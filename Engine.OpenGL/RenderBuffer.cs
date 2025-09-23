using Engine.OpenGL.Enums;
using JetBrains.Annotations;

namespace Engine.OpenGL
{
	/// <summary>
	/// Represents an OpenGL render buffer object.
	/// </summary>
	[MustDisposeResource]
	public readonly struct RenderBuffer : System.IDisposable, System.IEquatable<RenderBuffer>
	{
		private readonly uint id;

		/// <inheritdoc cref="RenderBuffer"/>
		public RenderBuffer() =>
			this.id = GL.GenRenderBuffer();

		/// <summary>
		/// Binds the current <see cref="RenderBuffer"/> to the specified target.
		/// </summary>
		public void Bind() =>
			GL.BindRenderBuffer(this);

		/// <summary>
		/// Releases the unmanaged resources used by this instance and optionally disposes of the managed resources.
		/// </summary>
		public unsafe void Dispose()
		{
			fixed (uint* ptr = &this.id)
			{
				GL.DeleteRenderBuffers(1, ptr);
			}
		}

		/// <summary>
		/// Determines whether the specified framebuffer is equal to this instance.
		/// </summary>
		/// <param name="other">The framebuffer to compare with this instance.</param>
		/// <returns>
		/// <see langword="true"/> if the specified framebuffer has the same ID as this instance; otherwise, <see langword="false"/>.
		/// </returns>
		public bool Equals(RenderBuffer other) =>
			this.id == other.id;

		/// <summary>
		/// Determines whether the specified object is equal to this instance.
		/// </summary>
		/// <param name="object">The object to compare with this instance.</param>
		/// <returns>
		/// <see langword="true"/> if the specified object is a <see cref="RenderBuffer"/> and has the same ID as this instance; otherwise, <see langword="false"/>.
		/// </returns>
		public override bool Equals(object? @object) =>
			(@object is RenderBuffer other) && this.Equals(other);

		/// <summary>
		/// Serves as a hash function for the current <see cref="RenderBuffer"/>.
		/// </summary>
		/// <returns>The OpenGL ID of this instance, cast to an integer.</returns>
		public override int GetHashCode() =>
			(int)this.id;

		/// <summary>
		/// Determines whether two specified framebuffers are not equal.
		/// </summary>
		/// <param name="left">The first framebuffer to compare.</param>
		/// <param name="right">The second framebuffer to compare.</param>
		/// <returns><see langword="true"/> if the specified framebuffers are not equal; otherwise, <see langword="false"/>.</returns>
		public static bool operator ==(RenderBuffer left, RenderBuffer right) =>
			left.Equals(right);

		/// <summary>
		/// Determines whether two specified framebuffers are not equal.
		/// </summary>
		/// <param name="left">The first framebuffer to compare.</param>
		/// <param name="right">The second framebuffer to compare.</param>
		/// <returns><see langword="true"/> if the specified framebuffers are not equal; otherwise, <see langword="false"/>.</returns>
		public static bool operator !=(RenderBuffer left, RenderBuffer right) =>
			!left.Equals(right);

		/// <summary>
		/// Implicitly converts a <see cref="RenderBuffer"/> to its underlying OpenGL ID (uint).
		/// </summary>
		/// <param name="this">The framebuffer object to convert.</param>
		/// <returns>The OpenGL ID of the framebuffer object.</returns>
		public static implicit operator uint(RenderBuffer @this) =>
			@this.id;

		/// <summary>
		/// Specifies the data storage format, width, and height for a render buffer.
		/// </summary>
		/// <param name="internalFormat">The internal format of the render buffer.</param>
		/// <param name="width">The width of the render buffer.</param>
		/// <param name="height">The height of the render buffer.</param>
		public static void Storage(RenderBufferInternalFormat internalFormat, int width, int height) =>
			GL.RenderBufferStorage(internalFormat, width, height);

		/// <summary>
		/// Allocates storage for a multisample renderbuffer.
		/// </summary>
		/// <param name="samples">The number of samples per pixel.</param>
		/// <param name="internalFormat">The internal format to use for the renderbuffer.</param>
		/// <param name="width">The width of the renderbuffer in pixels.</param>
		/// <param name="height">The height of the renderbuffer in pixels.</param>
		public static void StorageMultisample(int samples, RenderBufferInternalFormat internalFormat, int width, int height) =>
			GL.RenderbufferStorageMultisample(samples, internalFormat, width, height);
	}
}
