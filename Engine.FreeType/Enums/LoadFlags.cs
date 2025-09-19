namespace Engine.FreeType.Enums
{
	/// <summary>
	/// Specifies options for loading characters from a font face.
	/// </summary>
	[System.Flags]
	public enum LoadFlags
	{
		/// <summary>
		/// Specifies no special options for loading characters from a font face. This is the default behavior.
		/// </summary>
		Default = 0,

		/// <summary>
		/// Specifies that characters should be loaded without any scaling applied to their bitmaps.
		/// </summary>
		NoScale = 1 << 0,

		/// <summary>
		/// Disables hinting when loading characters from a font face.
		/// This can result in faster rendering but lower quality output.
		/// </summary>
		NoHinting = 1 << 1,

		/// <summary>
		/// Specifies that the glyph bitmap should be rendered into a pixmap, even if the font driver doesn't require this.
		/// </summary>
		Render = 1 << 2,

		/// <summary>
		/// Prevents the creation of a bitmap for loaded characters.
		/// </summary>
		NoBitmap = 1 << 3,

		/// <summary>
		/// Specifies that the character layout should be vertical when loading characters from a font face.
		/// </summary>
		VerticalLayout = 1 << 4,

		/// <summary>
		/// Enables the automatic hinting engine to be used if it is available for the font face.
		/// </summary>
		ForceAutohint = 1 << 5,

		/// <summary>
		/// Specifies that the glyph bitmap should be cropped to its minimum extent.
		/// This flag is only used when loading a glyph as a bitmap.
		/// </summary>
		CropBitmap = 1 << 6,

		/// <summary>
		/// Performs a highly detailed loading of characters from a font face,
		/// ensuring high-quality results at the cost of performance.
		/// </summary>
		Pedantic = 1 << 7,

		/// <summary>
		/// Ignores the global advance width value of a glyph.
		/// This flag is used to prevent FreeType from adjusting the advance width based on the global metrics.
		/// </summary>
		IgnoreGlobalAdvanceWidth = 1 << 9,

		/// <summary>
		/// Prevents FreeType from recursively loading child faces when loading a font.
		/// </summary>
		NoRecurse = 1 << 10,

		/// <summary>
		/// Prevents the transformation of glyph images to be loaded.
		/// This is useful when you want to manipulate the glyph image directly without any modifications.
		/// </summary>
		IgnoreTransform = 1 << 11,

		/// <summary>
		/// Requests a monochrome glyph bitmap (i.e. a 1-bit per pixel bitmap, also known as a 'bitmap' or 'bitonal').
		/// This is the default.
		/// </summary>
		Monochrome = 1 << 12,

		/// <summary>
		/// Indicates that the font face should be loaded using linear design metrics.
		/// </summary>
		LinearDesign = 1 << 13,

		/// <summary>
		/// Specifies that only the bitmaps of characters should be loaded from a font face.
		/// </summary>
		SBitsOnly = 1 << 14,

		/// <summary>
		/// Disables the auto-hinter when loading a glyph.
		/// This can be useful if you want to use your own hinting algorithm or if you don't need hinting at all.
		/// </summary>
		NoAutohint = 1 << 15,

		/// <summary>
		/// Enables color glyph support when loading characters from a font face.
		/// </summary>
		Color = 1 << 20,

		/// <summary>
		/// Specifies that the glyph's metrics should be computed even if its bitmap or outline is not loaded.
		/// </summary>
		ComputeMetrics = 1 << 21,

		/// <summary>
		/// Specifies that only the font metrics are to be loaded, without loading any bitmaps or outlines.
		/// </summary>
		BitmapMetricsOnly = 1 << 22,

		/// <summary>
		/// Prevents the loading of SVG glyph data.
		/// This flag is used to skip any embedded SVG data when loading characters from a font face.
		/// </summary>
		NoSvg = 1 << 24,
	}
}
