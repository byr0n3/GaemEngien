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
	[MustDisposeResource]
	public readonly unsafe struct Face : System.IDisposable
	{
		private readonly FaceData* ptr;

		public long NumFaces =>
			this.ptr->NumFaces;

		public long FaceIndex =>
			this.ptr->FaceIndex;

		public long FaceFlags =>
			this.ptr->FaceFlags;

		public long StyleFlags =>
			this.ptr->StyleFlags;

		public long NumGlyphs =>
			this.ptr->NumGlyphs;

		public NativeString FamilyName =>
			this.ptr->FamilyName;

		public NativeString StyleName =>
			this.ptr->StyleName;

		public System.ReadOnlySpan<BitmapSize> AvailableSizes =>
			new(this.ptr->AvailableSizes, this.ptr->NumFixedSizes);

		public System.ReadOnlySpan<CharMap> Charmaps =>
			new(this.ptr->AvailableCharMaps, this.ptr->NumCharMaps);

		public BoundingBox BoundingBox =>
			this.ptr->BoundingBox;

		public GlyphSlot Glyph =>
			this.ptr->Glyph;

		public void SetPixelSizes(uint pixelWidth, uint pixelHeight)
		{
			var error = libfreetype.SetPixelSizes(this, pixelWidth, pixelHeight);

			Debug.Assert(!error, "Unable to set pixel sizes.");
		}

		public void LoadCharacter(char character, LoadFlags flags) =>
			this.LoadCharacter((ulong)character, flags);

		public void LoadCharacter(ulong characterCode, LoadFlags flags)
		{
			var error = libfreetype.LoadChar(this, characterCode, flags);

			Debug.Assert(!error, "Unable to load character.");
		}

		public void Dispose() =>
			libfreetype.DoneFace(this);
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct FaceData
	{
		public readonly long NumFaces;
		public readonly long FaceIndex;

		public readonly long FaceFlags;
		public readonly long StyleFlags;

		public readonly long NumGlyphs;

		public readonly NativeString FamilyName;
		public readonly NativeString StyleName;

		public readonly int NumFixedSizes;
		public readonly Pointer<BitmapSize> AvailableSizes;

		public readonly int NumCharMaps;
		public readonly Pointer<CharMap> AvailableCharMaps;

		public readonly Generic Generic;

		public readonly BoundingBox BoundingBox;

		public readonly ushort UnitsPerEm;
		public readonly short Ascender;
		public readonly short Descender;
		public readonly short Height;

		public readonly short MaxAdvanceWidth;
		public readonly short MaxAdvanceHeight;

		public readonly short UnderlinePosition;
		public readonly short UnderlineThickness;

		public readonly Pointer<GlyphSlot> Glyph;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BitmapSize
	{
		public readonly short Height;
		public readonly short Width;

		public readonly long Size;

		public readonly long XPpem;
		public readonly long YPpem;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct CharMap
	{
		// @todo Making type `Face` or `FaceData` throws LoadException
		public readonly nint Face;

		// @todo Encoding
		public readonly nint Encoding;

		public readonly ushort PlatformId;
		public readonly ushort EncodingId;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Generic
	{
		public readonly VoidPointer Data;
		public readonly unsafe delegate*unmanaged<void*, void> Finalizer;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BoundingBox
	{
		public readonly long XMin;
		public readonly long YMin;

		public readonly long XMax;
		public readonly long YMax;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct GlyphSlot
	{
		public readonly Library Library;
		public readonly Face Face;
		public readonly Pointer<GlyphSlot> Next;
		public readonly uint GlyphIndex;
		public readonly Generic Generic;

		public readonly GlyphMetrics Metrics;
		public readonly long LinearHoriAdvance;
		public readonly long LinearVertAdvance;
		public readonly Vector2<long> Advance;

		public readonly GlyphFormat Format;

		public readonly Bitmap Bitmap;
		public readonly int BitmapLeft;
		public readonly int BitmapTop;

		public readonly Outline Outline;

		public readonly uint NumSubglyphs;
		public readonly Pointer<nint> Subglyphs;

		public readonly VoidPointer ControlData;
		public readonly long ControlLen;

		public readonly long LsbDelta;
		public readonly long RsbDelta;

		public readonly VoidPointer Other;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct GlyphMetrics
	{
		public readonly long Width;
		public readonly long Height;

		public readonly long HorizontalBearingX;
		public readonly long HorizontalBearingY;
		public readonly long HorizontalAdvance;

		public readonly long VerticalBearingX;
		public readonly long VerticalBearingY;
		public readonly long VerticalAdvance;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Bitmap
	{
		public readonly uint Rows;
		public readonly uint Width;
		public readonly int Pitch;
		public readonly Pointer<byte> Buffer;
		public readonly ushort NumGrays;
		public readonly byte PixelMode;
		public readonly byte PaletteMode;
		public readonly VoidPointer Palette;
	}

	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Outline
	{
		public readonly ushort NumOfContours;
		public readonly ushort NumOfPoints;

		public readonly Pointer<Vector2<long>> Points;
		public readonly Pointer<byte> Tags;
		public readonly Pointer<ushort> Contours;

		public readonly int Flags;
	}
}
