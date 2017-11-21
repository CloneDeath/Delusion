using System.Numerics;

namespace Delusion.Collision.Shapes {
	public class Cube : IRenderable {
		public Matrix4x4 Transformation { get; set; } = Matrix4x4.Identity;
		public Material Material { get; set; } = new Material();

		private Triangle[] GetTriangles() {
			var transform = Matrix4x4.CreateTranslation(-0.5f, -0.5f, -0.5f) * Transformation;
			var zero = Vector3.Transform(Vector3.Zero, transform);
			var x = Vector3.Transform(Vector3.UnitX, transform);
			var y = Vector3.Transform(Vector3.UnitY, transform);
			var z = Vector3.Transform(Vector3.UnitZ, transform);
			var xy = Vector3.Transform(Vector3.UnitX + Vector3.UnitY, transform);
			var xz = Vector3.Transform(Vector3.UnitX + Vector3.UnitZ, transform);
			var yz = Vector3.Transform(Vector3.UnitY + Vector3.UnitZ, transform);
			var xyz = Vector3.Transform(Vector3.One, transform);

			return new[] {
				// bottom
				new Triangle {Points = new[] { zero, y, x} },
				new Triangle {Points = new[] { xy, x, y } },
				
				// top
				new Triangle {Points = new[] { z, xz, yz } },
				new Triangle {Points = new[] { xyz, yz, xz } },
				
				// left
				new Triangle {Points = new[] { zero, z, y } },
				new Triangle {Points = new[] { yz, y, z } },
				
				// right
				new Triangle {Points = new[] { x, xy, xz } },
				new Triangle {Points = new[] { xyz, xz, xy } },
				
				// front
				new Triangle {Points = new[] { zero, x, z } },
				new Triangle {Points = new[] { xz, z, x } },
				
				// back
				new Triangle {Points = new[] { y, yz, xy } },
				new Triangle {Points = new[] { xyz, xy, yz } },
			};
		}
		
		public ITraceInformation CalculateIntersection(Ray line) {
			ITraceInformation bestHit = null;
			foreach (var triangle in GetTriangles()) {
				triangle.Material = Material;
				var hit = triangle.CalculateIntersection(line);
				if (!hit.Intersects) continue;

				if (bestHit == null) {
					bestHit = hit;
					continue;
				}

				if (hit.Distance < bestHit.Distance) bestHit = hit;
			}
			return bestHit ?? new NoIntersection();
		}
	}
}