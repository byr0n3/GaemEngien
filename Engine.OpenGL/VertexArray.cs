using Engine.OpenGL.Enums;
using Engine.Shared;
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

		/// <summary>
		/// Enables the vertex attribute array at the specified index.
		/// </summary>
		/// <param name="index">The index of the vertex attribute to enable.</param>
		public static void EnableAttribute(uint index) =>
			GL.EnableVertexAttribArray(index);

		/// <summary>
		/// Defines the format and location of vertex attribute data for a shader program.
		/// </summary>
		/// <param name="index">The index of the generic vertex attribute to modify.</param>
		/// <param name="size">The number of components per vertex attribute (e.g., 2 for a vec2).</param>
		/// <param name="type">The data type of each component in the attribute array.</param>
		/// <param name="stride">The byte offset between consecutive vertex attributes.</param>
		public static unsafe void AttributePointer(uint index, int size, VertexDataType type, int stride) =>
			GL.VertexAttribPointer(index, size, type, false, stride, null);

		/// <summary>
		/// Defines a generic vertex attribute array by specifying the attribute index, size, data type, stride, and pointer to the data.
		/// </summary>
		/// <param name="index">The index of the generic vertex attribute to be modified.</param>
		/// <param name="size">The number of components per vertex attribute (must be 1, 2, 3, or 4).</param>
		/// <param name="type">The data type of each component.</param>
		/// <param name="stride">The byte offset between consecutive vertex attributes.</param>
		/// <param name="pointer">A pointer to the first component of the first vertex attribute.</param>
		/// <typeparam name="TValue">The unmanaged type that represents the vertex attribute data.</typeparam>
		/// <remarks>
		/// This method calls <c>GL.VertexAttribPointer</c> with the <c>normalized</c> flag set to <c>false</c>.
		/// </remarks>
		public static unsafe void AttributePointer<TValue>(uint index, int size, VertexDataType type, int stride, Pointer<TValue> pointer)
			where TValue : unmanaged =>
			GL.VertexAttribPointer(index, size, type, false, stride, pointer);
	}
}
