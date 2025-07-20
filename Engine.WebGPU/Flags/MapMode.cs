namespace wgpu.Flags
{
	/// <summary>
	/// Specifies the mode for mapping a GPU buffer.
	/// </summary>
	[System.Flags]
	public enum MapMode : ulong
	{
		/// <summary>
		/// Specifies that no map mode is set.
		/// This value is typically not used directly but serves as a default or unset value.
		/// </summary>
		None = 0,

		/// <summary>
		/// Specifies that the buffer should be mapped for reading.
		/// This mode allows CPU-accessible memory to read from a GPU buffer.
		/// </summary>
		Read = 1 << 0,

		/// <summary>
		/// Specifies that the buffer should be mapped for writing.
		/// This allows the application to write data into the buffer's memory.
		/// </summary>
		Write = 1 << 1,
	}
}
