using Engine.OpenGL.Enums;
using JetBrains.Annotations;

namespace Engine.OpenGL
{
	/// <summary>
	/// Represents an OpenGL framebuffer object.
	/// </summary>
	[MustDisposeResource]
	public readonly struct Framebuffer : System.IDisposable, System.IEquatable<Framebuffer>
	{
		private readonly uint id;

		/// <inheritdoc cref="Framebuffer"/>
		public Framebuffer() =>
			this.id = GL.GenFramebuffer();

		/// <summary>
		/// Binds the current <see cref="Framebuffer"/> to the specified target.
		/// </summary>
		/// <param name="target">The target to which this <see cref="Framebuffer"/> should be bound.</param>
		public void Bind(FramebufferTarget target) =>
			GL.BindFramebuffer(target, this);

		/// <summary>
		/// Releases the unmanaged resources used by this instance and optionally disposes of the managed resources.
		/// </summary>
		public unsafe void Dispose()
		{
			fixed (uint* ptr = &this.id)
			{
				GL.DeleteFramebuffers(1, ptr);
			}
		}

		/// <summary>
		/// Determines whether the specified framebuffer is equal to this instance.
		/// </summary>
		/// <param name="other">The framebuffer to compare with this instance.</param>
		/// <returns>
		/// <see langword="true"/> if the specified framebuffer has the same ID as this instance; otherwise, <see langword="false"/>.
		/// </returns>
		public bool Equals(Framebuffer other) =>
			this.id == other.id;

		/// <summary>
		/// Determines whether the specified object is equal to this instance.
		/// </summary>
		/// <param name="object">The object to compare with this instance.</param>
		/// <returns>
		/// <see langword="true"/> if the specified object is a <see cref="Framebuffer"/> and has the same ID as this instance; otherwise, <see langword="false"/>.
		/// </returns>
		public override bool Equals(object? @object) =>
			(@object is Framebuffer other) && this.Equals(other);

		/// <summary>
		/// Serves as a hash function for the current <see cref="Framebuffer"/>.
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
		public static bool operator ==(Framebuffer left, Framebuffer right) =>
			left.Equals(right);

		/// <summary>
		/// Determines whether two specified framebuffers are not equal.
		/// </summary>
		/// <param name="left">The first framebuffer to compare.</param>
		/// <param name="right">The second framebuffer to compare.</param>
		/// <returns><see langword="true"/> if the specified framebuffers are not equal; otherwise, <see langword="false"/>.</returns>
		public static bool operator !=(Framebuffer left, Framebuffer right) =>
			!left.Equals(right);

		/// <summary>
		/// Implicitly converts a <see cref="Framebuffer"/> to its underlying OpenGL ID (uint).
		/// </summary>
		/// <param name="this">The framebuffer object to convert.</param>
		/// <returns>The OpenGL ID of the framebuffer object.</returns>
		public static implicit operator uint(Framebuffer @this) =>
			@this.id;

		/// <summary>
		/// Binds the default framebuffer to the specified target.
		/// This makes all framebuffer operations affect the window's main output framebuffer.
		/// </summary>
		/// <param name="target">The target for binding the default framebuffer.</param>
		public static void BindDefault(FramebufferTarget target) =>
			GL.BindFramebuffer(target, default);

		/// <summary>
		/// Checks the status of a framebuffer object.
		/// </summary>
		/// <param name="target">The target to which the named buffer is bound.</param>
		/// <returns>An enumeration value indicating the completion status of the framebuffer object.</returns>
		public static FramebufferStatus CheckStatus(FramebufferTarget target) =>
			GL.CheckFramebufferStatus(target);

		/// <summary>
		/// Attaches a 2D texture to the specified framebuffer attachment point.
		/// </summary>
		/// <param name="attachment">Specifies the attachment point of the framebuffer.</param>
		/// <param name="target">Specifies the target to which the texture is bound.</param>
		/// <param name="texture">Specifies the name of a texture object.</param>
		public static void Texture2D(FramebufferTextureAttachment attachment, FramebufferTextureTarget target, uint texture) =>
			GL.FramebufferTexture2D(attachment, target, texture);

		/// <summary>
		/// Binds a render buffer to a framebuffer.
		/// </summary>
		/// <param name="target">The framebuffer target.</param>
		/// <param name="attachment">The attachment point for the render buffer.</param>
		/// <param name="renderBuffer">The ID of the render buffer object to attach.</param>
		public static void RenderBuffer(FramebufferTarget target, FramebufferRenderBufferAttachment attachment, uint renderBuffer) =>
			GL.FramebufferRenderBuffer(target, attachment, renderBuffer);
	}
}
