using System.Numerics;
using Delusion.Collision;
using Delusion.Extensions;
using Delusion.Illusion;

namespace Delusion.Renderers {
	public class DiffusiveRenderer : BaseRenderer {
		
		protected override RgbColor GetColor(Scene scene, Ray ray) {
			var hit = scene.Trace(ray);
			if (!hit.Intersects) return RgbColor.Black;

			if (hit.Luminosity > 0) {
				var intensity = Vector3.Dot(hit.Normal.Normalized(), -ray.Direction);
				var distanceSquared = hit.Distance * hit.Distance;
				return hit.Color * hit.Luminosity * intensity / distanceSquared;
			}
			return RgbColor.Black;
		}
	}
}