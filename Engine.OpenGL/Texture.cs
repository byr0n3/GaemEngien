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

		/// <summary>
		/// Binds the current texture to the specified target.
		/// </summary>
		/// <param name="target">The target to which the texture should be bound.</param>
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

		/// <summary>
		/// Activates the specified texture unit.
		/// </summary>
		/// <param name="unit">The texture unit to activate.</param>
		public static void Active(TextureUnit unit) =>
			GL.ActiveTexture(unit);

		/// <summary>
		/// Unbinds the texture from the specified texture target.
		/// </summary>
		/// <param name="target">The texture target to unbind.</param>
		public static void Unbind(TextureTarget target) =>
			GL.BindTexture(target, default);

		// @todo Enums for values & overloads
		/// <summary>
		/// Sets a texture parameter.
		/// </summary>
		/// <param name="target">The texture target.</param>
		/// <param name="parameter">The texture parameter to set.</param>
		/// <param name="value">The value for the specified parameter.</param>
		public static void SetParameter(TextureTarget target, TextureParameter parameter, int value) =>
			GL.TextureParameteri(target, parameter, value);

		/// <summary>
		/// Creates a two-dimensional texture image.
		/// </summary>
		/// <param name="target">The target to which the texture is bound.</param>
		/// <param name="level">The level of detail. Level 0 is the base image level and m is the mth mipmap reduction level.</param>
		/// <param name="internalFormat">The format of the texture internal data.</param>
		/// <param name="width">The width of the texture in pixels.</param>
		/// <param name="height">The height of the texture in pixels.</param>
		/// <param name="format">The format of the pixel data.</param>
		/// <param name="type">The type of the pixel data.</param>
		/// <param name="data">A pointer to the image data in memory.</param>
		/// <typeparam name="T">The type of elements pointed to by the data pointer, must be unmanaged.</typeparam>
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

		/// <summary>
		/// Generates a mipmap for the specified texture target.
		/// </summary>
		/// <param name="target">
		/// The target to which the operation applies.
		/// This parameter can be one of the members of the TextureTarget enumeration.
		/// </param>
		public static void GenerateMipmap(TextureTarget target) =>
			GL.GenerateMipmap(target);
	}
}
