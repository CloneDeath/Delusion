using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Delusion.Collision;

namespace Delusion {
	public class Scene : IEnumerable<IRenderable> {
		private readonly List<IRenderable> _entities;

		public Scene() {
			_entities = new List<IRenderable>();
		}
		
		public Scene(IEnumerable<IRenderable> entities) {
			_entities = entities.ToList();
		}

		public void Add(IRenderable entity) {
			_entities.Add(entity);
		}
		
		public ITraceInformation Trace(Ray ray) {
			ITraceInformation? closestHit = null;
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

		public IEnumerator<IRenderable> GetEnumerator() {
			return _entities.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}