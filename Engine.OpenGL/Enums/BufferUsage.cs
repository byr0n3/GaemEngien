namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Defines the usage pattern of a buffer object.
	/// </summary>
	public enum BufferUsage
	{
		/// <summary>
		/// Indicates that no specific usage pattern is set for the buffer object.
		/// </summary>
		None,

		/// <summary>
		/// Specifies that the data store contents will be modified repeatedly and used at most a few times.
		/// </summary>
		StreamDraw = 0x88E0,

		/// <summary>
		/// Indicates that the buffer object is intended to be used for reading data in a stream pattern.
		/// This suggests frequent updates and transfers of data.
		/// </summary>
		StreamRead = 0x88E1,

		/// <summary>
		/// Indicates that the buffer object is intended for use with copying data between buffers.
		/// </summary>
		StreamCopy = 0x88E2,

		/// <summary>
		/// Specifies that the data store contents will be modified once and used at most a few times.
		/// </summary>
		StaticDraw = 0x88E4,

		/// <summary>
		/// Specifies that the buffer is intended for read operations where the data will be updated infrequently.
		/// </summary>
		StaticRead = 0x88E5,

		/// <summary>
		/// Specifies that the data store contents will be modified once and used multiple times as a copy source.
		/// </summary>
		StaticCopy = 0x88E6,

		/// <summary>
		/// Indicates that the buffer data will be modified frequently and used as the source for drawing operations.
		/// </summary>
		DynamicDraw = 0x88E8,

		/// <summary>
		/// Indicates that the buffer object is intended for dynamic reading.
		/// </summary>
		DynamicRead = 0x88E9,

		/// <summary>
		/// Indicates that the buffer object is intended for dynamic copying operations.
		/// </summary>
		DynamicCopy = 0x88EA,
	}
}
