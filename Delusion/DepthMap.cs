using System.Drawing;

namespace Delusion {
	public class DepthMap {
		private readonly float?[,] _depths;
		public DepthMap(Size resolution) {
			_depths = new float?[resolution.Width, resolution.Height];
		}

		public int Width => _depths.GetLength(0);
		public int Height => _depths.GetLength(1);
		public Size Resolution => new Size(Width, Height);

		public float? this[int x, int y] {
			get => _depths[x, y];
			set => _depths[x, y] = value;
		}
	}
}