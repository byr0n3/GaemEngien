namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Enumeration representing OpenGL pixel storage parameters.
	/// </summary>
	public enum PixelStoreParameter
	{
		/// <summary>
		/// Represents a default or invalid pixel storage parameter.
		/// </summary>
		None = 0,

		/// <summary>
		/// Specifies the number of components in a row when reading pixel data from an OpenGL texture.
		/// </summary>
		UnpackRowLength = 0x0CF2,

		/// <summary>
		/// Specifies the number of rows to skip when unpacking pixel data.
		/// </summary>
		UnpackSkipRows = 0x0CF3,

		/// <summary>
		/// Specifies the number of pixel components to skip between the start of each row.
		/// </summary>
		UnpackSkipPixels = 0x0CF4,

		/// <summary>
		/// Specifies the byte alignment for unpacking pixel data from memory.
		/// </summary>
		UnpackAlignment = 0x0CF5,

		/// <summary>
		/// Specifies the number of pixels that can be packed into a row.
		/// </summary>
		PackRowLength = 0x0D02,

		/// <summary>
		/// Specifies the number of rows to skip between consecutive reads from a packed pixel image.
		/// </summary>
		PackSkipRows = 0x0D03,

		/// <summary>
		/// Specifies the number of pixel values to skip between consecutive packed pixels.
		/// </summary>
		PackSkipPixels = 0x0D04,

		/// <summary>
		/// Specifies the alignment requirement for the start of each row in memory, measured in bytes.
		/// </summary>
		PackAlignment = 0x0D05,

		/// <summary>
		/// Specifies the number of images to skip when reading from an image array.
		/// </summary>
		UnpackSkipImages = 0x806D,

		/// <summary>
		/// Specifies the number of rows to skip when unpacking an image in OpenGL.
		/// </summary>
		UnpackImageHeight = 0x806E,
	}
}
