using System.Drawing;
using Delusion.Collision;

namespace Delusion {
	public class PixelRay : IPixelRay {
		public PixelRay(Ray ray) {
			Ray = ray;
		}
		
		public Ray Ray { get; }
		public Point Position { get; set; }

		public override string ToString() {
			return "{" + $"Position={Position},Ray={Ray}" + "}";
		}
	}
}