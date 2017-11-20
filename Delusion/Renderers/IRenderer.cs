using Delusion.Illusion;

namespace Delusion.Renderers {
	public interface IRenderer {
		Picture RenderSceneWithCamera(Scene scene, PerspectiveCamera camera);
	}
}