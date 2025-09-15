namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Represents various OpenGL error flags that can be returned by the <see cref="Engine.OpenGL.GL"/> class.
	/// </summary>
	public enum ErrorFlag
	{
		/// <summary>
		/// Indicates that no error has occurred.
		/// This is the default value and represents a state where there are no OpenGL errors to report.
		/// </summary>
		None = 0,

		/// <summary>
		/// Indicates that an invalid enumeration value has been encountered.
		/// This error occurs when the specified OpenGL enum is not a valid enumerated value.
		/// </summary>
		InvalidEnum = 0x0500,

		/// <summary>
		/// Indicates that an invalid value was passed to an OpenGL API function.
		/// This typically occurs when a value is outside the range of allowable values for a given parameter
		/// or is not compatible with the current OpenGL state.
		/// </summary>
		InvalidValue = 0x0501,

		/// <summary>
		/// Indicates that an invalid operation has been attempted.
		/// This error occurs when a function is called inappropriately,
		/// such as using it outside the context where it's valid or with incompatible arguments.
		/// </summary>
		InvalidOperation = 0x0502,

		/// <summary>
		/// Indicates that an OpenGL operation caused a stack overflow.
		/// This error is generated if there is not enough stack memory to perform the requested operation,
		/// such as pushing too many elements onto a matrix or display list stack.
		/// </summary>
		StackOverflow = 0x0503,

		/// <summary>
		/// Indicates that an attempt was made to pop an element from an empty stack.
		/// This error occurs when a stack operation (such as popping) is performed on a stack that has no elements,
		/// leading to an underflow condition.
		/// </summary>
		StackUnderflow = 0x0504,

		/// <summary>
		/// Indicates that an OpenGL operation could not be completed
		/// because there is insufficient memory available to execute the command.
		/// This error can occur when trying to allocate memory for buffers or textures, among other operations.
		/// </summary>
		OutOfMemory = 0x0505,

		/// <summary>
		/// Indicates that an operation against a framebuffer object is not allowed for some reason.
		/// This error flag is raised when the specified operation cannot be executed on the current framebuffer binding.
		/// </summary>
		InvalidFramebufferOperation = 0x0506,
	}
}
