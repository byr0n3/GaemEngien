namespace wgpu.Enums
{
	public enum SamplerBindingType
	{
		/// <summary>
		/// Indicates that this @ref WGPUSamplerBindingLayout member of
		/// its parent @ref WGPUBindGroupLayoutEntry is not used.
		/// (See also @ref SentinelValues.)
		/// </summary>
		BindingNotUsed = 0,

		/// <summary>
		/// Indicates no value is passed for this argument. See @ref SentinelValues.
		/// </summary>
		Undefined,
		Filtering,
		NonFiltering,
		Comparison,
	}
}
