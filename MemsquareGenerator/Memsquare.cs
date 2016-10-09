using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace MemsquareGenerator {
	public class Memsquare {
		/// <summary>
		/// Gives a block a value to be used for a color channel that represents the data in the block
		/// in some manner.
		/// The parameter <code>block</code> may have a length less than the block size, even 0.
		/// </summary>
		/// <param name="block">The block to analyse</param>
		/// <returns>A value for a color channel that represents the block in some manner.</returns>
		public delegate byte ColoringModeFunction(byte[] block);

		public struct ColoringMode {
			public ColoringModeFunction Red;
			public ColoringModeFunction Green;
			public ColoringModeFunction Blue;

			public ColoringMode(ColoringModeFunction red, ColoringModeFunction green, ColoringModeFunction blue) {
				Red = red;
				Green = green;
				Blue = blue;
			}
		}

		public static Dictionary<string, ColoringModeFunction> COLORING_MODES = new Dictionary<string, ColoringModeFunction> {
			{
				"Average",
				new ColoringModeFunction((byte[] block) => {
					if (block.Length == 0) return 0;

					long sum = 0;
					for (int i = 0; i < block.Length; ++i) {
						sum += block[i];
					}

					return (byte) (sum / block.Length);
				})
			},
			{
				"Sum (mod 256)",
				new ColoringModeFunction((byte[] block) => {
					if (block.Length == 0) return 0;

					long sum = 0;
					for (int i = 0; i < block.Length; ++i) {
						sum += block[i];
					}

					return (byte) (sum % 256);
				})
			},
			{
				"Entropy",
				new ColoringModeFunction((byte[] block) => {
					if (block.Length == 0) return 0;

					double entropy = 0;

					Dictionary<byte, int> seen = new Dictionary<byte, int>();
					for (int i = 0; i < 256; ++i) {
						seen.Add((byte) i, 0);
					}

					for (int i = 0; i < block.Length; ++i) {
						seen[block[i]] = seen[block[i]] + 1;
					}

					for (int i = 0; i < 256; ++i) {
						double probabilityX = (double) seen[(byte) i] / block.Length;
						if (probabilityX > 0) {
							entropy -= probabilityX * Math.Log(probabilityX, 2);
						}
					}

					return (byte) (entropy * 32);
				})
			},
			{
				"Empty",
				new ColoringModeFunction((byte[] block) => {
					return 0;
				})
			}
		};

		private static int NearestSquarePowerOfTwo(double n) {
			for (int i = 0; ; i++) {
				int value = (int) Math.Pow(Math.Pow(2, i), 2);
				if (value > n) {
					return value;
				}
			}
		}

		private static byte[] GetBlock(byte[] fileData, int i, int blockSize) {
			int startIndex = i * blockSize;
			if (startIndex >= fileData.Length) {
				return new byte[] { };
			}

			byte[] block;

			if (startIndex + blockSize >= fileData.Length) {
				// Get the maximum length we can possibly read
				int length = fileData.Length - startIndex;
				block = new byte[length];

				Array.Copy(fileData, startIndex, block, 0, length);

				return block;
			}

			block = new byte[blockSize];

			Array.Copy(fileData, startIndex, block, 0, blockSize);

			return block;
		}

		private static Color CharacterizeBlock(byte[] block, ColoringMode coloringMode) {
			return Color.FromArgb(
				coloringMode.Red(block),
				coloringMode.Green(block),
				coloringMode.Blue(block)
			);
		}

		/// <summary>
		/// Get the amount of blocks in a memsquare based on a file size and block size.
		/// </summary>
		/// <param name="fileSize">The file's size in bytes</param>
		/// <param name="blockSize">The size of each block in bytes</param>
		/// <returns>The amount of blocks in the memsquare</returns>
		public static int GetBlockCount(int fileSize, int blockSize) {
			return NearestSquarePowerOfTwo((double) fileSize / blockSize);
		}

		/// <summary>
		/// Get the side length of a memsquare image based on a file size and block size.
		/// </summary>
		/// <param name="fileSize">The file's size in bytes</param>
		/// <param name="blockSize">The size of each block in bytes</param>
		/// <returns>The side length of the memsquare</returns>
		public static int GetSideLength(int fileSize, int blockSize) {
			return (int) Math.Sqrt(GetBlockCount(fileSize, blockSize));
		}

		/// <summary>
		/// Creates a memsquare from a file.
		/// </summary>
		/// <param name="worker">The background worker the function is running on, or null if it isn't</param>
		/// <param name="fileData">The file to create the memsquare of</param>
		/// <param name="blockSize">Size of each block in bytes</param>
		/// <param name="coloringMode">Method in which to color each pixel based on the block</param>
		/// <returns>A memsquare based on the file</returns>
		public static Bitmap Generate(BackgroundWorker worker, byte[] fileData, int blockSize, ColoringMode coloringMode) {
			int fileSize = fileData.Length;

			// Side length of square must be a power of two for the Hilbert curve,
			// so therefore to maintain a square the number of blocks must be a square
			// number.
			int blockCount = GetBlockCount(fileSize, blockSize);
			int sideLength = GetSideLength(fileSize, blockSize);

			Bitmap memsquare = new Bitmap(sideLength, sideLength);
			for (int i = 0; i < blockCount; ++i) {
				if (worker != null && worker.CancellationPending) {
					memsquare.Dispose();
					return null;
				}

				byte[] block = GetBlock(fileData, i, blockSize);
				Color c = CharacterizeBlock(block, coloringMode);

				Tuple<int, int> position = Utility.HilbertDToXY(sideLength, i);

				memsquare.SetPixel(position.Item1, position.Item2, c);

				double percentage = (i + 1) / (double) blockCount * 100.0;

				// Don't report the percentage too often - otherwise the UI locks up entirely
				if (worker != null && i % 5 == 0) {
					worker.ReportProgress((int) percentage);
				}
			}

			// As we only report every so often, 100% doesn't usually get reported.
			// Just do it now so everything looks good.
			if (worker != null) worker.ReportProgress(100);

			return memsquare;
		}
	}
}
