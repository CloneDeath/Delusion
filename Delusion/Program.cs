using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Numerics;
using Delusion.Angles;
using Delusion.Collision;
using Delusion.Collision.Shapes;
using Delusion.Illusion;
using Delusion.Illusion.Format;
using Delusion.Renderers;

namespace Delusion {
	public class Program {
		public static void Main() {
			var camera = new PerspectiveCamera {
				HorizontalFieldOfView = new Circles(0.25f),
				Resolution = new Size(100, 100),
				Position = new Vector3(0, 0, 5),
				Direction = -Vector3.UnitZ,
				Up = Vector3.UnitY
			};
			var scene = new Scene {
				new Sphere {
					Postion = Vector3.Zero,
					Radius = 1,
					Material = new Material {
						Color = RgbColor.FullRed
					}
				},
				new Sphere {
					Postion = new Vector3(2, 2, 0),
					Radius = 0.5f,
					Material = new Material {
						Color = RgbColor.FullGreen
					}
				},
				new Sphere {
					Postion = new Vector3(-2, 2, 1),
					Radius = 0.25f,
					Material = new Material {
						Color = RgbColor.White,
						Luminosity = 10
					}
				},
				new Sphere {
					Postion = new Vector3(2, -2, 1),
					Radius = 0.25f,
					Material = new Material {
						Color = RgbColor.White,
						Luminosity = 10000
					}
				},
				new Cube {
					Transformation = Matrix4x4.CreateScale(-11)
				}
			};

			var renderers = new Dictionary<IRenderer, string> {
				{new DepthRenderer(), "depth"},
				{new HitRenderer(), "hit"},
				{new ColorRenderer(), "color"},
				{new NormalRenderer(), "normal"},
				{new DiffusiveRenderer { MaxDepth = 5 }, "diffuse"}
			};

			const string outputDirectory = "out";
			if (!Directory.Exists(outputDirectory)) Directory.CreateDirectory(outputDirectory);
			foreach (var rendererInfo in renderers) {
				var image = rendererInfo.Key.RenderSceneWithCamera(scene, camera);
				image.SaveAsPortablePixMap(Path.Combine(outputDirectory, rendererInfo.Value + ".ppm"));
			}
		}
	}
}