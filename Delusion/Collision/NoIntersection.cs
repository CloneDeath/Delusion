using System.Numerics;

namespace Delusion.Collision {
	public class NoIntersection : IIntersectionInformation {
		public bool Intersects => false;
		public Vector3 IntersectionPosition => Vector3.Zero;
	}
}