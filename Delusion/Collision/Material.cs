using Delusion.Illusion;

namespace Delusion.Collision {
	public class Material {
		public RgbColor Color { get; set; } = new RgbColor{Red = 0.5f, Green = 0.5f, Blue = 0.5f};
		public float Luminosity { get; set; }
	}
}