using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace MemsquareGenerator {
	public partial class FormMain : Form {
		private static Dictionary<string, ImageFormat> EXTENSION_TO_IMAGE_FORMAT = new Dictionary<string, ImageFormat>() {
			{ "png", ImageFormat.Png },
			{ "jpg", ImageFormat.Jpeg }
		};

		private Bitmap memsquare;
		private int fileSize;
		private int blockSize;
		private int blockCount;
		private int sideLength;
		private Bitmap memsquareView;

		public FormMain() {
			InitializeComponent();

			List<string> coloringModesNamesList = new List<string>(Memsquare.COLORING_MODES.Keys);
			string[] coloringModesNames = coloringModesNamesList.ToArray();

			uiColoringModeRed.Items.AddRange(coloringModesNames);
			uiColoringModeGreen.Items.AddRange(coloringModesNames);
			uiColoringModeBlue.Items.AddRange(coloringModesNames);

			// There's no guarantee (I don't think) that the dictionary keys will be in the order
			// they were added, so this doesn't have to work but it does
			uiColoringModeRed.SelectedIndex = 0;
			uiColoringModeGreen.SelectedIndex = 1;
			uiColoringModeBlue.SelectedIndex = 3;

			uiStatus.Text = "";
		}

		private void DisplayMemsquare() {
			if (memsquare == null) return;

			if (memsquareView != null) {
				memsquareView.Dispose();
				memsquareView = null;
			}

			memsquareView = new Bitmap(memsquare.Width, memsquare.Height);
			using (Graphics graphics = Graphics.FromImage(memsquareView)) {
				ImageAttributes attributes = new ImageAttributes();

				float r = uiRedChannelVisible.Checked ? 1 : 0;
				float g = uiGreenChannelVisible.Checked ? 1 : 0;
				float b = uiBlueChannelVisible.Checked ? 1 : 0;

				attributes.SetColorMatrix(new ColorMatrix(new float[][]
					{
						new float[] { r, 0, 0, 0, 0 },
						new float[] { 0, g, 0, 0, 0 },
						new float[] { 0, 0, b, 0, 0 },
						new float[] { 0, 0, 0, 1, 0 },
						new float[] { 0, 0, 0, 0, 1 },
					}
				));

				graphics.DrawImage(memsquare, new Rectangle(0, 0, memsquareView.Width, memsquareView.Height), 0, 0, memsquare.Width, memsquare.Height, GraphicsUnit.Pixel, attributes);
				graphics.Flush();
			}

			uiMemsquareView.Image = memsquareView;
		}

		private void uiInputFileBrowse_Click(object sender, EventArgs e) {
			if (uiInputFileDialog.ShowDialog() == DialogResult.OK) {
				uiInputFileLocation.Text = uiInputFileDialog.FileName;
			}
		}

		private void uiGenerate_Click(object sender, EventArgs e) {
			uiWorker.RunWorkerAsync();

			uiMemsquareView.Image = null;

			if (memsquare != null) {
				memsquare.Dispose();
				memsquare = null;
			}

			if (memsquareView != null) {
				memsquareView.Dispose();
				memsquareView = null;
			}

			uiStatus.Text = "";
			uiGenerate.Enabled = false;
			uiCancel.Enabled = true;
		}

		private void uiCancel_Click(object sender, EventArgs e) {
			uiWorker.CancelAsync();
		}

		private void visibleChannels_CheckStateChanged(object sender, EventArgs e) {
			DisplayMemsquare();
		}

		private void uiMemsquareView_MouseMove(object sender, MouseEventArgs e) {
			if (memsquare == null) return;

			Point? imagePosition = uiMemsquareView.ConvertMousePositionToImagePosition(e.Location);

			if (imagePosition.HasValue) {
				string formatString = "block {0} of {1} (0x{2:X}-0x{3:X}){4}\tr: {5:X}\tg: {6:X}\tb: {7:X}";
				formatString = formatString.Replace("\t", "    ");

				int x = imagePosition.Value.X;
				int y = imagePosition.Value.Y;

				int d = Utility.XYToHilbertD(sideLength, new Tuple<int, int>(x, y));

				int startAddress = d * blockSize;
				int endAddress = (d + 1) * blockSize - 1;

				bool isInFile = startAddress <= fileSize;

				Color c = memsquare.GetPixel(x, y);

				uiStatus.Text = string.Format(
					formatString,
					d,
					blockCount,
					startAddress,
					endAddress,
					isInFile ? "" : " - not in file",
					c.R,
					c.G,
					c.B
				);
			}
		}

		private void uiSave_Click(object sender, EventArgs e) {
			if (memsquare == null) {
				MessageBox.Show("No memsquare has been generated.");
				return;
			}
			
			if (uiSaveDialog.ShowDialog() == DialogResult.OK) {
				string path = uiSaveDialog.FileName;
				string extension = Path.GetExtension(path).Replace(".", "").ToLower();

				ImageFormat imageFormat;

				if (!EXTENSION_TO_IMAGE_FORMAT.TryGetValue(extension, out imageFormat)) {
					imageFormat = ImageFormat.Png;
				}

				memsquare.Save(path, imageFormat);
			}
		}

		private void uiWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
			byte[] fileData = File.ReadAllBytes(uiInputFileLocation.Text);
			int blockSize = (int) uiBlockSize.Value;

			fileSize = fileData.Length;
			// Use this since we're talking about the instance variable
			this.blockSize = blockSize;
			blockCount = Memsquare.GetBlockCount(fileSize, blockSize);
			sideLength = Memsquare.GetSideLength(fileSize, blockSize);

			Memsquare.ColoringMode cm = new Memsquare.ColoringMode();

			this.Invoke(new Action(() => {
				cm.Red = Memsquare.COLORING_MODES[(string) uiColoringModeRed.SelectedItem];
				cm.Green = Memsquare.COLORING_MODES[(string) uiColoringModeGreen.SelectedItem];
				cm.Blue = Memsquare.COLORING_MODES[(string) uiColoringModeBlue.SelectedItem];
			}));

			memsquare = Memsquare.Generate(uiWorker, fileData, blockSize, cm);
		}

		private void uiWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e) {
			uiProgressBar.Value = e.ProgressPercentage;
		}

		private void uiWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			if (e.Error != null) {
				MessageBox.Show(string.Format(
					"An error occurred whilst generating the memsquare:\n\n{0}",
					e.Error.ToString()
				));
			} else {
				DisplayMemsquare();
			}

			uiProgressBar.Value = 0;
			uiCancel.Enabled = false;
			uiGenerate.Enabled = true;
		}
	}
}
