using System.Numerics;
using Delusion.Collision;
using FluentAssertions;
using Xunit;

namespace Delusion.Tests.Collision {
	public class SphereTests {
		[Fact]
		public void ARayTravelingDownTheOriginIntersectsASphere() {
			var sphere = new Sphere {
				Postion = Vector3.UnitX,
				Radius = 0.5f
			};
			var line = new Ray {
				Origin = Vector3.Zero,
				Direction = Vector3.UnitX
			};
			var test = sphere.CalculateIntersection(line);
			test.Intersects.Should().BeTrue();
			test.IntersectionPosition.Should().Be(new Vector3(0.5f, 0, 0));
		}
		
		[Fact]
		public void ARayTravelingAwayFromASphereDoesNotIntersect() {
			var sphere = new Sphere {
				Postion = Vector3.UnitX,
				Radius = 0.5f
			};
			var line = new Ray {
				Origin = Vector3.Zero,
				Direction = -Vector3.UnitX
			};
			var test = sphere.CalculateIntersection(line);
			test.Intersects.Should().BeFalse();
		}

		[Fact]
		public void ARayTravelingAtAnAngleJustLargerThanTheRadiusWillMissTheSphere() {
			var sphere = new Sphere {
				Postion = Vector3.Zero,
				Radius = 1
			};
			var line = new Ray {
				Origin = new Vector3(0, 0, -2),
				Direction = new Vector3(-1, 0, 1)
			};
			var test = sphere.CalculateIntersection(line);
			test.Intersects.Should().BeFalse();
		}
	}
}