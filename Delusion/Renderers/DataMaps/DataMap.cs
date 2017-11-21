using System.Drawing;

namespace Delusion.Renderers.DataMaps {
	public class DataMap<T> {
		private readonly T[,] _data;
		public DataMap(Size resolution) {
			_data = new T[resolution.Width, resolution.Height];
		}
		
		public int Width => _data.GetLength(0);
		public int Height => _data.GetLength(1);
		public Size Resolution => new Size(Width, Height);

		public T this[int x, int y] {
			get => _data[x, y];
			set => _data[x, y] = value;
		}
	}
}