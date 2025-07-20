namespace wgpu.Enums
{
	/// <summary>
	/// Specifies the comparison function used in depth and stencil tests.
	/// </summary>
	public enum CompareFunction
	{
		/// <summary>
		/// Indicates no value is passed for this argument. See @ref SentinelValues.
		/// </summary>
		Undefined = 0,
		Never,
		Less,
		Equal,
		LessEqual,
		Greater,
		NotEqual,
		GreaterEqual,
		Always,
	}
}
