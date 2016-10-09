using System;

namespace MemsquareGenerator {
	class Utility {
		/// <summary>
		/// Converts a point on the Hilbert curve described by an index <code>d</code> into
		/// X and Y coordinates, in <code>Item1</code> and <code>Item2</code> of the returned tuple respectively.
		/// Based on https://en.wikipedia.org/wiki/Hilbert_curve#Applications_and_mapping_algorithms
		/// </summary>
		/// <param name="n">The side length of the Hilbert square</param>
		/// <param name="d">The index into the curve</param>
		/// <returns>The X and Y coordinates of the point</returns>
		public static Tuple<int, int> HilbertDToXY(int n, int d) {
			int x = 0;
			int y = 0;

			int rx;
			int ry;
			int t = d;

			for (int s = 1; s < n; s *= 2) {
				rx = 1 & (t / 2);
				ry = 1 & (t ^ rx);

				if (ry == 0) {
					if (rx == 1) {
						x = s - 1 - x;
						y = s - 1 - y;
					}

					int temp = x;
					x = y;
					y = temp;
				}

				x += s * rx;
				y += s * ry;

				t /= 4;
			}

			return new Tuple<int, int>(x, y);
		}

		/// <summary>
		/// Determines the index into the Hilbert curve from a points X and Y coordinates, in <code>Item1</code>
		/// and <code>Item2</code> of <code>xy</code> respectively.
		/// Based on https://en.wikipedia.org/wiki/Hilbert_curve#Applications_and_mapping_algorithms
		/// </summary>
		/// <param name="n">The side length of the Hilbert square</param>
		/// <param name="xy">The X and Y coordinates of the point</param>
		/// <returns>The index into the curve</returns>
		public static int XYToHilbertD(int n, Tuple<int, int> xy) {
			int x = 0;
			int y = 0;

			int rx;
			int ry;
			int d = 0;

			for (int s = n / 2; s > 0; s /= 2) {
				rx = (xy.Item1 & s) > 0 ? 1 : 0;
				ry = (xy.Item2 & s) > 0 ? 1 : 0;
				d += s * s * ((3 * rx) ^ ry);

				if (ry == 0) {
					if (rx == 1) {
						x = s - 1 - x;
						y = s - 1 - y;
					}

					int temp = x;
					x = y;
					y = temp;
				}
			}

			return d;
		}
	}
}
