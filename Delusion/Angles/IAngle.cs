using System;

namespace Delusion.Angles {
	public interface IAngle {
		float InCircles();
	}

	public static class AngleExtensions {
		public static float InRadians(this IAngle self) {
			return self.InCircles() * MathF.PI * 2;
		}

		public static float InDegrees(this IAngle self) {
			return self.InCircles() * 360;
		}
	}
}