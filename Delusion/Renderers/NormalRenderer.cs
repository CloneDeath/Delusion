using Delusion.Collision;
using Delusion.Extensions;
using Delusion.Illusion;

namespace Delusion.Renderers {
	public class NormalRenderer : BaseRenderer {
		protected override RgbColor GetColor(Scene scene, Ray ray) {
			var hit = scene.Trace(ray);
			var normal = hit.Normal.Normalized();
			
			return new RgbColor {
				Red = GetChannelFromNormal(normal.X),
				Green = GetChannelFromNormal(normal.Y),
				Blue = GetChannelFromNormal(normal.Z)
			};
		}

		private static float GetChannelFromNormal(float normal) {
			return (normal + 1) / 2;
		}
	}
}