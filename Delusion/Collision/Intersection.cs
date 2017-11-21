using System.Numerics;
using Delusion.Illusion;

namespace Delusion.Collision {
	public class Intersection : ITraceInformation {
		private readonly Ray _source;
		private readonly Material _material;

		public Intersection(Vector3 position, Ray source, Material material, IRenderable entity) {
			_material = material;
			_source = source;
			IntersectionPosition = position;
			Entity = entity;
		}
		public bool Intersects => Distance * Distance > 0;
		public Vector3 IntersectionPosition { get; }
		public Vector3 Normal { get; set; } = Vector3.Zero;
		public float Distance => (_source.Origin - IntersectionPosition).Length();

		public RgbColor Color => _material.Color;
		public float Luminosity => _material.Luminosity;
		public IRenderable Entity { get; }
	}
}