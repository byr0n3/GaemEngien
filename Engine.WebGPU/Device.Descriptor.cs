using System.Runtime.InteropServices;
using Engine.Native;
using wgpu.Enums;
using wgpu.Internal.Enums;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents a descriptor for creating a device with specific features and configurations.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct DeviceDescriptor
	{
		/// <summary>
		/// Gets or initializes the next structure in a chain of structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes a string view representing the label for this device descriptor.
		/// </summary>
		public StringView Label { get; init; }

		/// <summary>
		/// The number of required features specified by the device descriptor.
		/// </summary>
		private readonly nint requiredFeatureCount;

		/// <summary>
		/// Pointer to the array of features required by the device.
		/// </summary>
		private readonly Pointer<FeatureName> requiredFeatures;

		/// <summary>
		/// Gets or initializes the required limits for device creation.
		/// </summary>
		public Pointer<Limits> RequiredLimits { get; init; }

		/// <summary>
		/// Gets or initializes the default queue descriptor.
		/// </summary>
		public BasicDescriptor DefaultQueue { get; init; }

		/// <summary>
		/// Provides information for the callback that is invoked when a device is lost.
		/// </summary>
		public DeviceLostCallbackInfo DeviceLostCallbackInfo { get; init; }

		/// <summary>
		/// Contains information about the callback for uncaptured errors.
		/// </summary>
		public UncapturedErrorCallbackInfo UncapturedErrorCallbackInfo { get; init; }

		/// <summary>
		/// Gets or sets the required features for creating a device.
		/// </summary>
		public unsafe System.ReadOnlySpan<FeatureName> RequiredFeatures
		{
			get => new(this.requiredFeatures, (int)this.requiredFeatureCount);
			init
			{
				this.requiredFeatureCount = value.Length;
				this.requiredFeatures = value;
			}
		}
	}

	/// <summary>
	/// Represents the information required for a device lost callback, including mode and user data.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly unsafe struct DeviceLostCallbackInfo
	{
		/// <summary>
		/// Gets or initializes the pointer to the next structure in a chain of chained structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Specifies the mode for handling callbacks in asynchronous operations.
		/// </summary>
		public CallbackMode Mode { get; init; }

		/// <summary>
		/// Represents a pointer to an unmanaged function that serves as the callback for device lost events.
		/// The callback is invoked with the device, reason for loss, string view, and user data pointers when the device is lost.
		/// </summary>
		public delegate*unmanaged<Device, DeviceLostReason, StringView, void*, void*, void> Callback { get; init; }

		/// <summary>
		/// Gets or initializes custom user data associated with the device lost callback.
		/// </summary>
		public void* UserData1 { get; init; }

		/// <summary>
		/// Gets or initializes the second user-defined data pointer for custom use in the device lost callback.
		/// </summary>
		public void* UserData2 { get; init; }
	}

	/// <summary>
	/// Represents information for an uncaptured error callback in a device descriptor.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly unsafe struct UncapturedErrorCallbackInfo
	{
		/// <summary>
		/// Gets or initializes the next structure in a chain of structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Represents the callback function pointer used to handle uncaptured errors in a device descriptor.
		/// This delegate is called with parameters: a <see cref="Device"/>, an <see cref="ErrorType"/>,
		/// a <see cref="StringView"/>, and two void pointers for user data.
		/// </summary>
		public delegate*unmanaged<Device, ErrorType, StringView, void*, void*, void> Callback { get; init; }

		/// <summary>
		/// Represents a pointer to user data for an uncaptured error callback.
		/// </summary>
		public void* UserData1 { get; init; }

		/// <summary>
		/// Gets or initializes the second user-defined data pointer for uncaptured error callback information.
		/// </summary>
		public void* UserData2 { get; init; }
	}
}
