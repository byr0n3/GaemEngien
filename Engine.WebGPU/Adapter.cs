using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using wgpu.Enums;
using wgpu.Internal.Enums;
using wgpu.Internal.Structs;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents a hardware adapter used to request devices for rendering.
	/// </summary>
	[MustDisposeResource]
	public readonly struct Adapter : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Gets a value indicating whether the current instance is valid.
		/// </summary>
		public bool IsValid =>
			this.handle != default;

		/// <summary>
		/// Gets the limits of this adapter.
		/// </summary>
		public Limits Limits
		{
			get
			{
				Limits limits = default;

				var status = AdapterNative.GetLimits(this, limits);

				Debug.Assert(status == Status.Success);

				return limits;
			}
		}

		/// <summary>
		/// Requests a new device from the adapter using the provided descriptor.
		/// </summary>
		/// <param name="descriptor">The descriptor specifying the configuration for the requested device.</param>
		/// <returns>A new instance of the <see cref="Device"/> class representing the requested device.</returns>
		[MustDisposeResource]
		public unsafe Device RequestDevice(in DeviceDescriptor descriptor)
		{
			Debug.Assert(this.IsValid);

			Device result = default;

			fixed (DeviceDescriptor* descriptorPtr = &descriptor)
			{
				var callbackInfo = new RequestCallbackInfo<Device>
				{
					Callback = &Handler,
					UserData1 = &result,
				};

				_ = AdapterNative.RequestDevice(this, descriptorPtr, callbackInfo);
			}

			Debug.Assert(result.IsValid, "Failed to receive a valid device in time");

			return result;

			[UnmanagedCallersOnly]
			static void Handler(RequestStatus status, Device adapter, StringView message, void* userData1, void* _)
			{
				if (status == RequestStatus.Success)
				{
					Unsafe.AsRef<Device>(userData1) = adapter;
				}
				else
				{
					Debug.Fail($"wgpuAdapterRequestDevice failed: {status.ToString()}", message.ToString());
				}
			}
		}

		/// <summary>
		/// Releases all resources used by this instance.
		/// </summary>
		public void Dispose() =>
			AdapterNative.Release(this);
	}
}
