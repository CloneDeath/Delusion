using System.Numerics;

namespace Delusion.Collision {
	public class Ray {
		public Vector3 Origin { get; set; }
		public Vector3 Direction { get; set; }

		public override string ToString() {
			return "{" + $"Origin={Origin},Direction={Direction}" + "}";
		}
	}
}