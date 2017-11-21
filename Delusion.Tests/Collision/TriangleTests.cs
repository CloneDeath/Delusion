using System.Numerics;
using Delusion.Collision;
using Delusion.Collision.Shapes;
using FluentAssertions;
using Xunit;

namespace Delusion.Tests.Collision {
	public class TriangleTests {
		[Fact]
		public void ARayPointingDownTheOriginHitsATriangle() {
			var triangle = new Triangle {
				Point0 = new Vector3(0, 1, 0),
				Point1 = new Vector3(-1, -1, 0),
				Point2 = new Vector3(1, -1, 0)
			};
			var line = new Ray {
				Origin = Vector3.UnitZ,
				Direction = -Vector3.UnitZ
			};
			var hit = triangle.CalculateIntersection(line);
			hit.Intersects.Should().BeTrue();
			hit.IntersectionPosition.Should().Be(Vector3.Zero);
		}
		
		[Fact]
		public void ARayPointingUpDoesNotHitATriangle() {
			var triangle = new Triangle {
				Point0 = new Vector3(0, 1, 0),
				Point1 = new Vector3(-1, -1, 0),
				Point2 = new Vector3(1, -1, 0)
			};
			var line = new Ray {
				Origin = Vector3.UnitZ,
				Direction = Vector3.UnitY
			};
			var hit = triangle.CalculateIntersection(line);
			hit.Intersects.Should().BeFalse();
		}
	}
}