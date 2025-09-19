using System.Diagnostics;
using System.Numerics;
using System.Text;
using Engine.OpenGL.Enums;
using glfw;
using JetBrains.Annotations;

namespace Engine.OpenGL
{
	/// <summary>
	/// Represents an OpenGL program, which is a combination of shaders that can be used to render objects.
	/// </summary>
	[MustDisposeResource]
	public readonly struct Program : System.IEquatable<Program>, System.IDisposable
	{
		private readonly uint id;

		/// <inheritdoc cref="Program"/>
		public Program() =>
			this.id = GL.CreateProgram();

		/// <summary>
		/// Attaches the specified shader to the program.
		/// </summary>
		/// <param name="shader">The shader object to attach.</param>
		public void AttachShader(Shader shader) =>
			GL.AttachShader(this, shader);

		/// <summary>
		/// Attaches the specified shaders to the program.
		/// </summary>
		/// <param name="shaders">The span of shaders objects to attach.</param>
		public void AttachShaders(scoped System.ReadOnlySpan<Shader> shaders)
		{
			foreach (var shader in shaders)
			{
				GL.AttachShader(this, shader);
			}
		}

		/// <summary>
		/// Links the attached shaders to the program.
		/// </summary>
		public void Link() =>
			GL.LinkProgram(this);

		/// <summary>
		/// Sets the current active program object to this instance.
		/// If the link status of the program is not successful, writes the error log to the console in debug mode.
		/// </summary>
		public void Use()
		{
			GL.UseProgram(this);

			var success = GL.GetProgramIv(this, ProgramIvParameter.LinkStatus);

			if (success == 0)
			{
				WriteProgramLog(this);
			}

			return;

			[Conditional("DEBUG")]
			static void WriteProgramLog(Program @this)
			{
				System.Span<byte> buffer = stackalloc byte[512];

				var length = GL.GetProgramInfoLog(@this, buffer);

				var log = Encoding.UTF8.GetString(buffer.Slice(0, length));

				System.Console.Error.WriteLine("Error using program:");
				System.Console.Error.WriteLine(log);
			}
		}

		// @todo Cache
		/// <summary>
		/// Gets the location of a uniform variable in the program object.
		/// </summary>
		/// <param name="name">The name of the uniform variable.</param>
		/// <returns>
		/// The location of the specified uniform variable within the program object.
		/// If the named uniform variable is not an active uniform, returns -1.
		/// </returns>
		public int GetUniformLocation(NativeString name) =>
			GL.GetUniformLocation(this, name);

		/// <summary>
		/// Sets the value of a uniform variable with one integer component.
		/// </summary>
		/// <param name="name">The name of the uniform variable.</param>
		/// <param name="value">The integer value to set.</param>
		public void SetUniform1I(NativeString name, int value) =>
			GL.Uniform1I(this.GetUniformLocation(name), value);

		/// <summary>
		/// Sets a uniform variable of type float vec3.
		/// </summary>
		/// <param name="name">The name of the uniform variable.</param>
		/// <param name="value">The value to set for the uniform variable.</param>
		public void SetUniform3F(NativeString name, Vector3 value) =>
			this.SetUniform3F(name, value.X, value.Y, value.Z);

		/// <summary>
		/// Sets a uniform variable of type vec3 in the program object.
		/// </summary>
		/// <param name="name">The name of the uniform variable.</param>
		/// <param name="x">The x component of the vector.</param>
		/// <param name="y">The y component of the vector.</param>
		/// <param name="z">The z component of the vector.</param>
		public void SetUniform3F(NativeString name, float x, float y, float z) =>
			GL.Uniform3F(this.GetUniformLocation(name), x, y, z);

		/// <summary>
		/// Sets a uniform variable in the shader program to a 4-component vector.
		/// </summary>
		/// <param name="name">The name of the uniform variable.</param>
		/// <param name="value">The value to set the uniform variable to.</param>
		public void SetUniform4F(NativeString name, Vector4 value) =>
			this.SetUniform4F(name, value.X, value.Y, value.Z, value.W);

		/// <summary>
		/// Sets the value of a uniform variable located in the program object.
		/// </summary>
		/// <param name="name">The name of the uniform variable.</param>
		/// <param name="x">The x component of the 4D vector.</param>
		/// <param name="y">The y component of the 4D vector.</param>
		/// <param name="z">The z component of the 4D vector.</param>
		/// <param name="w">The w component of the 4D vector.</param>
		public void SetUniform4F(NativeString name, float x, float y, float z, float w) =>
			GL.Uniform4F(this.GetUniformLocation(name), x, y, z, w);

		public unsafe void SetUniformMatrix4Fv(NativeString name, bool transpose, Matrix4x4 value) =>
			GL.UniformMatrix4Fv(this.GetUniformLocation(name), 1, transpose, &value.M11);

		/// <summary>
		/// Disposes the OpenGL program by deleting it.
		/// </summary>
		public void Dispose() =>
			GL.DeleteProgram(this.id);

		/// <summary>
		/// Determines whether the current instance is equal to another specified <see cref="Program"/> object.
		/// </summary>
		/// <param name="other">The other <see cref="Program"/> object to compare with the current instance.</param>
		/// <returns>
		/// <see langword="true"/> if the current instance and the other <see cref="Program"/> object have the same ID; otherwise, <see langword="false"/>.
		/// </returns>
		public bool Equals(Program other) =>
			this.id == other.id;

		/// <summary>
		/// Determines whether the specified object is equal to the current instance.
		/// </summary>
		/// <param name="object">The object to compare with the current instance.</param>
		/// <returns>
		/// <see langword="true"/> if the specified object is equal to the current instance; otherwise, <see langword="false"/>.
		/// </returns>
		public override bool Equals(object? @object) =>
			(@object is Program other) && this.Equals(other);

		/// <summary>
		/// Serves as a hash function for the <see cref="Program"/> type.
		/// </summary>
		/// <returns>The hash code for this instance, which is based on the underlying OpenGL program ID.</returns>
		public override int GetHashCode() =>
			(int)this.id;

		/// <summary>
		/// Compares two instances of <see cref="Program"/> for equality based on their IDs.
		/// </summary>
		/// <param name="left">The first instance to compare.</param>
		/// <param name="right">The second instance to compare.</param>
		/// <returns><see langword="true"/> if the IDs are equal; otherwise, <see langword="false"/>.</returns>
		public static bool operator ==(Program left, Program right) =>
			left.Equals(right);

		/// <summary>
		/// Compares two instances of <see cref="Program"/> for inequality based on their IDs.
		/// </summary>
		/// <param name="left">The first instance to compare.</param>
		/// <param name="right">The second instance to compare.</param>
		/// <returns><see langword="true"/> if the IDs are not equal; otherwise, <see langword="false"/>.</returns>
		public static bool operator !=(Program left, Program right) =>
			!left.Equals(right);

		/// <summary>
		/// Implicitly converts a <see cref="Program"/> to its underlying OpenGL ID (uint).
		/// </summary>
		/// <param name="this">The program object to convert.</param>
		/// <returns>The OpenGL ID of the program object.</returns>
		public static implicit operator uint(Program @this) =>
			@this.id;
	}
}
