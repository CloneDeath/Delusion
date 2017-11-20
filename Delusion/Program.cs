using System.Drawing;
using System.Numerics;
using Delusion.Angles;
using Delusion.Collision;
using Delusion.Illusion.Format;

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
			
			var renderer = new DepthRenderer();
			var image = renderer.RenderSceneWithCamera(scene, camera);
			image.SaveAsPortablePixMap("out.ppm");
		}
	}
}