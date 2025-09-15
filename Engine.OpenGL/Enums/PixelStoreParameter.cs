namespace Engine.OpenGL.Enums
{
	public enum PixelStoreParameter
	{
		None = 0,

		PackRowLength = 0x0D02,
		PackSkipRows = 0x0D03,
		PackSkipPixels = 0x0D04,
		PackAlignment = 0x0D05,
		UnpackRowLength = 0x0CF2,
		UnpackImageHeight = 0x806E,
		UnpackSkipPixels = 0x0CF4,
		UnpackSkipRows = 0x0CF3,
		UnpackSkipImages = 0x806D,
		UnpackAlignment = 0x0CF5,
	}
}
