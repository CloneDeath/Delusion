namespace Delusion.Collision {
	public interface IRenderable {
		IIntersectionInformation CalculateIntersection(Ray line);
	}
}