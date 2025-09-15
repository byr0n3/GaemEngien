namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Specifies the data type of each component in a vertex attribute.
	/// </summary>
	public enum VertexDataType
	{
		/// <summary>
		/// Specifies that no data type is set for the vertex attribute.
		/// </summary>
		None,

		/// <summary>
		/// Specifies that the data type of each component in a vertex attribute is 8-bit signed integer.
		/// </summary>
		/// <remarks>This would translate to a <see cref="sbyte"/>.</remarks>
		Byte = 0x1400,

		/// <summary>
		/// Specifies that the data type of each component in a vertex attribute is 8-bit unsigned integer.
		/// </summary>
		/// <remarks>This would translate to a <see cref="byte"/>.</remarks>
		UnsignedByte = 0x1401,

		/// <summary>
		/// Specifies that the data type of each component in a vertex attribute is a 16-bit signed integer.
		/// </summary>
		/// <remarks>This would translate to a <see cref="short"/>.</remarks>
		Short = 0x1402,

		/// <summary>
		/// Specifies that the data type of each component in a vertex attribute is a 16-bit unsigned integer.
		/// </summary>
		/// <remarks>This would translate to a <see cref="ushort"/>.</remarks>
		UnsignedShort = 0x1403,

		/// <summary>
		/// Specifies that the data type of each component in a vertex attribute is a 32-bit signed integer.
		/// </summary>
		/// <remarks>This would translate to a <see cref="int"/>.</remarks>
		Int = 0x1404,

		/// <summary>
		/// Specifies that the data type of each component in a vertex attribute is a 32-bit unsigned integer.
		/// </summary>
		/// <remarks>This would translate to a <see cref="uint"/>.</remarks>
		UnsignedInt = 0x1405,

		/// <summary>
		/// Specifies that the data type for each component in a vertex attribute is a floating-point number.
		/// </summary>
		/// <remarks>This would translate to a <see cref="float"/>.</remarks>
		Float = 0x1406,

		/// <summary>
		/// Specifies that the data type of each component in a vertex attribute is a double-precision floating-point number.
		/// </summary>
		/// /// <remarks>This would translate to a <see cref="decimal"/>.</remarks>
		Double = 0x140A,

		/// <summary>
		/// Specifies that the data type for each component in a vertex attribute is a 16-bit half-precision floating-point number.
		/// </summary>
		HalfFloat = 0x140B,

		/// <summary>
		/// Specifies that the data type for each component in a vertex attribute is fixed-point.
		/// </summary>
		Fixed = 0x140C,

		/// <summary>
		/// Specifies a vertex attribute data type of unsigned integer with individual components of
		/// 2-bit for red, 10-bits each for green and blue, and 10-bits for alpha in reversed order.
		/// </summary>
		UnsignedInt_2_10_10_10_Rev = 0x8368,

		/// <summary>
		/// Specifies a 10-bit integer type with two bits for the sign and ten bits each for
		/// red, green, blue, and alpha components in reverse order.
		/// </summary>
		Int_2_10_10_10_Rev = 0x8D9F,
	}
}
