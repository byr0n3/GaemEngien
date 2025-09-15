using JetBrains.Annotations;

namespace Engine.OpenGL
{
	/// <summary>
	/// Represents a vertex array object (VAO) in OpenGL.
	/// A VAO stores the configuration state of vertex attributes and buffer objects so that the setup can be re-used when rendering.
	/// This struct provides methods to create, bind, unbind, and dispose of vertex arrays.
	/// </summary>
	[MustDisposeResource]
	public readonly struct VertexArray : System.IEquatable<VertexArray>, System.IDisposable
	{
		private readonly uint id;

		/// <inheritdoc cref="VertexArray"/>
		public VertexArray() =>
			this.id = GL.GenVertexArray();

		/// <summary>
		/// Binds the current Vertex Array Object (VAO) to make it active.
		/// </summary>
		public void Bind() =>
			GL.BindVertexArray(this);

		/// <summary>
		/// Releases the resources used by this instance of Vertex Array Object (VAO).
		/// </summary>
		public unsafe void Dispose()
		{
			fixed (uint* ptr = &this.id)
			{
				GL.DeleteVertexArrays(1, ptr);
			}
		}

		/// <summary>
		/// Determines whether the current instance is equal to another instance of <see cref="VertexArray"/>.
		/// </summary>
		/// <param name="other">The other <see cref="VertexArray"/> object to compare with.</param>
		/// <returns><see langword="true"/> if the instances are equal; otherwise, <see langword="false"/>.</returns>
		public bool Equals(VertexArray other) =>
			this.id == other.id;

		/// <summary>
		/// Determines whether the current instance is equal to another object.
		/// </summary>
		/// <param name="object">The object to compare with the current instance.</param>
		/// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
		public override bool Equals(object? @object) =>
			(@object is VertexArray other) && this.Equals(other);

		/// <summary>
		/// Generates a hash code for the current Vertex Array Object (VAO).
		/// </summary>
		/// <returns>The integer representation of the VAO's ID, cast to an int.</returns>
		public override int GetHashCode() =>
			(int)this.id;

		/// <summary>
		/// Determines whether two instances of <see cref="VertexArray"/> are not equal.
		/// </summary>
		/// <param name="left">The first <see cref="VertexArray"/> object to compare.</param>
		/// <param name="right">The second <see cref="VertexArray"/> object to compare.</param>
		/// <returns><see langword="true"/> if the instances are not equal; otherwise, <see langword="false"/>.</returns>
		public static bool operator ==(VertexArray left, VertexArray right) =>
			left.Equals(right);

		/// <summary>
		/// Determines whether two instances of <see cref="VertexArray"/> are not equal.
		/// </summary>
		/// <param name="left">The first <see cref="VertexArray"/> object to compare.</param>
		/// <param name="right">The second <see cref="VertexArray"/> object to compare.</param>
		/// <returns><see langword="true"/> if the instances are not equal; otherwise, <see langword="false"/>.</returns>
		public static bool operator !=(VertexArray left, VertexArray right) =>
			!left.Equals(right);

		/// <summary>
		/// Implicitly converts a <see cref="VertexArray"/> to its underlying OpenGL ID (uint).
		/// </summary>
		/// <param name="this">The Vertex Array Object (VAO) to convert.</param>
		/// <returns>The OpenGL ID of the shader object.</returns>
		public static implicit operator uint(VertexArray @this) =>
			@this.id;

		/// <summary>
		/// Unbinds the currently bound Vertex Array Object (VAO) by binding to a default VAO.
		/// </summary>
		public static void Unbind() =>
			GL.BindVertexArray(default);
	}
}
