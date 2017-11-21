namespace Delusion.Illusion {
	public partial struct RgbColor {
		public static RgbColor White		=> new RgbColor{Red = 1, Green = 1, Blue = 1};
		public static RgbColor Black		=> new RgbColor{Red = 0, Green = 0, Blue = 0};
		public static RgbColor FullRed		=> new RgbColor{Red = 1, Green = 0, Blue = 0};
		public static RgbColor FullGreen	=> new RgbColor{Red = 0, Green = 1, Blue = 0};
		public static RgbColor FullBlue		=> new RgbColor{Red = 0, Green = 0, Blue = 1};
	}
}