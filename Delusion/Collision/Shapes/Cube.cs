using System.Numerics;

namespace Delusion.Collision.Shapes {
	public class Cube : IRenderable {
		public Matrix4x4 Transformation { get; set; } = Matrix4x4.Identity;
		public Material Material { get; set; } = new Material();
		public Vector3 Origin => Transformation.Translation;

		private Quad[] GetTriangles() {
			var transform = Matrix4x4.CreateTranslation(-0.5f, -0.5f, -0.5f) * Transformation;
			var zero = Vector3.Transform(Vector3.Zero, transform);
			var x = Vector3.Transform(Vector3.UnitX, transform);
			var y = Vector3.Transform(Vector3.UnitY, transform);
			var z = Vector3.Transform(Vector3.UnitZ, transform);
			var xy = Vector3.Transform(Vector3.UnitX + Vector3.UnitY, transform);
			var xz = Vector3.Transform(Vector3.UnitX + Vector3.UnitZ, transform);
			var yz = Vector3.Transform(Vector3.UnitY + Vector3.UnitZ, transform);

			return new[] {
				new Quad {Points = new[] { zero, y, x} }, // bottom
				new Quad {Points = new[] { z, xz, yz } }, // top
				new Quad {Points = new[] { zero, z, y } }, // left
				new Quad {Points = new[] { x, xy, xz } }, // right
				new Quad {Points = new[] { zero, x, z } }, // front
				new Quad {Points = new[] { y, yz, xy } } // back
			};
		}

		public ITraceInformation CalculateIntersection(Ray line) {
			ITraceInformation bestHit = null;
			foreach (var triangle in GetTriangles()) {
				var hit = triangle.CalculateIntersection(line);
				if (!hit.Intersects) continue;

				if (bestHit == null) {
					bestHit = hit;
					continue;
				}

				if (hit.Distance < bestHit.Distance) bestHit = hit;
			}
			if (bestHit == null) return new NoIntersection();
			return new Intersection(bestHit.IntersectionPosition, line, Material, this) {
				Normal = bestHit.Normal
			};
		}
	}
}