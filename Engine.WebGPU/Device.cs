using JetBrains.Annotations;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents a GPU device that can create and manage various GPU resources such as buffers,
	/// pipelines, and command encoders.
	/// </summary>
	[MustDisposeResource]
	public readonly struct Device : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Gets a value indicating whether the device handle is valid.
		/// </summary>
		public bool IsValid =>
			this.handle != default;

		/// <summary>
		/// Gets the queue associated with this device.
		/// </summary>
		public Queue Queue =>
			DeviceNative.GetQueue(this);

		/// <summary>
		/// Creates a new command encoder.
		/// </summary>
		/// <returns>A newly created <see cref="CommandEncoder"/>.</returns>
		[MustDisposeResource]
		public CommandEncoder CreateCommandEncoder() =>
			DeviceNative.CreateCommandEncoder(this, null);

		/// <summary>
		/// Creates a new command encoder using the specified descriptor.
		/// </summary>
		/// <param name="descriptor">The descriptor to use for creating the command encoder.</param>
		/// <returns>A newly created <see cref="CommandEncoder"/>.</returns>
		[MustDisposeResource]
		public CommandEncoder CreateCommandEncoder(in BasicDescriptor descriptor) =>
			DeviceNative.CreateCommandEncoder(this, descriptor);

		/// <summary>
		/// Creates a new render pipeline based on the specified descriptor.
		/// </summary>
		/// <param name="descriptor">The descriptor containing configuration options for the render pipeline.</param>
		/// <returns>A newly created <see cref="RenderPipeline"/>.</returns>
		[MustDisposeResource]
		public RenderPipeline CreateRenderPipeline(in RenderPipelineDescriptor descriptor) =>
			DeviceNative.CreateRenderPipeline(this, descriptor);

		/// <summary>
		/// Creates a new shader module using the specified descriptor.
		/// </summary>
		/// <param name="descriptor">The descriptor that defines the shader module.</param>
		/// <returns>A newly created <see cref="ShaderModule"/>.</returns>
		[MustDisposeResource]
		public ShaderModule CreateShaderModule(in BasicDescriptor descriptor) =>
			DeviceNative.CreateShaderModule(this, descriptor);

		/// <summary>
		/// Creates a new GPU buffer.
		/// </summary>
		/// <param name="descriptor">The descriptor defining the properties of the buffer to create.</param>
		/// <returns>A newly created <see cref="GpuBuffer"/>.</returns>
		[MustDisposeResource]
		public GpuBuffer CreateBuffer(in BufferDescriptor descriptor) =>
			DeviceNative.CreateBuffer(this, descriptor);

		/// <summary>
		/// Creates a new bind group layout.
		/// </summary>
		/// <param name="descriptor">The descriptor containing the details for the bind group layout.</param>
		/// <returns>A newly created <see cref="BindGroupLayout"/>.</returns>
		[MustDisposeResource]
		public BindGroupLayout CreateBindGroupLayout(in BindGroupLayoutDescriptor descriptor) =>
			DeviceNative.CreateBindGroupLayout(this, descriptor);

		/// <summary>
		/// Creates a new pipeline layout.
		/// </summary>
		/// <param name="descriptor">The descriptor containing the configuration for the pipeline layout.</param>
		/// <returns>A newly created <see cref="PipelineLayout"/>.</returns>
		[MustDisposeResource]
		public PipelineLayout CreatePipelineLayout(in PipelineLayoutDescriptor descriptor) =>
			DeviceNative.CreatePipelineLayout(this, descriptor);

		/// <summary>
		/// Creates a new bind group.
		/// </summary>
		/// <param name="descriptor">The descriptor containing the configuration for creating the bind group.</param>
		/// <returns>A newly created <see cref="BindGroup"/>.</returns>
		[MustDisposeResource]
		public BindGroup CreateBindGroup(in BindGroupDescriptor descriptor) =>
			DeviceNative.CreateBindGroup(this, descriptor);

		[MustDisposeResource]
		public Texture CreateTexture(in TextureDescriptor descriptor) =>
			DeviceNative.CreateTexture(this, descriptor);

		/// <summary>
		/// Polls the device for completion of work.
		/// </summary>
		/// <param name="wait">Whether to wait for completion or not.</param>
		/// <param name="submissionIndex">The index of the submission to poll.</param>
		/// <returns>True if the command encoder has been signaled; otherwise, false.</returns>
		public bool Poll(bool wait, ulong submissionIndex) =>
			DeviceNative.Poll(this, wait, submissionIndex);

		/// <summary>
		/// Releases the resources used by this device.
		/// </summary>
		public void Dispose()
		{
			this.Queue.Dispose();

			DeviceNative.Release(this);
		}
	}
}
