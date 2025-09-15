namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Specifies parameters for querying shader information.
	/// </summary>
	public enum ShaderIvParameter
	{
		/// <summary>
		/// No shader parameter specified.
		/// </summary>
		None,

		/// <summary>
		/// Retrieves the type of shader.
		/// </summary>
		Type = 0x8B4F,

		/// <summary>
		/// Represents the status of whether a shader object has been deleted.
		/// </summary>
		DeleteStatus = 0x8B80,

		/// <summary>
		/// Indicates the compile status of a shader.
		/// </summary>
		CompileStatus = 0x8B81,

		/// <summary>
		/// Specifies the length of the information log for a shader.
		/// </summary>
		InfoLogLength = 0x8B84,

		/// <summary>
		/// Specifies the length of the source code string for a shader.
		/// </summary>
		SourceLength = 0x8B88,
	}
}
