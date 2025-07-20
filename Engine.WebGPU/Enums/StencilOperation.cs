namespace wgpu.Enums
{
	/// <summary>
	/// Specifies the stencil operation to perform when a stencil test fails, passes,
	/// or both depth and stencil tests pass.
	/// </summary>
	public enum StencilOperation
	{
		/// <summary>
		/// Indicates no value is passed for this argument. See @ref SentinelValues.
		/// </summary>
		Undefined = 0,
		Keep,
		Zero,
		Replace,
		Invert,
		IncrementClamp,
		DecrementClamp,
		IncrementWrap,
		DecrementWrap,
	}
}
