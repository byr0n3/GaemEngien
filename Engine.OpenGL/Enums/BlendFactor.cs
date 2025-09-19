namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Specifies the blending factors used in the OpenGL blending equation.
	/// </summary>
	public enum BlendFactor
	{
		/// <summary>
		/// Represents the blending factor of zero. This is used to specify that no source color should be used in the blending equation.
		/// </summary>
		Zero = 0,

		/// <summary>
		/// Represents the blending factor of one.
		/// This is used to specify that the source color should be fully used in the blending equation.
		/// </summary>
		One = 1,

		/// <summary>
		/// Represents the source color as the blending factor.
		/// This is used to specify that the source color should be used directly in the blending equation.
		/// </summary>
		SrcColor = 0x0300,

		/// <summary>
		/// Represents the blending factor of one minus the source color.
		/// This is used to specify that the complement of the source color should be used in the blending equation.
		/// </summary>
		OneMinusSrcColor = 0x0301,

		/// <summary>
		/// Represents the source alpha factor.
		/// This is used to specify that the source color's alpha value should be used in the blending equation.
		/// </summary>
		SrcAlpha = 0x0302,

		/// <summary>
		/// Represents the blending factor of one minus source alpha.
		/// This is used to specify that the complement of the source alpha should be used in the blending equation.
		/// </summary>
		OneMinusSrcAlpha = 0x0303,

		/// <summary>
		/// Represents the blending factor of destination alpha.
		/// This is used to specify that the alpha component of the destination color should be used in the blending equation.
		/// </summary>
		DstAlpha = 0x0304,

		/// <summary>
		/// Represents the blending factor of one minus destination alpha.
		/// This is used to specify that the source color should be blended with the inverse of the destination alpha.
		/// </summary>
		OneMinusDstAlpha = 0x0305,

		/// <summary>
		/// Represents the blending factor of destination color.
		/// This is used to specify that the destination color should be used in the blending equation.
		/// </summary>
		DstColor = 0x0306,

		/// <summary>
		/// Represents the blending factor of one minus the destination color.
		/// This is used to specify that the inverse of the destination color should be used in the blending equation.
		/// </summary>
		OneMinusDstColor = 0x0307,

		/// <summary>
		/// Represents the blending factor of source alpha saturate.
		/// This is used to specify that the source alpha should be saturated during the blending equation.
		/// </summary>
		SrcAlphaSaturate = 0x0308,

		/// <summary>
		/// Represents a constant color value used in the OpenGL blending equation.
		/// This is specified by the application and used to scale source and destination colors.
		/// </summary>
		ConstantColor = 0x8001,

		/// <summary>
		/// Represents the blending factor of one minus constant color.
		/// This is used to specify that the inverse of the constant color should be used in the blending equation.
		/// </summary>
		OneMinusConstantColor = 0x8002,

		/// <summary>
		/// Represents the blending factor of constant alpha.
		/// This is used to specify that the constant alpha value should be used in the blending equation.
		/// </summary>
		ConstantAlpha = 0x8003,

		/// <summary>
		/// Represents the blending factor of one minus constant alpha.
		/// This is used to specify that the inverse of the constant alpha should be used in the blending equation.
		/// </summary>
		OneMinusConstantAlpha = 0x8004,
	}
}
