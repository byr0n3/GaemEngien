namespace wgpu.Enums
{
	/// <summary>
	/// Defines the step mode for a vertex buffer layout, specifying how often data in each vertex buffer is updated.
	/// </summary>
	public enum VertexStepMode
	{
		/// <summary>
		/// This @ref WGPUVertexBufferLayout is a "hole" in the @ref WGPUVertexState `buffers` array.
		/// (See also @ref SentinelValues.)
		/// </summary>
		VertexBufferNotUsed = 0,

		/// <summary>
		/// Indicates no value is passed for this argument. See SentinelValues.
		/// </summary>
		Undefined,

		/// <summary>
		/// Specifies that the data in each vertex buffer is updated for each vertex.
		/// </summary>
		Vertex,

		/// <summary>
		/// This value specifies that the vertex buffer is updated once per instance. Useful for instanced rendering where data changes per draw call.
		/// </summary>
		Instance,
	}
}
