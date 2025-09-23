using System.Numerics;

namespace Engine.Sample.OpenGL.Extensions
{
	internal static class VectorExtensions
	{
		extension(Vector2 value)
		{
			public Vector2 Add(float add) =>
				new(value.X + add, value.Y + add);

			public Vector2 Multiply(float multiplier) =>
				new(value.X * multiplier, value.Y * multiplier);
		}
	}
}
