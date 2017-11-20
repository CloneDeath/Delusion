using System.Drawing;
using Delusion.Collision;

namespace Delusion {
	public interface IPixelRay {
		Ray Ray { get; }
		Point Position { get; }
	}
}