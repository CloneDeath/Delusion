using Delusion.Collision;
using Delusion.Illusion;
using Delusion.Renderers.DataMaps;

namespace Delusion.Renderers {
	public class DepthRenderer : IRenderer {
		public Picture RenderSceneWithCamera(Scene scene, PerspectiveCamera camera) {
			var depth = new DepthMap(camera.Resolution);
			foreach (var pixelRay in camera.GetPixelRays()) {
				depth[pixelRay.Position.X, pixelRay.Position.Y] = GetDepth(scene, pixelRay.Ray);
			}
			return DepthAsPicture(depth);
		}

		private Picture DepthAsPicture(DepthMap depth) {
			var maxDepth = float.MinValue;
			var minDepth = float.MaxValue;
			
			for (var x = 0; x < depth.Width; x++)
			for (var y = 0; y < depth.Height; y++) {
				if (depth[x, y] == null) continue;
				
				var currentDepth = depth[x, y].Value;
				if (currentDepth > maxDepth) maxDepth = currentDepth;
				if (currentDepth < minDepth) minDepth = currentDepth;
			}
			
			var picture = new Picture(depth.Resolution);
			for (var x = 0; x < depth.Width; x++)
			for (var y = 0; y < depth.Height; y++) {
				var intensity = GetIntensity(depth[x, y], minDepth, maxDepth);
				var color = new RgbColor{Red = intensity, Green = intensity, Blue = intensity};
				picture.SetColor(x, y, color);
			}
			return picture;
		}

		protected virtual float GetIntensity(float? depth, float minDepth, float maxDepth) {
			if (depth == null) return 0;
			return 1 - (depth.Value - minDepth) / (maxDepth - minDepth);
		}

		protected virtual float? GetDepth(Scene scene, Ray ray) {
			var hit = scene.Trace(ray);
			return hit.Intersects 
				? (float?) hit.Distance 
				: null;
		}
	}
}