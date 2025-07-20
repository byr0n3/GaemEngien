namespace wgpu.Enums
{
	/// <summary>
	/// Specifies the primitive topology for drawing operations in a graphics API.
	/// </summary>
	public enum PrimitiveTopology
	{
		/// <summary>
		/// Indicates no value is passed for this argument. See @ref SentinelValues.
		/// </summary>
		Undefined = 0,
		PointList,
		LineList,
		LineStrip,
		TriangleList,
		TriangleStrip,
	}
}
