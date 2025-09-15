using Engine.Shared;
using Engine.OpenGL.Enums;
using JetBrains.Annotations;

namespace Engine.OpenGL
{
	/// <summary>
	/// Represents an OpenGL Texture.
	/// </summary>
	[MustDisposeResource]
	public readonly struct Texture : System.IEquatable<Texture>, System.IDisposable
	{
		private readonly uint id;

		/// <inheritdoc cref="Texture"/>
		public Texture() =>
			this.id = GL.GenTexture();

		public void Bind(TextureTarget target) =>
			GL.BindTexture(target, this);

		/// <summary>
		/// Releases the resources used by this texture.
		/// </summary>
		public void Dispose() =>
			GL.DeleteTexture(this);

		/// <summary>
		/// Determines whether the current Texture instance is equal to another specified Texture instance.
		/// </summary>
		/// <param name="other">The other Texture instance to compare with the current instance.</param>
		/// <returns>
		/// <see langword="true"/> if the current instance and the other instance have the same OpenGL ID; otherwise, <see langword="false"/>.
		/// </returns>
		public bool Equals(Texture other) =>
			this.id == other.id;

		/// <summary>
		/// Determines whether the current Texture instance is equal to another specified object.
		/// </summary>
		/// <param name="object">The other object to compare with the current instance.</param>
		/// <returns>
		/// <see langword="true"/> if the current instance and the other instance have the same OpenGL ID; otherwise, <see langword="false"/>.
		/// </returns>
		public override bool Equals(object? @object) =>
			(@object is Texture other) && this.Equals(other);

		/// <summary>
		/// Returns a hash code for the current Texture instance.
		/// </summary>
		/// <returns>The OpenGL ID of the texture as an integer.</returns>
		public override int GetHashCode() =>
			(int)this.id;

		/// <summary>
		/// Determines whether two specified <see cref="Texture"/> instances are equal.
		/// </summary>
		/// <param name="left">The first Texture instance to compare.</param>
		/// <param name="right">The second Texture instance to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the two instances have the same OpenGL ID; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator ==(Texture left, Texture right) =>
			left.Equals(right);

		/// <summary>
		/// Determines whether two specified <see cref="Texture"/> instances are not equal.
		/// </summary>
		/// <param name="left">The first Texture instance to compare.</param>
		/// <param name="right">The second Texture instance to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the two instances do not have the same OpenGL ID; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator !=(Texture left, Texture right) =>
			!left.Equals(right);

		/// <summary>
		/// Implicitly converts a <see cref="Texture"/> to its underlying OpenGL ID (uint).
		/// </summary>
		/// <param name="this">The texture object to convert.</param>
		/// <returns>The OpenGL ID of the texture object.</returns>
		public static implicit operator uint(Texture @this) =>
			@this.id;

		public static void Active(TextureUnit unit) =>
			GL.ActiveTexture(unit);

		public static void Unbind(TextureTarget target) =>
			GL.BindTexture(target, default);

		// @todo Enums for values & overloads
		public static void SetParameter(TextureTarget target, TextureParameter parameter, int value) =>
			GL.TextureParameteri(target, parameter, value);

		public static unsafe void Image2D<T>(TextureTarget target,
											 int level,
											 TextureFormat internalFormat,
											 int width,
											 int height,
											 TextureFormat format,
											 TextureType type,
											 Pointer<T> data)
			where T : unmanaged =>
			GL.TextureImage2D(target, level, internalFormat, width, height, format, type, data);

		public static void GenerateMipmap(TextureTarget target) =>
			GL.GenerateMipmap(target);
	}
}
