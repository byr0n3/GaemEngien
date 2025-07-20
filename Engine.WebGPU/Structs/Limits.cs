using System.Runtime.InteropServices;
using Engine.Native;

namespace wgpu.Structs
{
	/// <summary>
	/// Represents the limits of an adapter or a device.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Limits
	{
		/// <summary>
		/// A <see cref="Limits"/> instance having all its properties set to `undefined`/`no preference`.
		/// </summary>
		public static readonly Limits Default = new()
		{
			MaxTextureDimension1D = uint.MaxValue,
			MaxTextureDimension2D = uint.MaxValue,
			MaxTextureDimension3D = uint.MaxValue,
			MaxTextureArrayLayers = uint.MaxValue,
			MaxBindGroups = uint.MaxValue,
			MaxBindGroupsPlusVertexBuffers = uint.MaxValue,
			MaxBindingsPerBindGroup = uint.MaxValue,
			MaxDynamicUniformBuffersPerPipelineLayout = uint.MaxValue,
			MaxDynamicStorageBuffersPerPipelineLayout = uint.MaxValue,
			MaxSampledTexturesPerShaderStage = uint.MaxValue,
			MaxSamplersPerShaderStage = uint.MaxValue,
			MaxStorageBuffersPerShaderStage = uint.MaxValue,
			MaxStorageTexturesPerShaderStage = uint.MaxValue,
			MaxUniformBuffersPerShaderStage = uint.MaxValue,
			MaxUniformBufferBindingSize = ulong.MaxValue,
			MaxStorageBufferBindingSize = ulong.MaxValue,
			MinUniformBufferOffsetAlignment = uint.MaxValue,
			MinStorageBufferOffsetAlignment = uint.MaxValue,
			MaxVertexBuffers = uint.MaxValue,
			MaxBufferSize = ulong.MaxValue,
			MaxVertexAttributes = uint.MaxValue,
			MaxVertexBufferArrayStride = uint.MaxValue,
			MaxInterStageShaderVariables = uint.MaxValue,
			MaxColorAttachments = uint.MaxValue,
			MaxColorAttachmentBytesPerSample = uint.MaxValue,
			MaxComputeWorkgroupStorageSize = uint.MaxValue,
			MaxComputeInvocationsPerWorkgroup = uint.MaxValue,
			MaxComputeWorkgroupSizeX = uint.MaxValue,
			MaxComputeWorkgroupSizeY = uint.MaxValue,
			MaxComputeWorkgroupSizeZ = uint.MaxValue,
			MaxComputeWorkgroupsPerDimension = uint.MaxValue,
		};

		/// <summary>
		/// Gets or initializes the pointer to the next structure in a chain.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes the maximum size of a 1D texture dimension.
		/// </summary>
		public required uint MaxTextureDimension1D { get; init; }

		/// <summary>
		/// Gets or initializes the maximum size of a 2D texture dimension supported by the GPU device.
		/// </summary>
		public required uint MaxTextureDimension2D { get; init; }

		/// <summary>
		/// Gets the maximum size of a 3D texture that can be used by the GPU device.
		/// </summary>
		public required uint MaxTextureDimension3D { get; init; }

		/// <summary>
		/// Gets or initializes the maximum number of layers in a texture array.
		/// </summary>
		public required uint MaxTextureArrayLayers { get; init; }

		/// <summary>
		/// Gets or initializes the maximum number of bind groups supported by the GPU device.
		/// </summary>
		public required uint MaxBindGroups { get; init; }

		/// <summary>
		/// Gets or initializes the maximum number of bind groups plus vertex buffers supported by the GPU device.
		/// </summary>
		public required uint MaxBindGroupsPlusVertexBuffers { get; init; }

		/// <summary>
		/// Gets the maximum number of bindings per bind group.
		/// </summary>
		public required uint MaxBindingsPerBindGroup { get; init; }

		/// <summary>
		/// Gets the maximum number of dynamic uniform buffers per pipeline layout.
		/// </summary>
		public required uint MaxDynamicUniformBuffersPerPipelineLayout { get; init; }

		/// <summary>
		/// Gets or initializes the maximum number of dynamic storage buffers per pipeline layout.
		/// </summary>
		public required uint MaxDynamicStorageBuffersPerPipelineLayout { get; init; }

		/// <summary>
		/// Gets or initializes the maximum number of sampled textures that can be used per shader stage.
		/// </summary>
		public required uint MaxSampledTexturesPerShaderStage { get; init; }

		/// <summary>
		/// Gets or initializes the maximum number of samplers allowed per shader stage.
		/// </summary>
		public required uint MaxSamplersPerShaderStage { get; init; }

		/// <summary>
		/// Gets or initializes the maximum number of storage buffers per shader stage.
		/// </summary>
		public required uint MaxStorageBuffersPerShaderStage { get; init; }

		/// <summary>
		/// Gets or initializes the maximum number of storage textures per shader stage.
		/// </summary>
		public required uint MaxStorageTexturesPerShaderStage { get; init; }

		/// <summary>
		/// Gets the maximum number of uniform buffers allowed per shader stage.
		/// </summary>
		public required uint MaxUniformBuffersPerShaderStage { get; init; }

		/// <summary>
		/// Gets or initializes the maximum size of a uniform buffer binding.
		/// </summary>
		public required ulong MaxUniformBufferBindingSize { get; init; }

		/// <summary>
		/// Gets or initializes the maximum size in bytes of a storage buffer binding.
		/// </summary>
		public required ulong MaxStorageBufferBindingSize { get; init; }

		/// <summary>
		/// Gets or initializes the minimum alignment for uniform buffer offsets.
		/// </summary>
		public required uint MinUniformBufferOffsetAlignment { get; init; }

		/// <summary>
		/// Gets the minimum offset alignment required for storage buffers.
		/// </summary>
		public required uint MinStorageBufferOffsetAlignment { get; init; }

		/// <summary>
		/// Gets the maximum number of vertex buffers that can be used in a pipeline.
		/// </summary>
		public required uint MaxVertexBuffers { get; init; }

		/// <summary>
		/// Gets or initializes the maximum size of a buffer in bytes.
		/// </summary>
		public required ulong MaxBufferSize { get; init; }

		/// <summary>
		/// Gets the maximum number of vertex attributes that can be used in a single draw call.
		/// </summary>
		public required uint MaxVertexAttributes { get; init; }

		/// <summary>
		/// Gets or initializes the maximum stride of a vertex buffer array.
		/// </summary>
		public required uint MaxVertexBufferArrayStride { get; init; }

		/// <summary>
		/// Gets or initializes the maximum number of inter-stage shader variables.
		/// </summary>
		public required uint MaxInterStageShaderVariables { get; init; }

		/// <summary>
		/// Gets the maximum number of color attachments that can be used in a render pass.
		/// </summary>
		public required uint MaxColorAttachments { get; init; }

		/// <summary>
		/// Gets or initializes the maximum number of bytes per sample for color attachments.
		/// </summary>
		public required uint MaxColorAttachmentBytesPerSample { get; init; }

		/// <summary>
		/// Gets or initializes the maximum size of compute workgroup storage in bytes.
		/// </summary>
		public required uint MaxComputeWorkgroupStorageSize { get; init; }

		/// <summary>
		/// Gets or initializes the maximum number of compute function invocations per workgroup.
		/// </summary>
		public required uint MaxComputeInvocationsPerWorkgroup { get; init; }

		/// <summary>
		/// Gets or initializes the maximum size of a compute workgroup in the X dimension.
		/// </summary>
		public required uint MaxComputeWorkgroupSizeX { get; init; }

		/// <summary>
		/// Gets or initializes the maximum size of a compute workgroup in the Y dimension.
		/// </summary>
		public required uint MaxComputeWorkgroupSizeY { get; init; }

		/// <summary>
		/// Gets or initializes the maximum size of a compute workgroup in the Z dimension.
		/// </summary>
		public required uint MaxComputeWorkgroupSizeZ { get; init; }

		/// <summary>
		/// Gets the maximum number of compute workgroups that can be dispatched in a single dimension.
		/// </summary>
		public required uint MaxComputeWorkgroupsPerDimension { get; init; }
	}
}
