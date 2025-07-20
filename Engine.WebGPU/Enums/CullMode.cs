namespace wgpu.Enums
{
	/// <summary>
	/// Specifies the culling mode for rendering, determining which triangles to discard during rasterization.
	/// </summary>
	public enum CullMode
	{
		/// <summary>
		/// Indicates no value is passed for this argument. See @ref SentinelValues.
		/// </summary>
		Undefined = 0,

		/// <summary>
		/// No triangles are discarded during rasterization. Both front-facing and back-facing triangles are considered for rendering.
		/// </summary>
		None,

		/// <summary>
		/// Specifies that triangles facing the camera should be discarded during rasterization.
		/// </summary>
		Front,

		/// <summary>
		/// Discards triangles that are facing away from the camera.
		/// This is typically used for rendering single-sided surfaces where only one side of a triangle is visible.
		/// </summary>
		Back,
	}
}
