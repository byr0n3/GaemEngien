using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using Engine.FreeType.Enums;
using Engine.FreeType.Internal;
using Engine.Shared;
using glfw;
using JetBrains.Annotations;

namespace Engine.FreeType
{
	/// <summary>
	/// Represents a font face, providing access to its metrics and allowing the loading of glyphs.
	/// </summary>
	[MustDisposeResource]
	public readonly unsafe struct Face : System.IDisposable
	{
		private readonly FaceData* ptr;

		/// <inheritdoc cref="FaceData.NumFaces"/>
		public long NumFaces =>
			this.ptr->NumFaces;

		/// <inheritdoc cref="FaceData.FaceIndex"/>
		public long FaceIndex =>
			this.ptr->FaceIndex;

		/// <inheritdoc cref="FaceData.FaceFlags"/>
		public long FaceFlags =>
			this.ptr->FaceFlags;

		/// <inheritdoc cref="FaceData.StyleFlags"/>
		public long StyleFlags =>
			this.ptr->StyleFlags;

		/// <inheritdoc cref="FaceData.NumGlyphs"/>
		public long NumGlyphs =>
			this.ptr->NumGlyphs;

		/// <inheritdoc cref="FaceData.FamilyName"/>
		public NativeString FamilyName =>
			this.ptr->FamilyName;

		/// <inheritdoc cref="FaceData.StyleName"/>
		public NativeString StyleName =>
			this.ptr->StyleName;

		/// <inheritdoc cref="FaceData.AvailableSizes"/>
		public System.ReadOnlySpan<BitmapSize> AvailableSizes =>
			new(this.ptr->AvailableSizes, this.ptr->NumFixedSizes);

		/// <inheritdoc cref="FaceData.AvailableCharMaps"/>
		public System.ReadOnlySpan<CharMap> CharMaps =>
			new(this.ptr->AvailableCharMaps, this.ptr->NumCharMaps);

		/// <inheritdoc cref="FaceData.BoundingBox"/>
		public BoundingBox BoundingBox =>
			this.ptr->BoundingBox;

		/// <inheritdoc cref="FaceData.Glyph"/>
		public GlyphSlot Glyph =>
			this.ptr->Glyph;

		/// <summary>
		/// Sets the pixel dimensions for a face.
		/// </summary>
		/// <param name="pixelWidth">The width in pixels.</param>
		/// <param name="pixelHeight">The height in pixels.</param>
		public void SetPixelSizes(uint pixelWidth, uint pixelHeight)
		{
			var error = libfreetype.SetPixelSizes(this, pixelWidth, pixelHeight);

			Debug.Assert(!error, "Unable to set pixel sizes.");
		}

		/// <summary>
		/// Loads a specific character into the face with the specified loading options.
		/// </summary>
		/// <param name="character">The character to load.</param>
		/// <param name="flags">The options for loading the character.</param>
		public void LoadCharacter(char character, LoadFlags flags) =>
			this.LoadCharacter((ulong)character, flags);

		/// <summary>
		/// Loads a character glyph into the face.
		/// </summary>
		/// <param name="characterCode">The Unicode code point of the character.</param>
		/// <param name="flags">Options for loading the character, such as rendering or hinting flags.</param>
		public void LoadCharacter(ulong characterCode, LoadFlags flags)
		{
			var error = libfreetype.LoadChar(this, characterCode, flags);

			Debug.Assert(!error, "Unable to load character.");
		}

		/// <summary>
		/// Releases the resources associated with this face.
		/// </summary>
		public void Dispose() =>
			libfreetype.DoneFace(this);
	}

	/// <summary>
	/// Contains metadata and metrics for a font face, providing detailed information about its characteristics and capabilities.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct FaceData
	{
		/// <summary>
		/// The number of faces in the current font file.
		/// </summary>
		public readonly long NumFaces;

		/// <summary>
		/// The index of the face within its parent font file.
		/// </summary>
		public readonly long FaceIndex;

		/// <summary>
		/// Represents the flags associated with a font face, providing information about its characteristics and capabilities.
		/// </summary>
		public readonly long FaceFlags;

		/// <summary>
		/// Represents the flags associated with a font face, providing information about its characteristics and capabilities.
		/// </summary>
		public readonly long StyleFlags;

		/// <summary>
		/// The total number of glyphs in the font face.
		/// </summary>
		public readonly long NumGlyphs;

		/// <summary>
		/// The name of the font family for this face.
		/// </summary>
		public readonly NativeString FamilyName;

		/// <summary>
		/// The name of the style for the font face, represented as a native string.
		/// </summary>
		public readonly NativeString StyleName;

		/// <summary>
		/// The number of pre-defined sizes available for the font face.
		/// </summary>
		public readonly int NumFixedSizes;

		/// <summary>
		/// Gets a read-only span of available bitmap sizes for the current font face.
		/// </summary>
		public readonly Pointer<BitmapSize> AvailableSizes;

		/// <summary>
		/// The number of character maps available in the font face.
		/// </summary>
		public readonly int NumCharMaps;

		/// <summary>
		/// A pointer to the array of available character maps for this font face.
		/// </summary>
		public readonly Pointer<CharMap> AvailableCharMaps;

		/// <summary>
		/// Represents a generic data structure with a pointer to raw data and an optional finalizer delegate.
		/// </summary>
		public readonly Generic Generic;

		/// <summary>
		/// Represents the bounding box of a font face, defining its extents in the horizontal and vertical dimensions.
		/// </summary>
		public readonly BoundingBox BoundingBox;

		/// <summary>
		/// The number of font units per em size, which is a design scaling unit for the face.
		/// </summary>
		public readonly ushort UnitsPerEm;

		/// <summary>
		/// The maximum ascender value for the face,
		/// representing the greatest distance above the baseline that any glyph in the font extends.
		/// </summary>
		public readonly short Ascender;

		/// <summary>
		/// The maximum glyph descent for the font face, typically used to calculate the vertical layout of text.
		/// </summary>
		public readonly short Descender;

		/// <summary>
		/// The height of the font face, typically representing the total vertical extent from the baseline to the topmost ascent.
		/// </summary>
		public readonly short Height;

		/// <summary>
		/// The maximum advance width for the glyphs in the font face,
		/// representing the furthest horizontal distance any single character can extend.
		/// </summary>
		public readonly short MaxAdvanceWidth;

		/// <summary>
		/// The maximum advance height of any glyph in the font face, measured in font units.
		/// This value represents the greatest vertical distance that a single character can extend above its baseline position.
		/// </summary>
		public readonly short MaxAdvanceHeight;

		/// <summary>
		/// The vertical position of the underline for the font face,
		/// typically measured in 1/64th of an em unit from the baseline.
		/// </summary>
		public readonly short UnderlinePosition;

		/// <summary>
		/// The thickness of the underline in the current font.
		/// </summary>
		public readonly short UnderlineThickness;

		/// <summary>
		/// Represents a slot for storing glyph data.
		/// </summary>
		public readonly Pointer<GlyphSlot> Glyph;
	}

	/// <summary>
	/// Represents the size and resolution of a bitmap used by a font face.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BitmapSize
	{
		/// <summary>
		/// The height of the bitmap in pixels.
		/// </summary>
		public readonly short Height;

		/// <summary>
		/// The width of the bitmap in pixels.
		/// </summary>
		public readonly short Width;

		/// <summary>
		/// Represents the size of the bitmap in bytes.
		/// </summary>
		public readonly long Size;

		/// <summary>
		/// The width of the bitmap in Pixels per Em (PPEM) units.
		/// </summary>
		public readonly long XPpem;

		/// <summary>
		/// The height of the bitmap in Pixels per Em (PPEM) units.
		/// </summary>
		public readonly long YPpem;
	}

	/// <summary>
	/// Represents a character map, providing access to encoding and platform-specific information.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct CharMap
	{
		// @todo Making type `Face` or `FaceData` throws LoadException
		/// <summary>
		/// Represents a font face, providing access to its metrics and allowing the loading of glyphs.
		/// </summary>
		public readonly nint Face;

		// @todo Encoding
		/// <summary>
		/// Identifies the encoding scheme used by this character map.
		/// </summary>
		public readonly nint Encoding;

		/// <summary>
		/// Identifies the platform-specific identifier used by this character map.
		/// </summary>
		public readonly ushort PlatformId;

		/// <summary>
		/// Specifies the encoding identifier used by this character map.
		/// </summary>
		public readonly ushort EncodingId;
	}

	/// <summary>
	/// Represents a generic data structure with a pointer to raw data and an optional finalizer delegate.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Generic
	{
		/// <summary>
		/// Represents a pointer to raw data.
		/// </summary>
		public readonly VoidPointer Data;

		/// <summary>
		/// A delegate that points to a function responsible for finalizing the unmanaged resources of an object.
		/// </summary>
		public readonly unsafe delegate*unmanaged<void*, void> Finalizer;
	}

	/// <summary>
	/// Represents the bounding box of a font face, defining its extents in the horizontal and vertical dimensions.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BoundingBox
	{
		/// <summary>
		/// The minimum horizontal (x) coordinate of the face's bounding box.
		/// </summary>
		public readonly long XMin;

		/// <summary>
		/// The minimum vertical (y) coordinate of the face's bounding box.
		/// </summary>
		public readonly long YMin;

		/// <summary>
		/// The maximum horizontal (x) coordinate of the face's bounding box.
		/// </summary>
		public readonly long XMax;

		/// <summary>
		/// The maximum vertical (y) coordinate of the face's bounding box.
		/// </summary>
		public readonly long YMax;
	}

	/// <summary>
	/// Represents a slot for glyphs within a font face, providing access to its metrics and various glyph-related data.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct GlyphSlot
	{
		/// <summary>
		/// Represents a FreeType library instance that can be used to create faces and perform font operations.
		/// </summary>
		public readonly Library Library;

		/// <summary>
		/// Represents a font face, providing access to its metrics and allowing the loading of glyphs.
		/// </summary>
		public readonly Face Face;

		/// <summary>
		/// A pointer to the next glyph slot in a chain of slots.
		/// </summary>
		public readonly Pointer<GlyphSlot> Next;

		/// <summary>
		/// The index of the glyph within the current font face.
		/// </summary>
		public readonly uint GlyphIndex;

		/// <summary>
		/// Represents a generic data structure with a pointer to raw data and an optional finalizer delegate.
		/// </summary>
		public readonly Generic Generic;

		/// <summary>
		/// Represents the metrics of a glyph, including its dimensions, bearing, and advance values.
		/// </summary>
		public readonly GlyphMetrics Metrics;

		/// <summary>
		/// The horizontal advancement of the glyph in 1/64th pixel units.
		/// </summary>
		public readonly long LinearHoriAdvance;

		/// <summary>
		/// Represents the linear vertical advance of the glyph, in font units.
		/// </summary>
		public readonly long LinearVertAdvance;

		/// <summary>
		/// Gets the advancement vector of the glyph slot.
		/// This represents the distance to move the cursor in both the X and Y directions after rendering the glyph.
		/// </summary>
		public readonly Vector2<long> Advance;

		/// <summary>
		/// Specifies the format of a glyph.
		/// </summary>
		public readonly GlyphFormat Format;

		/// <summary>
		/// Represents a bitmap containing the glyph image for rendering.
		/// </summary>
		public readonly Bitmap Bitmap;

		/// <summary>
		/// The horizontal offset from the current position to the left edge of the bitmap glyph.
		/// </summary>
		public readonly int BitmapLeft;

		/// <summary>
		/// The vertical distance from the baseline to the topmost scanline of the bitmap glyph.
		/// </summary>
		public readonly int BitmapTop;

		/// <summary>
		/// Represents the outline of a glyph, containing its contours and points.
		/// </summary>
		public readonly Outline Outline;

		/// <summary>
		/// Gets the number of subglyphs in the current glyph slot.
		/// </summary>
		public readonly uint NumSubglyphs;

		/// <summary>
		/// A pointer to an array of subglyphs for the current glyph.
		/// </summary>
		public readonly Pointer<nint> Subglyphs;

		/// <summary>
		/// A pointer to control data associated with the glyph slot,
		/// allowing for additional glyph manipulation and customization.
		/// </summary>
		public readonly VoidPointer ControlData;

		/// <summary>
		/// The length of the control data in bytes.
		/// </summary>
		public readonly long ControlLen;

		/// <summary>
		/// Represents the left side bearing delta value,
		/// which is a difference between the original and scaled left side bearings for the glyph.
		/// </summary>
		public readonly long LsbDelta;

		/// <summary>
		/// Represents the right side bearing delta in design units for a glyph.
		/// This value can be used to adjust the position of the next glyph when rendering text.
		/// </summary>
		public readonly long RsbDelta;

		/// <summary>
		/// Represents a pointer to arbitrary data associated with the glyph slot.
		/// </summary>
		public readonly VoidPointer Other;
	}

	/// <summary>
	/// Represents the metrics of a glyph, including its dimensions, bearing, and advance values.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct GlyphMetrics
	{
		/// <summary>
		/// The width of the glyph in font units.
		/// </summary>
		public readonly long Width;

		/// <summary>
		/// The height of the glyph in font units.
		/// </summary>
		public readonly long Height;

		/// <summary>
		/// The distance from the origin to the left side of the glyph's advance in font units.
		/// </summary>
		public readonly long HorizontalBearingX;

		/// <summary>
		/// The distance from the origin to the top side of the glyph's advance in font units.
		/// </summary>
		public readonly long HorizontalBearingY;

		/// <summary>
		/// The horizontal distance to move the cursor for the next glyph, measured in font units.
		/// </summary>
		public readonly long HorizontalAdvance;

		/// <summary>
		/// The distance from the origin to the left side of the glyph's advance in font units, when measured vertically.
		/// </summary>
		public readonly long VerticalBearingX;

		/// <summary>
		/// The distance from the origin to the top side of the glyph's advance in font units, when measured vertically.
		/// </summary>
		public readonly long VerticalBearingY;

		/// <summary>
		/// The vertical distance to move the cursor for the next glyph, measured in font units.
		/// </summary>
		public readonly long VerticalAdvance;
	}

	/// <summary>
	/// Represents a bitmap structure used to store the glyph image data.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Bitmap
	{
		/// <summary>
		/// The number of rows in the bitmap image.
		/// </summary>
		public readonly uint Rows;

		/// <summary>
		/// Gets the width of the bitmap in pixels.
		/// </summary>
		public readonly uint Width;

		/// <summary>
		/// The pitch or stride of the bitmap image in bytes.
		/// This represents the distance between the start of one row to the next,
		/// which might be larger than the width due to alignment requirements.
		/// </summary>
		public readonly int Pitch;

		/// <summary>
		/// A pointer to the buffer containing the glyph image data.
		/// </summary>
		public readonly Pointer<byte> Buffer;

		/// <summary>
		/// The number of grayscale pixels in the bitmap image.
		/// </summary>
		public readonly ushort NumGrays;

		/// <summary>
		/// Specifies the pixel format used in the bitmap image.
		/// </summary>
		public readonly byte PixelMode;

		/// <summary>
		/// Specifies the mode of the palette used in the bitmap image.
		/// </summary>
		public readonly byte PaletteMode;

		/// <summary>
		/// Represents a pointer to an unknown, unmanaged type used for palette data in the bitmap image.
		/// </summary>
		public readonly VoidPointer Palette;
	}

	/// <summary>
	/// Represents the outline of a glyph, containing its contours and points.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Outline
	{
		/// <summary>
		/// The number of contours in the glyph outline.
		/// </summary>
		public readonly ushort NumOfContours;

		/// <summary>
		/// The number of points in the glyph outline.
		/// </summary>
		public readonly ushort NumOfPoints;

		/// <summary>
		/// Represents a pointer to an array of <see cref="Vector2"/> points that define the outline of a glyph.
		/// </summary>
		public readonly Pointer<Vector2<long>> Points;

		/// <summary>
		/// Represents a pointer to an array of tags associated with the glyph outline.
		/// </summary>
		public readonly Pointer<byte> Tags;

		/// <summary>
		/// Represents a pointer to an array of ushort values that define the start and end indices of contours in the glyph outline.
		/// </summary>
		public readonly Pointer<ushort> Contours;

		/// <summary>
		/// Represents the flags associated with the glyph outline, providing additional information about its properties and behavior.
		/// </summary>
		public readonly int Flags;
	}
}
