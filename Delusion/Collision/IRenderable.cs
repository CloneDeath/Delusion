namespace Delusion.Collision {
	public interface IRenderable {
		ITraceInformation CalculateIntersection(Ray line);
	}
}