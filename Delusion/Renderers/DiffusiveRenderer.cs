using System.Numerics;
using Delusion.Collision;
using Delusion.Extensions;
using Delusion.Illusion;

namespace Delusion.Renderers {
	public class DiffusiveRenderer : BaseRenderer {
		public int MaxDepth { get; set; } = 10;

		protected override RgbColor GetColor(Scene scene, Ray ray) {
			return GetColor(scene, ray, MaxDepth);
		}

		public virtual RgbColor GetColor(Scene scene, Ray ray, int depth) {
			if (depth < 0) return RgbColor.Black;
			
			var hit = scene.Trace(ray);
			
			if (!hit.Intersects) return RgbColor.Black;

			var emission = RgbColor.Black;
			
			if (hit.Luminosity > 0) {
				var intensity = Vector3.Dot(hit.Normal.Normalized(), -ray.Direction);
				emission = hit.Color * hit.Luminosity * intensity;
			}

			var otherColor = RgbColor.Black;
			foreach (var entity in scene) {
				if (entity == hit.Entity) continue;
				var check = new Ray {
					Direction = (entity.Origin - hit.IntersectionPosition).Normalized(),
					Origin = hit.IntersectionPosition
				};

				var deflectionStrength = Vector3.Dot(check.Direction, hit.Normal);
				if (deflectionStrength < 0) continue;
				otherColor += GetColor(scene, check, depth - 1) * deflectionStrength;
			}
			var distanceSquared = (ray.Origin - hit.IntersectionPosition).LengthSquared();
			return (emission + hit.Color * otherColor) / distanceSquared;
		}
	}
}