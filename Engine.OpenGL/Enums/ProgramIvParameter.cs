namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Represents the parameters used with <see cref="Engine.OpenGL.GL.GetProgramIv(uint, ProgramIvParameter)"/>.
	/// </summary>
	public enum ProgramIvParameter
	{
		/// <summary>
		/// Represents an invalid or unspecified parameter for the program.
		/// </summary>
		None,

		/// <summary>
		/// Represents the status of a program's deletion.
		/// </summary>
		DeleteStatus = 0x8B80,

		/// <summary>
		/// Represents the status of linking a program object.
		/// </summary>
		LinkStatus = 0x8B82,

		/// <summary>
		/// Represents the status of a program's validation process.
		/// </summary>
		ValidateStatus = 0x8B83,

		/// <summary>
		/// Specifies the length of the information log for a program object.
		/// </summary>
		InfoLogLength = 0x8B84,

		/// <summary>
		/// Specifies the number of shader objects attached to a program object.
		/// </summary>
		AttachedShaders = 0x8B85,

		/// <summary>
		/// Represents the number of active uniform variables for a program.
		/// </summary>
		ActiveUniforms = 0x8B86,

		/// <summary>
		/// Represents the maximum length of a string that can be returned for an active uniform.
		/// </summary>
		ActiveUniformMaxLength = 0x8B87,

		/// <summary>
		/// Represents the number of active attributes in a program.
		/// </summary>
		ActiveAttributes = 0x8B89,

		/// <summary>
		/// Specifies the maximum length of the longest active attribute name in a program.
		/// </summary>
		ActiveAttributeMaxLength = 0x8B8A,
	}
}
