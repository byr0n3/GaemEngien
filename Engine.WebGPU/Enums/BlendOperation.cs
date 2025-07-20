namespace wgpu.Enums
{
	/// <summary>
	/// Specifies the operation used to blend a source color with a destination color.
	/// </summary>
	public enum BlendOperation
	{
		/// <summary>
		/// Indicates no value is passed for this argument. See @ref SentinelValues.
		/// </summary>
		Undefined = 0,
		Add,
		Subtract,
		ReverseSubtract,
		Min,
		Max,
	}
}
