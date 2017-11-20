using System.Numerics;

namespace Delusion.Extensions {
	public static class VectorExtensions {
		public static Vector3 Normalized(this Vector3 self) {
			return Vector3.Normalize(self);
		}
	}
}