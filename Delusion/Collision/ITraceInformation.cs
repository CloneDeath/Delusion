using System.Numerics;
using Delusion.Illusion;

namespace Delusion.Collision {
	public interface ITraceInformation {
		bool Intersects { get; }
		Vector3 IntersectionPosition { get; }
		float Distance { get; }
		RgbColor Color { get; }
	}
}