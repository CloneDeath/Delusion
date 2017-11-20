using Delusion.Collision;
using Delusion.Illusion;

namespace Delusion.Renderers {
	public class HitRenderer : BaseRenderer {
		protected override RgbColor GetColor(Scene scene, Ray ray) {
			foreach (var entity in scene) {
				var hit = entity.CalculateIntersection(ray);
				if (hit.Intersects) return new RgbColor{ Green = 1 };
			}
			return new RgbColor{ Red = 1 };
		}
	}
}