using System.Numerics;

namespace Delusion.Extensions {
	public static class VectorExtensions {
		public static Vector3 Normalized(this Vector3 self) {
			return Vector3.Normalize(self);
		}

		public static Vector3 ReflectionGivenNormal(this Vector3 self, Vector3 normal) {
			return Vector3.Reflect(self, normal);
		}
	}
}