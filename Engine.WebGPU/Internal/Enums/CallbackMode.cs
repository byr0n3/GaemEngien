namespace wgpu.Internal.Enums
{
	/// <summary>
	/// Specifies the mode for handling callbacks in asynchronous operations.
	/// </summary>
	public enum CallbackMode
	{
		/// <summary>
		/// Callbacks created with `WGPUCallbackMode_WaitAnyOnly`:
		/// - fire when the asynchronous operation's future is passed to a call to `::wgpuInstanceWaitAny`
		///   AND the operation has already completed or it completes inside the call to `::wgpuInstanceWaitAny`.
		/// </summary>
		WaitAnyOnly = 1,

		/// <summary>
		/// Callbacks created with `WGPUCallbackMode_AllowProcessEvents`:
		/// - fire for the same reasons as callbacks created with `WGPUCallbackMode_WaitAnyOnly`
		/// - fire inside a call to `::wgpuInstanceProcessEvents` if the asynchronous operation is complete.
		/// </summary>
		AllowProcessEvents,

		/// <summary>
		/// Callbacks created with `WGPUCallbackMode_AllowSpontaneous`:
		/// - fire for the same reasons as callbacks created with `WGPUCallbackMode_AllowProcessEvents`
		/// - **may** fire spontaneously on an arbitrary or application thread, when the WebGPU implementations discovers that the asynchronous operation is complete.
		///   Implementations _should_ fire spontaneous callbacks as soon as possible.
		/// </summary>
		/// <remarks>Because spontaneous callbacks may fire at an arbitrary time on an arbitrary thread, applications should take extra care when acquiring locks or mutating state inside the callback. It undefined behavior to re-entrantly call into the webgpu.h API if the callback fires while inside the callstack of another webgpu.h function that is not `wgpuInstanceWaitAny` or `wgpuInstanceProcessEvents`.</remarks>
		AllowSpontaneous,
	}
}
