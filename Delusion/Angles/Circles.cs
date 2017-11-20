namespace Delusion.Angles {
	public class Circles : IAngle {
		private readonly float _angle;

		public Circles(float angle) {
			_angle = angle;
		}
		
		public float InCircles() {
			return _angle;
		}
	}
}