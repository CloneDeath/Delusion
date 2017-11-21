using System.IO;

namespace Delusion.Illusion.Format {
	public static class PortablePixMap {
		public static void Save(Picture image, string fileName) {
			var writer = new StreamWriter(fileName);
			writer.Write("P6" + "\n");
			writer.Write(image.Width + " " + image.Height + "\n");
			writer.Write("255" + "\n");
			writer.Close();
			var writerB = new BinaryWriter(new FileStream(fileName, FileMode.Append));
			for (var y = 0; y < image.Height; y++)
			for (var x = 0; x < image.Width; x++)
			{
				var pixel = image.GetPixel(x, y);
				var color = pixel.Color;
				writerB.Write(FloatChannelToByte(color.Red));
				writerB.Write(FloatChannelToByte(color.Green));
				writerB.Write(FloatChannelToByte(color.Blue));
			}
			writerB.Close();
		}

		private static byte FloatChannelToByte(float color) {
			if (color < 0) return 0;
			if (color > 1) return 255;
			return (byte)(color * 255);
		}

		public static void SaveAsPortablePixMap(this Picture self, string fileName) {
			Save(self, fileName);
		}
	}
}