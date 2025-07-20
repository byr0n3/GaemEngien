using System.IO;
using Engine.Enums;
using Engine.Internal;
using JetBrains.Annotations;
using wgpu;
using wgpu.Enums;
using wgpu.Structs;

namespace Engine
{
	/// <summary>
	/// Provides methods for loading and managing shader modules.
	/// </summary>
	public static class Shaders
	{
		/// <summary>
		/// Load a shader module from a file.
		/// </summary>
		/// <param name="device">The device to create the shader module on.</param>
		/// <param name="filePath">The path to the shader file.</param>
		/// <param name="shaderType">The type of the shader.</param>
		/// <param name="label">An optional label for the shader module. Default is an empty <see cref="StringView"/>.</param>
		/// <returns>A new <see cref="ShaderModule"/> instance created from the file.</returns>
		/// <exception cref="System.ArgumentException">Thrown when the file is too large or the shader type is unsupported.</exception>
		[MustDisposeResource]
		public static ShaderModule LoadFromFile(Device device, string filePath, ShaderType shaderType, StringView label = default)
		{
			var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

			// Max. of 10 mb files for now.
			if (stream.Length >= 1024 * 1024 * 10)
			{
				// @todo Support
				throw new System.ArgumentException("File is too large. Max is 10mb.", nameof(filePath));
			}

			var buffer = new RentedArray<byte>((int)stream.Length);

			using (buffer)
			{
				var read = stream.Read(buffer);

				var source = (shaderType) switch
				{
					ShaderType.WGSL => new ShaderSourceWGSL
					{
						Chain = new ChainedStruct(SType.ShaderSourceWGSL),
						Code = new System.ReadOnlySpan<byte>(buffer, 0, read),
					},

					_ => throw new System.ArgumentException("Unsupported shader type.", nameof(shaderType)),
				};

				return device.CreateShaderModule(new BasicDescriptor
				{
					NextInChain = source,
					Label = label,
				});
			}
		}
	}
}
