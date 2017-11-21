using System.Drawing;

namespace Delusion.Renderers.DataMaps {
	public class DepthMap : DataMap<float?> {
		public DepthMap(Size resolution) : base(resolution) { }
	}
}