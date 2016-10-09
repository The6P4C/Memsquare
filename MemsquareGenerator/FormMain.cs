using System;
using System.Collections.Generic;
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
			uiColoringModeBlue.SelectedIndex = 2;
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

			uiGenerate.Enabled = false;
			uiCancel.Enabled = true;
		}

		private void uiCancel_Click(object sender, EventArgs e) {
			uiWorker.CancelAsync();
		}

		private void visibleChannels_CheckStateChanged(object sender, EventArgs e) {
			DisplayMemsquare();
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

			Memsquare.ColoringMode cm = new Memsquare.ColoringMode(
				Memsquare.COLORING_MODES["Average"],
				Memsquare.COLORING_MODES["Sum (mod 256)"],
				Memsquare.COLORING_MODES["Empty"]
			);

			memsquare = Memsquare.Generate(uiWorker, fileData, blockSize, cm);
		}

		private void uiWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e) {
			uiProgressBar.Value = e.ProgressPercentage;
		}

		private void uiWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
			DisplayMemsquare();

			uiProgressBar.Value = 0;
			uiCancel.Enabled = false;
			uiGenerate.Enabled = true;
		}
	}
}
