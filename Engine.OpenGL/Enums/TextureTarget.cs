namespace Engine.OpenGL.Enums
{
	public enum TextureTarget
	{
		None,
		Texture1D = 0x0DE0,
		Texture2D = 0x0DE1,
		Texture3D = 0x806F,
		Texture1DArray = 0x8C18,
		Texture2DArray = 0x8C1A,
		TextureRectangle = 0x84F5,
		TextureCubeMap = 0x8513,
		TextureCubeMapArray = 0x9009,
		TextureBuffer = 0x8C2A,
		Texture2DMultisample = 0x9100,
		Texture2DMultisampleArray = 0x9102,
	}
}
