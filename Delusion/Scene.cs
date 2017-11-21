using System.Collections.Generic;
using System.Linq;
using Delusion.Collision;

namespace Delusion {
	public class Scene : List<IRenderable> {
		public ITraceInformation Trace(Ray ray) {
			ITraceInformation closestHit = null;
			foreach (var entity in this) {
				var hitInfo = entity.CalculateIntersection(ray);
				if (!hitInfo.Intersects) continue;
				if (closestHit == null) {
					closestHit = hitInfo;
					continue;
				}

				if (hitInfo.Distance < closestHit.Distance) {
					closestHit = hitInfo;
				}
			}
			return closestHit ?? new NoIntersection();
		}

		public Scene Without(params IRenderable[] ignore) {
			var elements = this.Where(e => !ignore.Contains(e)).ToList();
			var child = new Scene();
			child.AddRange(elements);
			return child;
		}
	}
}