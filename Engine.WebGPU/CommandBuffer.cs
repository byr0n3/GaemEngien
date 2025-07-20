using JetBrains.Annotations;

namespace wgpu
{
	/// <summary>
	/// Represents a buffer of command data that can be submitted to a queue for execution.
	/// </summary>
	[MustDisposeResource]
	public readonly struct CommandBuffer : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Releases the resources used by the current instance.
		/// </summary>
		public void Dispose() =>
			CommandBufferNative.Release(this);
	}
}
