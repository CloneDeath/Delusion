using System;
using System.Numerics;
using Delusion.Extensions;

namespace Delusion.Collision.Shapes {
	public class Triangle : IRenderable {
		public Vector3 Point0 { get; set; }
		public Vector3 Point1 { get; set; }
		public Vector3 Point2 { get; set; }
		
		public Material Material { get; set; } = new Material();

		public Vector3[] Points {
			get => new[] {Point0, Point1, Point2};
			set {
				Point0 = value[0];
				Point1 = value[1];
				Point2 = value[2];
			}
		}

		public ITraceInformation CalculateIntersection(Ray line) {
			var edge1 = Point1 - Point0;
			var edge2 = Point2 - Point0;

			var height = Vector3.Cross(line.Direction, edge2);
			var alpha = Vector3.Dot(height, edge1);

			if (MathF.Abs(alpha) <= 1e-10) return new NoIntersection();

			var flow = 1 / alpha;
			var sRelativeOrigin = line.Origin - Point0;
			var u = flow * Vector3.Dot(sRelativeOrigin, height);
			
			if (u < 0 || u > 1) return new NoIntersection();

			var qHeight = Vector3.Cross(sRelativeOrigin, edge1);
			var v = flow * Vector3.Dot(line.Direction, qHeight);
			
			if (v < 0 || u + v > 1) return new NoIntersection();

			var time = flow * Vector3.Dot(edge2, qHeight);
			if (time < 0) return new NoIntersection();

			var intersection = line.Origin + line.Direction * time;
			
			return new Intersection(intersection, line, Material) {
				Normal = Vector3.Cross(edge1, edge2).Normalized()
			};
		}
	}
}