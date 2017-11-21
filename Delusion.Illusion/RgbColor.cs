namespace Delusion.Illusion {
	public partial struct RgbColor {
		public float Red { get; set; }
		public float Green { get; set; }
		public float Blue { get; set; }

		public override string ToString() {
			return "{" + $"Red={Red},Green={Green},Blue={Blue}" + "}";
		}
	}
}