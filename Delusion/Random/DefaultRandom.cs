using System.Collections.Generic;
using System.Numerics;
using Delusion.Extensions;

namespace Delusion.Random {
	public class DefaultRandom : IRandom {
		private readonly System.Random _random;
		
		public DefaultRandom() {
			_random = new System.Random();
		}
		
		public Vector3 GetVector3() {
			return new Vector3 {
				X = (float)_random.NextDouble(),
				Y = (float)_random.NextDouble(),
				Z = (float)_random.NextDouble(),
			};
		}

		public Vector3 GetUnitVector3() {
			return GetVector3().Normalized();
		}

		public Vector3 GetDome(Vector3 normal) {
			var vector = GetUnitVector3();
			return Vector3.Dot(vector, normal) > 0 
				? vector 
				: -vector;
		}

		public IEnumerable<Vector3> GetDomes(Vector3 normal, int count) {
			for (var i = 0; i < count; i++) {
				yield return GetDome(normal);
			}
		}
	}
}