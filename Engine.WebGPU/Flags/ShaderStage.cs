namespace wgpu.Flags
{
	/// <summary>
	/// Specifies the stage(s) of the graphics pipeline that a resource is used in.
	/// This enumeration allows for bitwise combinations to indicate multiple shader stages.
	/// </summary>
	[System.Flags]
	public enum ShaderStage : ulong
	{
		/// <summary>
		/// Represents no shader stage. This value is typically used when no specific shader stage is required or relevant.
		/// </summary>
		None = 0,

		/// <summary>
		/// Indicates that the shader stage is Vertex.
		/// This value represents operations performed in the vertex shader,
		/// which processes each vertex's data and computes attributes like position and texture coordinates.
		/// </summary>
		Vertex = 1 << 0,

		/// <summary>
		/// Represents the fragment shader stage.
		/// This value is used to indicate that a resource is used in the fragment shader stage of the graphics pipeline.
		/// </summary>
		Fragment = 1 << 1,

		/// <summary>
		/// Represents the compute shader stage.
		/// This value is used to indicate that a resource is used in the compute shader stage of the graphics pipeline.
		/// </summary>
		Compute = 1 << 2,
	}
}
