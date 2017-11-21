using System.Numerics;
using Delusion.Illusion;

namespace Delusion.Collision {
	public class NoIntersection : ITraceInformation {
		public bool Intersects => false;
		public Vector3 IntersectionPosition => Vector3.Zero;
		public Vector3 Normal => Vector3.Zero;
		public float Distance => float.MaxValue;
		public RgbColor Color => RgbColor.Black;
		public float Luminosity => 0;
		public IRenderable Entity => null;

		public override string ToString() {
			return "No Intersection";
		}
	}
}