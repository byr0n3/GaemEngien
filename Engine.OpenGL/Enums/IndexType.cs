namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Specifies the type of index used in drawing commands.
	/// </summary>
	public enum IndexType
	{
		/// <summary>
		/// Specifies that no index type is used.
		/// </summary>
		None,

		/// <summary>
		/// Specifies that the index data is of unsigned byte type (GL_UNSIGNED_BYTE / <see cref="byte"/>).
		/// </summary>
		UnsignedByte = 0x1401,

		/// <summary>
		/// Specifies that the index data is of unsigned short type (GL_UNSIGNED_SHORT / <see cref="ushort"/>).
		/// </summary>
		UnsignedShort = 0x1403,

		/// <summary>
		/// Specifies that the index data is of unsigned int type (GL_UNSIGNED_INT / <see cref="uint"/>).
		/// </summary>
		UnsignedInt = 0x1405,
	}
}
