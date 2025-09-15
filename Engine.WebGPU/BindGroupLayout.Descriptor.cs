using System.Runtime.InteropServices;
using Engine.Shared;
using wgpu.Enums;
using wgpu.Flags;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Describes a bind group layout.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BindGroupLayoutDescriptor
	{
		/// <summary>
		/// Gets or sets a pointer to the next structure in the chain of descriptors.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or sets a string view representing the label for this bind group layout descriptor.
		/// </summary>
		public StringView Label { get; init; }

		private readonly nint entryCount;

		private readonly Pointer<BindGroupLayoutEntry> entries;

		/// <summary>
		/// Gets or sets the span of entries that define the layout of the bind group.
		/// </summary>
		public unsafe System.ReadOnlySpan<BindGroupLayoutEntry> Entries
		{
			get => new(this.entries, (int)this.entryCount);
			init
			{
				this.entryCount = value.Length;
				this.entries = value;
			}
		}
	}

	/// <summary>
	/// Represents an entry in a bind group layout.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BindGroupLayoutEntry
	{
		/// <summary>
		/// Gets or sets a pointer to the next structure in the chain of descriptors.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or sets the binding index for a resource in a bind group layout entry.
		/// </summary>
		public uint Binding { get; init; }

		/// <summary>
		/// Specifies the shader stages that can access resources bound through this entry.
		/// </summary>
		public ShaderStage Visibility { get; init; }

		/// <summary>
		/// Gets or sets the buffer binding layout for this entry.
		/// </summary>
		public BufferBindingLayout Buffer { get; init; }

		/// <summary>
		/// Specifies the layout configuration for a sampler in a bind group.
		/// </summary>
		public SamplerBindingLayout Sampler { get; init; }

		/// <summary>
		/// Gets or sets the texture binding layout for this entry.
		/// </summary>
		public TextureBindingLayout Texture { get; init; }

		/// <summary>
		/// Gets or sets the storage texture binding layout.
		/// </summary>
		public StorageTextureBindingLayout StorageTexture { get; init; }
	}

	/// <summary>
	/// Describes the layout of a buffer binding.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BufferBindingLayout
	{
		/// <summary>
		/// Gets or sets a pointer to the next structure in the chain of descriptors.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Specifies the type of buffer binding layout.
		/// </summary>
		public BufferBindingType Type { get; init; }

		/// <summary>
		/// Gets or sets a value indicating whether the buffer binding has a dynamic offset.
		/// </summary>
		public NativeBool HasDynamicOffset { get; init; }

		/// <summary>
		/// Gets or sets the minimum size of the buffer binding.
		/// </summary>
		public ulong MinBindingSize { get; init; }
	}

	/// <summary>
	/// Represents the layout of a sampler binding.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct SamplerBindingLayout
	{
		/// <summary>
		/// Gets or sets a pointer to the next structure in the chain of descriptors.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or sets the type of sampler binding.
		/// </summary>
		public SamplerBindingType Type { get; init; }
	}

	/// <summary>
	/// Describes the layout of a texture binding.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct TextureBindingLayout
	{
		/// <summary>
		/// Gets or sets a pointer to the next structure in the chain of descriptors.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Specifies the sample type of the texture.
		/// </summary>
		public TextureSampleType SampleType { get; init; }

		/// <summary>
		/// Specifies the dimension of a texture view.
		/// </summary>
		public TextureViewDimension ViewDimension { get; init; }

		/// <summary>
		/// Gets or sets a value indicating whether the texture binding is multisampled.
		/// </summary>
		public NativeBool Multisampled { get; init; }
	}

	/// <summary>
	/// Describes the layout of a storage texture binding.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct StorageTextureBindingLayout
	{
		/// <summary>
		/// Gets or sets a pointer to the next structure in the chain of descriptors.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or sets the access mode for the storage texture binding.
		/// </summary>
		public StorageTextureAccess Access { get; init; }

		/// <summary>
		/// Gets or sets the texture format for the storage texture binding.
		/// </summary>
		public TextureFormat Format { get; init; }

		/// <summary>
		/// Specifies the dimensions of a texture view.
		/// </summary>
		public TextureViewDimension ViewDimension { get; init; }
	}
}
