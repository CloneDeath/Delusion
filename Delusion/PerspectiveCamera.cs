using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Delusion.Angles;
using Delusion.Collision;
using Delusion.Extensions;

namespace Delusion {
	public class PerspectiveCamera {
		public float ScreenWidth => MathF.Acos(HorizontalFieldOfView.InRadians() / 2) * 2;
		public float ScreenHeight => ScreenWidth * VerticalAspectRatio;
		
		public IAngle HorizontalFieldOfView { get; set; }
		public IAngle VerticalFieldOfView => new Radians(MathF.Sin(ScreenHeight / 2) * 2);
		
		public float VerticalAspectRatio => Resolution.Height * 1.0f / Resolution.Width;
		public Size Resolution { get; set; }
		public Vector3 Position { get; set; }
		public Vector3 Direction { get; set; }
		public Vector3 Up { get; set; }
		
		public int Width => Resolution.Width;
		public int Height => Resolution.Height;

		public IEnumerable<IPixelRay> GetPixelRays() {
			for (var x = 0; x < Resolution.Width; x++)
			for (var y = 0; y < Resolution.Height; y++) {
				yield return new PixelRay {
					Ray = new Ray {
						Origin = Position,
						Direction = GetDirection(x, y)
					},
					Position = new Point(x, y)
				};
			}
		}

		private Vector3 GetDirection(int x, int y) {
			var forward = Direction.Normalized();
			var up = Up.Normalized();
			var left = Vector3.Cross(up, forward).Normalized();
			var topLeft = forward + (left * ScreenWidth / 2) + (up * ScreenHeight / 2);
			var scaleX = x * 1.0f / Width;
			var scaleY = y * 1.0f / Height;
			return topLeft + (-up * scaleY * ScreenHeight) + (-left * scaleX * ScreenWidth);
		}
	}
}