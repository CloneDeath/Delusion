using Delusion.Illusion;

namespace Delusion {
	public class SceneRenderer {
		public Picture RenderSceneWithCamera(Scene scene, PerspectiveCamera camera) {
			var picture = new Picture(camera.Resolution);
			foreach (var pixelRay in camera.GetPixelRays()) {
				var hitAny = false;
				foreach (var entity in scene) {
					var hit = entity.CalculateIntersection(pixelRay.Ray);
					if (hit.Intersects) hitAny = true;
				}
				
				if (!hitAny) picture.SetColor(pixelRay.Position, new RgbColor{ Red = 1 });
				else picture.SetColor(pixelRay.Position, new RgbColor{ Green = 1 });
			}
			return picture;
		}
	}
}