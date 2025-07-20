namespace wgpu.Enums
{
	/// <summary>
	/// Specifies the dimensions of a texture view.
	/// </summary>
	public enum TextureViewDimension
	{
		/// <summary>
		/// Specifies that the texture view dimension is undefined.
		/// </summary>
		Undefined = 0,

		/// <summary>
		/// Specifies that the texture view dimension is one-dimensional.
		/// </summary>
		OneDimension,

		/// <summary>
		/// Specifies that the texture view dimension is two-dimensional.
		/// </summary>
		TwoDimensions,

		/// <summary>
		/// Specifies that the texture view dimension is a 2D array.
		/// </summary>
		TwoDimensionsArray,

		/// <summary>
		/// Specifies that the texture view dimension is a cube map.
		/// </summary>
		Cube,

		/// <summary>
		/// Specifies that the texture view dimension is a cube array.
		/// </summary>
		CubeArray,

		/// <summary>
		/// Specifies that the texture view dimension is three-dimensional.
		/// </summary>
		ThreeDimensions,
	}
}
