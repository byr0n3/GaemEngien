namespace wgpu.Enums
{
	/// <summary>
	/// Specifies the winding order for front-facing polygons in a mesh.
	/// </summary>
	public enum FrontFace
	{
		/// <summary>
		/// Indicates no value is passed for this argument. See @ref SentinelValues.
		/// </summary>
		Undefined = 0,
		CounterClockWise,
		ClockWise,
	}
}
