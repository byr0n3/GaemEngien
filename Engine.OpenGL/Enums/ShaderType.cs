namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Specifies a type of shader.
	/// </summary>
	public enum ShaderType
	{
		/// <summary>
		/// Represents an invalid or non-existent shader type.
		/// </summary>
		None,

		/// <summary>
		/// Represents a fragment shader type.
		/// </summary>
		Fragment = 0x8B30,

		/// <summary>
		/// Represents a vertex shader type.
		/// </summary>
		Vertex = 0x8B31,

		/// <summary>
		/// Represents a geometry shader type.
		/// </summary>
		Geometry = 0x8DD9,

		/// <summary>
		/// Represents a tessellation evaluation shader.
		/// </summary>
		TessEvaluation = 0x8E87,

		/// <summary>
		/// Represents the tessellation control shader type.
		/// </summary>
		TessControl = 0x8E88,

		/// <summary>
		/// Represents a compute shader type.
		/// </summary>
		Compute = 0x91B9,
	}
}
