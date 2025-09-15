using Engine.Shared;
using Engine.OpenGL.Enums;
using JetBrains.Annotations;

namespace Engine.OpenGL
{
	/// <summary>
	/// Represents an OpenGL buffer object.
	/// </summary>
	[MustDisposeResource]
	public readonly struct Buffer : System.IEquatable<Buffer>, System.IDisposable
	{
		private readonly uint id;

		/// <inheritdoc cref="Buffer"/>
		public Buffer() =>
			this.id = GL.GenBuffer();

		/// <summary>
		/// Binds the buffer to the specified target.
		/// </summary>
		/// <param name="target">The buffer target to bind to.</param>
		public void Bind(BufferTarget target) =>
			GL.BindBuffer(target, this);

		/// <summary>
		/// Disposes the buffer by deleting it.
		/// </summary>
		public unsafe void Dispose()
		{
			fixed (uint* ptr = &this.id)
			{
				GL.DeleteBuffers(1, ptr);
			}
		}

		/// <summary>
		/// Determines whether the specified buffer is equal to the current buffer.
		/// </summary>
		/// <param name="other">The buffer to compare with the current buffer.</param>
		/// <returns><see langword="true"/> if the specified buffer is equal to the current buffer; otherwise, <see langword="false"/>.</returns>
		public bool Equals(Buffer other) =>
			this.id == other.id;

		/// <summary>
		/// Determines whether the specified object is equal to the current buffer.
		/// </summary>
		/// <param name="object">The object to compare with the current buffer.</param>
		/// <returns>
		/// <see langword="true"/> if the specified object is a <see cref="Buffer"/> and its ID equals the ID of the current buffer; otherwise, <see langword="false"/>.
		/// </returns>
		public override bool Equals(object? @object) =>
			(@object is Buffer other) && this.Equals(other);

		/// <summary>
		/// Gets the hash code for this buffer, which is based on its unique ID.
		/// </summary>
		/// <returns>The hash code of this buffer.</returns>
		public override int GetHashCode() =>
			(int)this.id;

		/// <summary>
		/// Determines whether the specified buffers are equal.
		/// </summary>
		/// <param name="left">The first buffer to compare.</param>
		/// <param name="right">The second buffer to compare.</param>
		/// <returns><see langword="true"/> if the specified buffers are equal; otherwise, <see langword="false"/>.</returns>
		public static bool operator ==(Buffer left, Buffer right) =>
			left.Equals(right);

		/// <summary>
		/// Determines whether the specified buffers are not equal.
		/// </summary>
		/// <param name="left">The first buffer to compare.</param>
		/// <param name="right">The second buffer to compare.</param>
		/// <returns><see langword="true"/> if the specified buffers are not equal; otherwise, <see langword="false"/>.</returns>
		public static bool operator !=(Buffer left, Buffer right) =>
			!left.Equals(right);

		/// <summary>
		/// Implicitly converts a <see cref="Buffer"/> to its underlying OpenGL ID (uint).
		/// </summary>
		/// <param name="this">The buffer object to convert.</param>
		/// <returns>The OpenGL ID of the buffer object.</returns>
		public static implicit operator uint(Buffer @this) =>
			@this.id;

		/// <summary>
		/// Unbinds the buffer associated with the specified target.
		/// </summary>
		/// <param name="target">The target to unbind the buffer from.</param>
		public static void Unbind(BufferTarget target) =>
			GL.BindBuffer(target, default);

		/// <summary>
		/// Generates OpenGL buffer objects and stores their IDs in the provided span.
		/// </summary>
		/// <param name="buffers">A span to store the generated buffer IDs.</param>
		public static unsafe void GenerateBuffers(scoped System.ReadOnlySpan<Buffer> buffers)
		{
			fixed (void* ptr = buffers)
			{
				GL.GenBuffers(buffers.Length, (uint*)ptr);
			}
		}

		/// <summary>
		/// Copies data to a buffer object's memory.
		/// </summary>
		/// <param name="target">Specifies the target to which later buffer object operations apply. Must be either `Array`, `ElementArray` or `CopyReadBuffer`.</param>
		/// <param name="data">A span of data that will be copied into the buffer object.</param>
		/// <param name="usage">Describes how a buffer's data is accessed by an application (hint to driver).</param>
		/// <typeparam name="T">The type of elements in the data array. Must be unmanaged.</typeparam>
		public static unsafe void BufferData<T>(BufferTarget target, scoped System.ReadOnlySpan<T> data, BufferUsage usage)
			where T : unmanaged
		{
			fixed (void* ptr = data)
			{
				GL.BufferData(target, sizeof(T) * data.Length, ptr, usage);
			}
		}

		public static unsafe void BufferData(BufferTarget target, nint size, VoidPointer data, BufferUsage usage) =>
			GL.BufferData(target, size, data, usage);

		public static unsafe void BufferSubData<T>(BufferTarget target, scoped System.ReadOnlySpan<T> data, int offset = 0)
			where T : unmanaged
		{
			fixed (void* ptr = data)
			{
				GL.BufferSubData(target, offset, sizeof(T) * data.Length, ptr);
			}
		}

		public static unsafe void BufferSubData(BufferTarget target, int offset, nint size, VoidPointer data) =>
			GL.BufferSubData(target, offset, size, data);
	}
}
