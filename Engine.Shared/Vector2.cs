using System.Runtime.InteropServices;

namespace Engine.Shared
{
	/// <summary>
	/// Represents a two-dimensional vector with generic value type.
	/// </summary>
	/// <typeparam name="TValue">The type of the vector components. Must be unmanaged.</typeparam>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Vector2<TValue>
		where TValue : unmanaged
	{
		/// <summary>
		/// Gets the X component of this vector.
		/// </summary>
		public readonly TValue X;

		/// <summary>
		/// Gets the Y component of this vector.
		/// </summary>
		public readonly TValue Y;

		/// <inheritdoc cref="Vector2{TValue}"/>
		/// <param name="value">The value to initialize the vector with.</param>
		public Vector2(TValue value) : this(value, value)
		{
		}

		/// <inheritdoc cref="Vector2{TValue}"/>
		/// <param name="x">The X component of the vector.</param>
		/// <param name="y">The Y component of the vector.</param>
		public Vector2(TValue x, TValue y)
		{
			this.X = x;
			this.Y = y;
		}
	}
}
