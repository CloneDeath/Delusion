using System.Numerics;
using Delusion.Extensions;

namespace Delusion.Collision {
	public class Ray {
		private Vector3 _direction;
		
		public Vector3 Origin { get; set; }
		public Vector3 Direction {
			get => _direction;
			set => _direction = value.Normalized();
		}

		public override string ToString() {
			return "{" + $"Origin={Origin},Direction={Direction}" + "}";
		}
	}
}