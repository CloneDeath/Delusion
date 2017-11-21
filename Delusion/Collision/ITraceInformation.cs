using System.Numerics;
using Delusion.Illusion;

namespace Delusion.Collision {
	public interface ITraceInformation {
		bool Intersects { get; }
		Vector3 IntersectionPosition { get; }
		Vector3 Normal { get; }
		float Distance { get; }
		RgbColor Color { get; }
		float Luminosity { get; }
		IRenderable Entity { get; }
	}
}