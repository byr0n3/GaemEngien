namespace wgpu.Flags
{
	/// <summary>
	/// Specifies which color channels can be written to when rendering.
	/// </summary>
	[System.Flags]
	public enum ColorWriteMask : ulong
	{
		/// <summary>
		/// Specifies that no color channels can be written to.
		/// </summary>
		None = 0,

		/// <summary>
		/// Specifies that the red color channel can be written to.
		/// </summary>
		Red = 1 << 0,

		/// <summary>
		/// Specifies that the green color channel can be written to.
		/// </summary>
		Green = 1 << 1,

		/// <summary>
		/// Specifies that the blue color channel can be written to.
		/// </summary>
		Blue = 1 << 2,

		/// <summary>
		/// Specifies that the alpha channel can be written to.
		/// </summary>
		Alpha = 1 << 3,

		/// <summary>
		/// Specifies that all color channels (red, green, blue, and alpha) can be written to.
		/// </summary>
		All = ColorWriteMask.Red | ColorWriteMask.Green | ColorWriteMask.Blue | ColorWriteMask.Alpha,
	}
}
