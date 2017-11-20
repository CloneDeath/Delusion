using System.Drawing;
using Delusion.Collision;

namespace Delusion {
	public class PixelRay : IPixelRay {
		public Ray Ray { get; set; }
		public Point Position { get; set; }

		public override string ToString() {
			return "{" + $"Position={Position},Ray={Ray}" + "}";
		}
	}
}