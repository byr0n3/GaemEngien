namespace wgpu.Enums
{
	/// <summary>
	/// Specifies the type of data sampled from a texture.
	/// </summary>
	public enum TextureSampleType
	{
		/// <summary>
		/// Indicates that this @ref WGPUTextureBindingLayout member of
		/// its parent @ref WGPUBindGroupLayoutEntry is not used.
		/// (See also @ref SentinelValues.)
		/// </summary>
		BindingNotUsed = 0,

		/// <summary>
		/// Indicates no value is passed for this argument. See @ref SentinelValues.
		/// </summary>
		Undefined,

		/// <summary>
		/// Specifies that the texture samples are floating-point values.
		/// </summary>
		Float,

		/// <summary>
		/// Specifies that the texture sample type is a float value which cannot be filtered.
		/// </summary>
		UnfilterableFloat,

		/// <summary>
		/// Specifies that the texture sample type is depth.
		/// </summary>
		Depth,

		/// <summary>
		/// Indicates that the texture sample type is signed integer.
		/// </summary>
		Sint,

		/// <summary>
		/// Specifies that the texture data is of an unsigned integer type.
		/// </summary>
		Uint,
	}
}
