using System.Diagnostics;
using System.Text;
using Engine.OpenGL.Enums;
using glfw;
using JetBrains.Annotations;

namespace Engine.OpenGL
{
	/// <summary>
	/// Represents an OpenGL shader object.
	/// </summary>
	[MustDisposeResource]
	public readonly struct Shader : System.IEquatable<Shader>, System.IDisposable
	{
		private readonly uint id;

		/// <inheritdoc cref="Shader"/>
		[System.Obsolete("Use the constructor with the ShaderType parameter", true)]
		public Shader()
		{
		}

		/// <inheritdoc cref="Shader"/>
		/// <param name="type">The type of shader to create.</param>
		public Shader(ShaderType type) =>
			this.id = GL.CreateShader(type);

		/// <summary>
		/// Sets the source code of the shader.
		/// </summary>
		/// <param name="source">The source code as a C level string.</param>
		public unsafe void SetSource(NativeString source) =>
			GL.ShaderSource(this, 1, &source, null);

		/// <summary>
		/// Compiles the shader.
		/// </summary>
		public void Compile()
		{
			GL.CompileShader(this);

			var success = GL.GetShaderIv(this, ShaderIvParameter.CompileStatus);

			if (success == 0)
			{
				WriteShaderLog(this);
			}

			return;

			[Conditional("DEBUG")]
			static void WriteShaderLog(Shader @this)
			{
				System.Span<byte> buffer = stackalloc byte[512];

				var length = GL.GetShaderInfoLog(@this, buffer);

				var log = Encoding.UTF8.GetString(buffer.Slice(0, length));

				System.Console.Error.WriteLine("Error compiling shader:");
				System.Console.Error.WriteLine(log);
			}
		}

		/// <summary>
		/// Disposes the shader by deleting it.
		/// </summary>
		public void Dispose() =>
			GL.DeleteShader(this);

		/// <summary>
		/// Determines whether the specified shader is equal to the current shader.
		/// </summary>
		/// <param name="other">The shader to compare with the current shader.</param>
		/// <returns>
		/// <see langword="true"/> if the specified shader is equal to the current shader; otherwise, <see langword="false"/>
		/// </returns>
		public bool Equals(Shader other) =>
			this.id == other.id;

		/// <summary>
		/// Determines whether the specified object is equal to the current shader.
		/// </summary>
		/// <param name="object">The object to compare with the current shader.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current shader; otherwise, <see langword="false"/></returns>
		public override bool Equals(object? @object) =>
			(@object is Shader other) && this.Equals(other);

		/// <summary>
		/// Returns a hash code for this shader.
		/// </summary>
		/// <returns>The integer hash code.</returns>
		public override int GetHashCode() =>
			(int)this.id;

		/// <summary>
		/// Determines whether two shader objects are equal.
		/// </summary>
		/// <param name="left">The first shader to compare.</param>
		/// <param name="right">The second shader to compare.</param>
		/// <returns><see langword="true" /> if the shaders are equal; otherwise, <see langword="false" />.</returns>
		public static bool operator ==(Shader left, Shader right) =>
			left.Equals(right);

		/// <summary>
		/// Determines whether two shader objects are not equal.
		/// </summary>
		/// <param name="left">The first shader to compare.</param>
		/// <param name="right">The second shader to compare.</param>
		/// <returns><see langword="true" /> if the shaders are not equal; otherwise, <see langword="false" />.</returns>
		public static bool operator !=(Shader left, Shader right) =>
			!left.Equals(right);

		/// <summary>
		/// Implicitly converts a <see cref="Shader"/> to its underlying OpenGL ID (uint).
		/// </summary>
		/// <param name="this">The shader object to convert.</param>
		/// <returns>The OpenGL ID of the shader object.</returns>
		public static implicit operator uint(Shader @this) =>
			@this.id;
	}
}
