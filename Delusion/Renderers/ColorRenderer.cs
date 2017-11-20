using Delusion.Collision;
using Delusion.Illusion;

namespace Delusion.Renderers {
	public class ColorRenderer : BaseRenderer {
		protected override RgbColor GetColor(Scene scene, Ray ray) {
			var hit = scene.Trace(ray);
			return hit.Color;
		}
	}
}