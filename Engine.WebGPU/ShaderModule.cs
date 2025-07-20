using JetBrains.Annotations;

namespace wgpu
{
	/// <summary>
	/// Represents a shader module, which contains compiled GPU shader code.
	/// </summary>
	[MustDisposeResource]
	public readonly struct ShaderModule : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Releases the unmanaged resources used by this instance and makes it ineligible for use.
		/// </summary>
		public void Dispose() =>
			ShaderModuleNative.Release(this);
	}
}
