namespace Delusion.Illusion {
	public struct RgbColor {
		public float Red { get; set; }
		public float Green { get; set; }
		public float Blue { get; set; }
		
		public static RgbColor Black => new RgbColor{Red = 0, Green = 0, Blue = 0};
	}
}