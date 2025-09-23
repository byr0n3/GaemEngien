using System.Diagnostics.CodeAnalysis;

namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Defines the internal formats that can be assigned to an OpenGL render buffer.
	/// </summary>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public enum RenderBufferInternalFormat
	{
		/// <summary>
		/// Represents an absence of an internal format for a render buffer.
		/// </summary>
		None = 0,

		/// <summary>
		/// Represents an 8‑bit per component RGB internal format for an OpenGL render buffer.
		/// This format stores red, green, and blue components, each 8 bits, without an alpha channel.
		/// </summary>
		RGB8 = 0x8051,

		/// <summary>
		/// Represents an 8‑bit render buffer format with four 4‑bit channels (red, green, blue, and alpha).
		/// This internal format packs each component into 4 bits, providing a total of 16 bits per pixel.
		/// It is useful for low‑memory or performance‑sensitive contexts where full 8‑bit precision is unnecessary.
		/// </summary>
		RGBA4 = 0x8056,

		/// <summary>
		/// Represents a 16‑bit internal format with 5 bits each for red, green, and blue, and a single alpha bit.
		/// </summary>
		RGB5_A1 = 0x8057,

		/// <summary>
		/// Represents an 8‑bit per channel RGBA internal format for an OpenGL render buffer,
		/// providing full color and alpha information.
		/// </summary>
		RGBA8 = 0x8058,

		/// <summary>
		/// Represents an internal format for a render buffer that allocates 10 bits for each of the
		/// red, green, and blue channels, and 2 bits for the alpha channel.
		/// This format is used to achieve high‑color precision in rendering operations while providing a compact representation of the alpha component.
		/// </summary>
		RGB10_A2 = 0x8059,

		/// <summary>
		/// Represents a 16‑bit depth component internal format for a render buffer.
		/// This format stores a depth value using 16 bits and does not include a stencil component.
		/// </summary>
		DepthComponent16 = 0x81A5,

		/// <summary>
		/// Specifies a 24‑bit depth component internal format for an OpenGL render buffer.
		/// </summary>
		DepthComponent24 = 0x81A6,

		/// <summary>
		/// Represents a single 8‑bit component internal format (R8) for a render buffer.
		/// Stores one red component per pixel with 8 bits of precision, typically used for
		/// single‑channel data such as luminance or alpha.
		/// </summary>
		R8 = 0x8229,

		/// <summary>
		/// Represents a two-component render buffer format where each component
		/// (red and green) is stored with 8 bits of precision.
		/// </summary>
		RG8 = 0x822B,

		/// <summary>
		/// Represents a single‑component render buffer format that stores data in an 8‑bit signed integer.
		/// This format is suitable for rendering operations that need signed integer precision,
		/// such as certain types of depth or stencil processing.
		/// </summary>
		R8I = 0x8231,

		/// <summary>
		/// Represents a render buffer format that stores an 8‑bit unsigned integer in the red channel.
		/// This single‑channel integer format is suitable for applications that require discrete integer values,
		/// such as depth or stencil data, and allows values in the range 0–255.
		/// </summary>
		R8UI = 0x8232,

		/// <summary>
		/// Specifies a 16‑bit signed integer format for the red channel of a render buffer.
		/// This format stores signed integer values, enabling integer arithmetic and filtering on the
		/// single red component.
		/// </summary>
		R16I = 0x8233,

		/// <summary>
		/// Represents a render buffer internal format with a single 16‑bit unsigned integer
		/// channel for the red component.
		/// </summary>
		R16UI = 0x8234,

		/// <summary>
		/// Represents a 32‑bit signed integer internal format for a single
		/// component in a render buffer. This format permits integer
		/// values to be written to the buffer and accessed by shaders
		/// that support integer sampling.
		/// </summary>
		R32I = 0x8235,

		/// <summary>
		/// Represents a 32‑bit unsigned integer single‑channel render buffer internal format.
		/// </summary>
		R32UI = 0x8236,

		/// <summary>
		/// Represents a two‑component, 8‑bit signed integer format (Red and Green channels) for a render buffer.
		/// This internal format stores signed integer values for each component, which can be used for integer‑based
		/// rendering operations such as depth or stencil data.
		/// </summary>
		RG8I = 0x8237,

		/// <summary>
		/// Represents a render buffer internal format with an unsigned 8‑bit red and green component.
		/// </summary>
		RG8UI = 0x8238,

		/// <summary>
		/// Specifies a 16‑bit signed integer format for two color components (Red and Green).
		/// This format is used for render buffers that require high‑precision signed integer data per channel.
		/// </summary>
		RG16I = 0x8239,

		/// <summary>
		/// Represents an RG16UI render buffer internal format, storing two 16‑bit unsigned integer components.
		/// </summary>
		RG16UI = 0x823A,

		/// <summary>
		/// Represents a two‑component signed 32‑bit integer render buffer format (RGBA32I).
		/// Each texel contains a 32‑bit signed integer in the red and green channels,
		/// with the blue and alpha channels undefined.
		/// This format is commonly used for high‑precision integer data such as
		/// signed displacement fields, height maps, or compute‑shader outputs that require full 32‑bit integer precision.
		/// </summary>
		RG32I = 0x823B,

		/// <summary>
		/// Represents a render buffer format that stores two 32‑bit unsigned integer components (red and green).
		/// This format is suitable for high‑precision integer storage in render buffers where both R and G channels require 32‑bit unsigned integer values.
		/// </summary>
		RG32UI = 0x823C,

		/// <summary>
		/// Represents a render buffer format that stores a 24‑bit depth component alongside an 8‑bit stencil component.
		/// </summary>
		Depth24Stencil8 = 0x88F0,

		/// <summary>
		/// Represents an 8‑bit per channel sRGB color format with an 8‑bit alpha channel for render buffers.
		/// </summary>
		SRGB8Alpha8 = 0x8C43,

		/// <summary>
		/// Specifies a 32‑bit floating‑point depth component render buffer format.
		/// This format offers higher depth precision than the 16‑bit and 24‑bit depth components,
		/// making it suitable for scenes that demand fine depth resolution.
		/// </summary>
		DepthComponent32F = 0x8CAC,

		/// <summary>
		/// Represents a 32‑bit floating‑point depth component combined with an 8‑bit stencil component for a render buffer.
		/// </summary>
		Depth32FStencil8 = 0x8CAD,

		/// <summary>
		/// Specifies an 8‑bit stencil index format for a render buffer.
		/// This format is used for stencil attachments in depth‑stencil render buffer objects.
		/// </summary>
		StencilIndex8 = 0x8D48,

		/// <summary>
		/// Represents a 16‑bit RGB format with 5 bits for red, 6 bits for green,
		/// and 5 bits for blue, used as a render‑buffer internal format.
		/// </summary>
		RGB565 = 0x8D62,

		/// <summary>
		/// Represents a render buffer format with four 32‑bit unsigned integer channels (red, green, blue, and alpha).
		/// This format is suitable for storing high‑precision integer data in rendering operations.
		/// </summary>
		RGBA32UI = 0x8D70,

		/// <summary>
		/// Represents a render buffer internal format that stores color data using four 16‑bit unsigned integer components
		/// (red, green, blue, and alpha).
		/// This format offers higher integer precision per channel than standard 8‑bit per channel formats,
		/// making it suitable for applications that require precise integer color values,
		/// such as HDR rendering or image processing pipelines that benefit from increased bit depth.
		/// </summary>
		RGBA16UI = 0x8D76,

		/// <summary>
		/// Represents an 8‑bit unsigned integer format for each of the red, green, blue, and alpha components in a render buffer.
		/// </summary>
		RGBA8UI = 0x8D7C,

		/// <summary>
		/// Represents a render buffer with 32‑bit signed integer components for red, green, blue, and alpha.
		/// </summary>
		RGBA32I = 0x8D82,

		/// <summary>
		/// Indicates a render‑buffer internal format using four 16‑bit signed integer components (red, green, blue, alpha).
		/// </summary>
		RGBA16I = 0x8D88,

		/// <summary>
		/// Represents a render buffer internal format with 8‑bit signed integer components for red, green, blue, and alpha.
		/// </summary>
		RGBA8I = 0x8D8E,

		/// <summary>
		/// Specifies a render buffer internal format that uses 10 bits for each of the
		/// red, green, and blue channels and 2 bits for the alpha channel, storing the values as unsigned integers.
		/// </summary>
		RGB10_A2UI = 0x906F,
	}
}
