using System.Numerics;

namespace Delusion.Collision {
	public class Intersection : IIntersectionInformation {
		public Intersection(Vector3 position) {
			IntersectionPosition = position;
		}
		public bool Intersects => true;
		public Vector3 IntersectionPosition { get; }
	}
}