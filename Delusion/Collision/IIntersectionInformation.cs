using System.Numerics;

namespace Delusion.Collision {
	public interface IIntersectionInformation {
		bool Intersects { get; }
		Vector3 IntersectionPosition { get; }
	}
}