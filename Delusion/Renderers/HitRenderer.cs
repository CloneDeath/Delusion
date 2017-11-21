using Delusion.Collision;
using Delusion.Illusion;

namespace Delusion.Renderers {
	public class HitRenderer : BaseRenderer {
		protected override RgbColor GetColor(Scene scene, Ray ray) {
			var hit = scene.Trace(ray);
			return hit.Intersects
				? RgbColor.FullGreen
				: RgbColor.FullRed;
		}
	}
}