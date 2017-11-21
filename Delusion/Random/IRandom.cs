using System.Collections.Generic;
using System.Numerics;

namespace Delusion.Random {
	public interface IRandom {
		Vector3 GetVector3();
		Vector3 GetUnitVector3();
		Vector3 GetDome(Vector3 normal);
		IEnumerable<Vector3> GetDomes(Vector3 normal, int count);
	}
}