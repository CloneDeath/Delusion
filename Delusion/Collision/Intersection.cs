using System.Numerics;
using Delusion.Illusion;

namespace Delusion.Collision {
	public class Intersection : ITraceInformation {
		private readonly Ray _source;
		private readonly Material _material;

		public Intersection(Vector3 position, Ray source, Material material) {
			_material = material;
			_source = source;
			IntersectionPosition = position;
		}
		public bool Intersects => true;
		public Vector3 IntersectionPosition { get; }
		public float Distance => (_source.Origin - IntersectionPosition).Length();

		public RgbColor Color => _material.Color;
	}
}