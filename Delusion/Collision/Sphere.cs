using System;
using System.Numerics;
using Delusion.Extensions;

namespace Delusion.Collision {
	public class Sphere : IRenderable {
		public Vector3 Postion { get; set; }
		public float Radius { get; set; }

		public IIntersectionInformation CalculateIntersection(Ray line) {
			var relativePosition = Postion - line.Origin;

			var sphereInRayspace = Vector3.Dot(relativePosition, line.Direction.Normalized());
			if (sphereInRayspace < 0) return new NoIntersection();

			var closestDistance = MathF.Sqrt(relativePosition.LengthSquared() - MathF.Pow(sphereInRayspace, 2));
			if (closestDistance > Radius) return new NoIntersection();

			var backdistanceInRaySpace = MathF.Sqrt(MathF.Pow(Radius, 2) - MathF.Pow(closestDistance, 2));
			var nearCollisionInRaySpace = sphereInRayspace - backdistanceInRaySpace;

			return new Intersection(line.Origin + Vector3.Multiply(line.Direction.Normalized(), nearCollisionInRaySpace));
		}
	}
}