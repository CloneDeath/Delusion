using System.Numerics;
using Delusion.Collision;
using Delusion.Extensions;
using Delusion.Illusion;

namespace Delusion.Renderers {
	public class DiffusiveRenderer : BaseRenderer {
		public int MaxDepth = 10;
		
		protected override RgbColor GetColor(Scene scene, Ray ray) {
			return GetColor(scene, ray, MaxDepth);
		}

		public RgbColor GetColor(Scene scene, Ray ray, int depth) {
			if (depth <= 0) return RgbColor.Black;
			
			var hit = scene.Trace(ray);
			if (!hit.Intersects) return RgbColor.Black;

			var distanceSquared = hit.Distance * hit.Distance;
			var emission = RgbColor.Black;
			
			if (hit.Luminosity > 0) {
				var intensity = Vector3.Dot(hit.Normal.Normalized(), -ray.Direction);
				emission = hit.Color * hit.Luminosity * intensity / distanceSquared;
			}

			var reflection = new Ray {
				Direction = ray.Direction.ReflectionGivenNormal(hit.Normal).Normalized(),
				Origin = hit.IntersectionPosition
			};

			var otherColor = GetColor(scene, reflection, depth - 1) / distanceSquared;

			return emission + otherColor;
		}
	}
}