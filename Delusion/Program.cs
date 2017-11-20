using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Delusion.Angles;
using Delusion.Collision;
using Delusion.Collision.Shapes;
using Delusion.Illusion.Format;
using Delusion.Renderers;

namespace Delusion {
	public class Program {
		public static void Main() {
			var camera = new PerspectiveCamera {
				HorizontalFieldOfView = new Circles(0.25f),
				Resolution = new Size(1000, 1000),
				Position = new Vector3(0, 0, 5),
				Direction = -Vector3.UnitZ,
				Up = Vector3.UnitY
			};
			var scene = new Scene {
				new Sphere {
					Postion = Vector3.Zero,
					Radius = 1
				},
				new Sphere {
					Postion = new Vector3(2, 2, 0),
					Radius = 0.5f
				}
			};

			var renderers = new Dictionary<IRenderer, string> {
				{ new DepthRenderer(), "depth" },
				{ new HitRenderer(), "hit" },
				{ new ColorRenderer(), "color" }
			};

			foreach (var rendererInfo in renderers) {
				var image = rendererInfo.Key.RenderSceneWithCamera(scene, camera);
				image.SaveAsPortablePixMap(rendererInfo.Value + ".ppm");
			}

		}
	}
}