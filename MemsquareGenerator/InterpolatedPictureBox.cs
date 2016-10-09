using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MemsquareGenerator {
	class InterpolatedPictureBox : PictureBox {
		public InterpolationMode InterpolationMode { get; set; }

		protected override void OnPaint(PaintEventArgs paintEventArgs) {
			paintEventArgs.Graphics.InterpolationMode = InterpolationMode;

			base.OnPaint(paintEventArgs);
		}

		public Point? ConvertMousePositionToImagePosition(Point coordinates) {
			if (SizeMode != PictureBoxSizeMode.Zoom) {
				throw new NotImplementedException();
			}

			if (Image == null) return coordinates;
			if (Width == 0 || Height == 0 || Image.Width == 0 || Image.Height == 0) return coordinates;
			
			float imageAspect = (float) Image.Width / Image.Height;
			float controlAspect = (float) Width / Height;
			float newX = coordinates.X;
			float newY = coordinates.Y;
			if (imageAspect > controlAspect) {
				float ratioWidth = (float) Image.Width / Width;

				newX *= ratioWidth;

				float scale = (float) Width / Image.Width;
				float displayHeight = scale * Image.Height;
				float diffHeight = Height - displayHeight;

				diffHeight /= 2;
				newY -= diffHeight;
				newY /= scale;
			} else {
				float ratioHeight = (float) Image.Height / Height;

				newY *= ratioHeight;

				float scale = (float) Height / Image.Height;
				float displayWidth = scale * Image.Width;
				float diffWidth = Width - displayWidth;

				diffWidth /= 2;
				newX -= diffWidth;
				newX /= scale;
			}
			int newXInt = (int) newX;
			int newYInt = (int) newY;

			if (newXInt < 0 || newXInt >= Image.Width || newYInt < 0 || newYInt >= Image.Height) {
				return null;
			} else {
				return new Point(newXInt, newYInt);
			}
		}
	}
}
