namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Specifies the data type of texture data.
	/// </summary>
	public enum TextureType
	{
		/// <summary>
		/// Represents a value indicating no texture type is specified.
		/// </summary>
		None,

		/// <summary>
		/// Represents a value indicating the texture data type is unsigned byte.
		/// </summary>
		Byte = 0x1400,

		/// <summary>
		/// Represents a value indicating the texture data type is unsigned byte.
		/// </summary>
		UnsignedByte = 0x1401,

		/// <summary>
		/// Represents a value indicating the texture data type is 16-bit integer.
		/// </summary>
		Short = 0x1402,

		/// <summary>
		/// Represents a value indicating the texture data type is an unsigned short.
		/// </summary>
		UnsignedShort = 0x1403,

		/// <summary>
		/// Represents a value indicating the texture data type is an integer.
		/// </summary>
		Integer = 0x1404,

		/// <summary>
		/// Specifies the data type of texture data as an unsigned integer.
		/// </summary>
		UnsignedInteger = 0x1405,

		/// <summary>
		/// Specifies the data type of texture data as floating-point numbers.
		/// </summary>
		Float = 0x1406,

		/// <summary>
		/// Represents a value indicating the texture type is half-float.
		/// </summary>
		HalfFloat = 0x140B,

		/// <summary>
		/// Represents a texture type with an unsigned integer format
		/// consisting of one 32-bit value composed of three 10-bit integers and one 2-bit integer.
		/// </summary>
		Int_2_10_10_10_Rev = 0x8D9F,
	}
}
