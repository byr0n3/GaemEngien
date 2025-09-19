namespace Engine.FreeType.Enums
{
	/// <summary>
	/// Specifies the format of a glyph.
	/// </summary>
	public enum GlyphFormat
	{
		/// <summary>
		/// Represents an undefined or invalid glyph format.
		/// </summary>
		None,

		/// <summary>
		/// Represents a glyph format using SVG (Scalable Vector Graphics).
		/// </summary>
		Svg = 1398163232, // S V G ' '

		/// <summary>
		/// Represents a bitmap glyph format.
		/// </summary>
		Bitmap = 1651078259, // b i t s

		/// <summary>
		/// Represents a composite glyph format, which is composed of other glyphs.
		/// </summary>
		Composite = 1668246896, // c o m p

		/// <summary>
		/// Represents a glyph format that uses outline data to describe the shape of a glyph.
		/// </summary>
		Outline = 1869968492, // o u t l

		/// <summary>
		/// Represents a glyph format that uses a plotter for rendering.
		/// </summary>
		Plotter = 1886154612, // p l o t
	}
}
