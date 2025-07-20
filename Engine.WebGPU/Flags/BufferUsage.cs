namespace wgpu.Flags
{
	/// <summary>
	/// Specifies the intended usage for a buffer.
	/// </summary>
	[System.Flags]
	public enum BufferUsage : ulong
	{
		/// <summary>
		/// Indicates that no specific usage is intended for the buffer.
		/// </summary>
		None = 0,

		/// <summary>
		/// Indicates that the buffer can be mapped for reading.
		/// </summary>
		MapRead = 1 << 0,

		/// <summary>
		/// Indicates that the buffer is intended to be mapped for writing.
		/// </summary>
		MapWrite = 1 << 1,

		/// <summary>
		/// Indicates that the buffer is intended for use as a source in copy operations.
		/// </summary>
		CopySrc = 1 << 2,

		/// <summary>
		/// Indicates that the buffer is intended for use as a destination in copy operations.
		/// </summary>
		CopyDst = 1 << 3,

		/// <summary>
		/// Indicates that the buffer will be used for indexing operations, such as element index buffers in indexed drawing.
		/// </summary>
		Index = 1 << 4,

		/// <summary>
		/// Indicates that the buffer is intended for use as a vertex buffer.
		/// </summary>
		Vertex = 1 << 5,

		/// <summary>
		/// Indicates that the buffer will be used to store uniform data.
		/// </summary>
		Uniform = 1 << 6,

		/// <summary>
		/// Indicates that the buffer is intended to be used for storage,
		/// such as storing data that will be accessed by shaders.
		/// </summary>
		Storage = 1 << 7,

		/// <summary>
		/// Indicates that the buffer is used for indirect commands.
		/// </summary>
		Indirect = 1 << 8,

		/// <summary>
		/// Indicates that the buffer is intended to be used for query resolution.
		/// </summary>
		QueryResolve = 1 << 9,
	}
}
