namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Specifies the drawing mode for OpenGL primitives.
	/// </summary>
	public enum DrawMode
	{
		/// <summary>
		/// Specifies that OpenGL should draw individual points.
		/// </summary>
		Points = 0,

		/// <summary>
		/// Specifies that OpenGL should draw lines between vertices.
		/// </summary>
		Lines = 0x0001,

		/// <summary>
		/// Specifies that OpenGL should connect the first and last vertices of a line strip to form a closed loop.
		/// </summary>
		LineLoop = 0x0002,

		/// <summary>
		/// Specifies that OpenGL should draw a connected series of lines.
		/// </summary>
		LineStrip = 0x0003,

		/// <summary>
		/// Specifies that OpenGL should draw individual triangles.
		/// </summary>
		Triangles = 0x0004,

		/// <summary>
		/// Specifies that OpenGL should draw a series of connected triangles using the triangle strip primitive.
		/// </summary>
		TriangleStrip = 0x0005,

		/// <summary>
		/// Specifies that OpenGL should draw a series of triangles using the vertices provided in a fan-like structure.
		/// </summary>
		TriangleFan = 0x0006,

		/// <summary>
		/// Specifies that OpenGL should draw lines with adjacency.
		/// </summary>
		LinesAdjacency = 0x000A,

		/// <summary>
		/// Specifies that OpenGL should draw a line strip with adjacency.
		/// </summary>
		LineStripAdjacency = 0x000B,

		/// <summary>
		/// Specifies that OpenGL should draw triangles with adjacent connectivity information.
		/// </summary>
		TrianglesAdjacency = 0x000C,

		/// <summary>
		/// Specifies that OpenGL should draw triangle strips with adjacent primitives for efficient rendering.
		/// </summary>
		TriangleStripAdjacency = 0x000D,

		/// <summary>
		/// Specifies that OpenGL should draw patches.
		/// </summary>
		Patches = 0xE,
	}
}
