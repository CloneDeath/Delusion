﻿using System.Numerics;
using Delusion.Illusion;

namespace Delusion.Collision {
	public class NoIntersection : ITraceInformation {
		public bool Intersects => false;
		public Vector3 IntersectionPosition => Vector3.Zero;
		public float Distance => float.MaxValue;
		public RgbColor Color => RgbColor.Black;
	}
}