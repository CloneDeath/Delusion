﻿using System;
using System.Numerics;
using Delusion.Extensions;

namespace Delusion.Collision.Shapes {
	public class Sphere : IRenderable {
		public Vector3 Postion { get; set; }
		public float Radius { get; set; }
		public Material Material { get; set; } = new Material();

		public Vector3 Origin => Postion;

		public ITraceInformation CalculateIntersection(Ray line) {
			var relativePosition = Postion - line.Origin;
			if (relativePosition.Length() <= Radius) return new NoIntersection();

			var sphereInRayspace = Vector3.Dot(relativePosition, line.Direction);
			if (sphereInRayspace < 0) return new NoIntersection();

			var closestDistance = MathF.Sqrt(Math.Abs(relativePosition.LengthSquared() - MathF.Pow(sphereInRayspace, 2)));
			if (closestDistance > Radius) return new NoIntersection();

			var backdistanceInRaySpace = MathF.Sqrt(MathF.Pow(Radius, 2) - MathF.Pow(closestDistance, 2));
			var nearCollisionInRaySpace = sphereInRayspace - backdistanceInRaySpace;

			var hitPosition = line.Origin + Vector3.Multiply(line.Direction, nearCollisionInRaySpace);
			return new Intersection(hitPosition, line, Material, this) {
				Normal = (hitPosition - Postion).Normalized()
			};
		}
	}
}