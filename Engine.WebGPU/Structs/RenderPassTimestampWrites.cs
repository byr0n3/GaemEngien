using System.Runtime.InteropServices;

namespace wgpu.Structs
{
	/// <summary>
	/// Represents a range of timestamp writes to be performed within a render pass.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct RenderPassTimestampWrites
	{
		/// <summary>
		/// Gets or initializes the set of queries used to gather information about rendering performance.
		/// </summary>
		public QuerySet QuerySet { get; init; }

		/// <summary>
		/// Gets or initializes the starting index for a range of timestamp writes within a render pass.
		/// </summary>
		public uint BeginIndex { get; init; }

		/// <summary>
		/// Gets or initializes the end index of the range of timestamp writes to be performed within a render pass.
		/// </summary>
		public uint EndIndex { get; init; }
	}
}
