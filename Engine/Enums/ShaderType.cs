namespace Engine.Enums
{
	/// <summary>
	/// Enumerates the types of shaders used in the engine.
	/// </summary>
	public enum ShaderType
	{
		/// <summary>
		/// Represents an unknown or unrecognized shader type.
		/// </summary>
		Unknown,

		/// <summary>
		/// Represents a WGSL shader type, used for the WebGPU Shader Language.
		/// </summary>
		WGSL,

		// @todo Support more Shader types
	}
}
