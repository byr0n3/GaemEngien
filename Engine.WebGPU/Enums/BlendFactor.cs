namespace wgpu.Enums
{
	/// <summary>
	/// Represents the factors used in blending operations for color values.
	/// </summary>
	public enum BlendFactor
	{
		/// <summary>
		/// Indicates no value is passed for this argument. See @ref SentinelValues.
		/// </summary>
		Undefined = 0,
		Zero,
		One,
		Src,
		OneMinusSrc,
		SrcAlpha,
		OneMinusSrcAlpha,
		Dst,
		OneMinusDst,
		DstAlpha,
		OneMinusDstAlpha,
		SrcAlphaSaturated,
		Constant,
		OneMinusConstant,
		Src1,
		OneMinusSrc1,
		Src1Alpha,
		OneMinusSrc1Alpha,
	}
}
