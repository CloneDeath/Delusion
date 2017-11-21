namespace Delusion.Illusion {
	public partial struct RgbColor {
		public static RgbColor operator +(RgbColor left, RgbColor right) {
			return new RgbColor {
				Red = left.Red + right.Red,
				Green = left.Green + right.Green,
				Blue = left.Blue + right.Blue
			};
		}

		public static RgbColor operator *(RgbColor left, RgbColor right) {
			return new RgbColor {
				Red = left.Red * right.Red,
				Green = left.Green * right.Green,
				Blue = left.Blue * right.Blue
			};
		}
		
		public static RgbColor operator *(RgbColor left, float right) {
			return new RgbColor {
				Red = left.Red * right,
				Green = left.Green * right,
				Blue = left.Blue * right
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