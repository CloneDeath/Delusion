namespace Delusion.Illusion {
	public partial struct RgbColor {
		public static RgbColor operator *(RgbColor left, float right) {
			return new RgbColor {
				Red = left.Red * right,
				Blue = left.Blue * right,
				Green = left.Green * right
			};
		}

		public static RgbColor operator /(RgbColor left, float right) {
			return new RgbColor {
				Red = left.Red / right,
				Green = left.Green / right,
				Blue = left.Blue / right
			};
		}
	}
}