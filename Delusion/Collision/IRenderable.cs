using System.Numerics;

namespace Delusion.Collision {
	public interface IRenderable {
		Vector3 Origin { get; }
		ITraceInformation CalculateIntersection(Ray line);
	}
}