using System;

namespace Delusion.Angles {
	public class Radians : IAngle {
		private readonly float _angle;

		public Radians(float angle) {
			_angle = angle;
		}
		
		public float InCircles() {
			return _angle / (MathF.PI * 2);
		}
	}
}