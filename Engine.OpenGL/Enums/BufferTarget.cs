namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Specifies the target to which buffer object operations are directed.
	/// </summary>
	public enum BufferTarget
	{
		/// <summary>
		/// Specifies that no buffer target is selected. Used to unbind a buffer.
		/// </summary>
		None,

		/// <summary>
		/// Specifies the buffer target for vertex attribute arrays.
		/// This is used to bind a buffer object to this target, allowing vertex data to be stored and accessed efficiently.
		/// </summary>
		Array = 0x8892,

		/// <summary>
		/// Specifies that the buffer object is a Shader Storage Buffer Object (SSBO) with atomic counter support.
		/// </summary>
		AtomicCounter = 0x92C0,

		/// <summary>
		/// Specifies the buffer target for copying data from another buffer.
		/// Used in operations that require a source buffer to be read.
		/// </summary>
		CopyRead = 0x8F36,

		/// <summary>
		/// Specifies that the buffer is used for copying data from one buffer to another.
		/// </summary>
		CopyWrite = 0x8F37,

		/// <summary>
		/// Specifies the buffer target for indirect dispatch commands.
		/// </summary>
		DispatchIndirect = 0x8F3F,

		/// <summary>
		/// Specifies that the buffer is used for indirect draw commands.
		/// </summary>
		DrawIndirect = 0x8F39,

		/// <summary>
		/// Specifies the element array buffer object target. Used for storing vertex indices.
		/// </summary>
		ElementArray = 0x8893,

		/// <summary>
		/// Specifies that the buffer is bound for pixel packing operations.
		/// </summary>
		PixelPack = 0x88EB,

		/// <summary>
		/// Specifies the target for pixel unpack operations.
		/// This is used to define where data should be read from when performing pixel transfer operations.
		/// </summary>
		PixelUnpack = 0x88EC,

		/// <summary>
		/// Specifies the buffer target for query object buffers.
		/// </summary>
		Query = 0x9192,

		/// <summary>
		/// Specifies the target for shader storage buffers.
		/// </summary>
		ShaderStorage = 0x90D2,

		/// <summary>
		/// Specifies that the buffer is used for storing texture data.
		/// </summary>
		Texture = 0x8C2A,

		/// <summary>
		/// Specifies that the buffer is used for transform feedback operations.
		/// </summary>
		TransformFeedback = 0x8E22,

		/// <summary>
		/// Specifies the buffer target for uniform buffer objects.
		/// </summary>
		Uniform = 0x8A11,
	}
}
