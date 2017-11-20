using System.Drawing;

namespace Delusion.Illusion {
	public class Picture {
		private readonly RgbColor[,] _pixels;
		
		public Picture(Size resolution) {
			_pixels = new RgbColor[resolution.Width, resolution.Height];
		}

		public Size Resolution => new Size(Width, Height);
		public int Width => _pixels.GetLength(0);
		public int Height => _pixels.GetLength(1);

		public Pixel GetPixel(int x, int y) => new Pixel {
			Color = _pixels[x, y],
			Position = new Point(x, y)
		};

		public void SetColor(Point pixel, RgbColor color) {
			_pixels[pixel.X, pixel.Y] = color;
		}

		public void SetColor(int x, int y, RgbColor color) {
			SetColor(new Point(x, y), color);
		}
	}
}