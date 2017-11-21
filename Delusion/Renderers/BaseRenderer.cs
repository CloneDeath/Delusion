using Delusion.Collision;
using Delusion.Illusion;

namespace Delusion.Renderers {
	public abstract class BaseRenderer : IRenderer {
		public Picture RenderSceneWithCamera(Scene scene, PerspectiveCamera camera) {
			var picture = new Picture(camera.Resolution);
			foreach (var pixelRay in camera.GetPixelRays()) {
				//if (pixelRay.Position.X == 57 && pixelRay.Position.Y == 60)
				picture.SetColor(pixelRay.Position, GetColor(scene, pixelRay.Ray));
			}
			return picture;
		}

		protected abstract RgbColor GetColor(Scene scene, Ray ray);
	}
}