using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Engine.FreeType.Enums;
using Engine.Shared;
using glfw;

[assembly: DisableRuntimeMarshalling]

namespace Engine.FreeType.Internal
{
	// ReSharper disable once InconsistentNaming
	internal static class libfreetype
	{
		public const string Library = nameof(libfreetype);

		[DllImport(libfreetype.Library, EntryPoint = "FT_Init_FreeType")]
		public static extern NativeBool InitFreeType(Pointer<Library> library);

		[DllImport(libfreetype.Library, EntryPoint = "FT_New_Face")]
		public static extern NativeBool NewFace(Library library, NativeString path, int faceIndex, Pointer<Face> face);

		[DllImport(libfreetype.Library, EntryPoint = "FT_Set_Pixel_Sizes")]
		public static extern NativeBool SetPixelSizes(Face face, uint pixelWidth, uint pixelHeight);

		[DllImport(libfreetype.Library, EntryPoint = "FT_Load_Char")]
		public static extern NativeBool LoadChar(Face face, ulong charCode, LoadFlags flags);

		[DllImport(libfreetype.Library, EntryPoint = "FT_Done_Face")]
		public static extern NativeBool DoneFace(Face face);

		[DllImport(libfreetype.Library, EntryPoint = "FT_Done_FreeType")]
		public static extern NativeBool DoneFreeType(Library library);
	}
}
