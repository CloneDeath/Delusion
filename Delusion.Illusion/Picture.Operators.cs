namespace Delusion.Illusion {
	public partial class Picture {
		public static Picture operator *(Picture picture, float scale) {
			var copy = new Picture(picture.Resolution);
			for (var x = 0; x < copy.Width; x++)
			for (var y = 0; y < copy.Height; y++) {
				copy._pixels[x, y] = picture._pixels[x, y] * scale;
			}
			return copy;
		}
	}
}