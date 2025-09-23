using System.IO;
using Engine.OpenGL.Enums;
using Engine.Shared;
using JetBrains.Annotations;

namespace Engine.OpenGL.Extensions
{
	/// <summary>
	/// Provides static methods for working with OpenGL shaders.
	/// </summary>
	public static class Shaders
	{
		/// <summary>
		/// Loads and compiles a shader program from vertex and fragment shader files.
		/// </summary>
		/// <param name="vertexPath">The path to the vertex shader file.</param>
		/// <param name="fragmentPath">The path to the fragment shader file.</param>
		/// <returns>A new <see cref="ShaderProgram"/> instance representing the compiled shader program.</returns>
		/// <exception cref="System.ArgumentException">
		/// Thrown if the file does not exist at the specified <paramref name="vertexPath"/> or <paramref name="fragmentPath"/>.
		/// </exception>
		[MustDisposeResource]
		public static ShaderProgram LoadFromFiles(string vertexPath, string fragmentPath)
		{
			if (!File.Exists(vertexPath))
			{
				throw new System.ArgumentException($"File doesn't exist at: {Path.GetFullPath(vertexPath)}", nameof(vertexPath));
			}

			if (!File.Exists(fragmentPath))
			{
				throw new System.ArgumentException($"File doesn't exist at: {Path.GetFullPath(fragmentPath)}", nameof(fragmentPath));
			}

			var vertexSource = Shaders.ReadFile(vertexPath, out var vertexRead);
			var fragmentSource = Shaders.ReadFile(fragmentPath, out var fragmentRead);

			var vertex = new Shader(ShaderType.Vertex);
			var fragment = new Shader(ShaderType.Fragment);

			using (vertex)
			using (fragment)
			using (vertexSource)
			using (fragmentSource)
			{
				vertex.SetSource(vertexSource.Slice(0, vertexRead));
				vertex.Compile();

				fragment.SetSource(fragmentSource.Slice(0, fragmentRead));
				fragment.Compile();

				var shaderProgram = new Engine.OpenGL.ShaderProgram();
				{
					shaderProgram.AttachShaders([vertex, fragment]);
					shaderProgram.Link();
				}

				return shaderProgram;
			}
		}

		[MustDisposeResource]
		private static RentedArray<byte> ReadFile(string filePath, out int read)
		{
			if (!File.Exists(filePath))
			{
				throw new System.ArgumentException($"File doesn't exist at: {Path.GetFullPath(filePath)}", nameof(filePath));
			}

			var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

			// Max. of 10 mb files for now.
			if (stream.Length >= 1024 * 1024 * 10)
			{
				// @todo Support
				throw new System.ArgumentException("File is too large. Max is 10mb.", nameof(filePath));
			}

			var buffer = new RentedArray<byte>((int)stream.Length);

			using (stream)
			{
				read = stream.Read(buffer);
			}

			return buffer;
		}
	}
}
