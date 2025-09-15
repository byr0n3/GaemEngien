using System.Runtime.InteropServices;
using Engine.Shared;
using JetBrains.Annotations;
using wgpu.Enums;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents the state of a vertex shader stage in a graphics pipeline.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct VertexState
	{
		/// <summary>
		/// Gets or initializes the next structure in a chain of vertex state structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes the shader module used for vertex shading.
		/// </summary>
		public ShaderModule Module { get; init; }

		/// <summary>
		/// Gets or initializes the entry point name for the vertex shader stage in a graphics pipeline.
		/// </summary>
		public StringView EntryPoint { get; init; }

		private readonly nint constantCount;

		private readonly Pointer<ConstantEntry> constants;

		private readonly nint bufferCount;

		private readonly Pointer<VertexBufferLayout> buffers;

		/// <summary>
		/// Gets or initializes the span of vertex constants.
		/// </summary>
		public unsafe System.ReadOnlySpan<ConstantEntry> Constants
		{
			get => new(this.constants, (int)this.constantCount);
			init
			{
				this.constantCount = value.Length;
				this.constants = value;
			}
		}

		/// <summary>
		/// Gets or initializes the span of vertex buffer layouts.
		/// </summary>
		public unsafe System.ReadOnlySpan<VertexBufferLayout> Buffers
		{
			get => new(this.buffers, (int)this.bufferCount);
			init
			{
				this.bufferCount = value.Length;
				this.buffers = value;
			}
		}
	}

	/// <summary>
	/// Defines the layout of a vertex buffer, including its stride, step mode, and attributes.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct VertexBufferLayout
	{
		/// <summary>
		/// Specifies how the vertex buffer is stepped through.
		/// </summary>
		public VertexStepMode StepMode { get; init; }

		/// <summary>
		/// Gets or initializes the stride of the vertex attribute array.
		/// </summary>
		public ulong ArrayStride { get; init; }

		private readonly nint attributeCount;

		private readonly Pointer<VertexAttribute> attributes;

		/// <summary>
		/// Gets or initializes the span of vertex attributes associated with this vertex buffer layout.
		/// </summary>
		public unsafe System.ReadOnlySpan<VertexAttribute> Attributes
		{
			get => new(this.attributes, (int)this.attributeCount);
			init
			{
				this.attributeCount = value.Length;
				this.attributes = value;
			}
		}
	}

	/// <summary>
	/// Represents a vertex attribute used in the graphics pipeline, specifying format, offset, and shader location.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct VertexAttribute
	{
		/// <summary>
		/// Gets or initializes the format of the vertex attribute data.
		/// </summary>
		public VertexFormat Format { get; init; }

		/// <summary>
		/// Gets or initializes the offset in bytes from the start of each vertex buffer.
		/// </summary>
		public ulong Offset { get; init; }

		/// <summary>
		/// Gets or initializes the location of the shader attribute.
		/// </summary>
		public uint ShaderLocation { get; init; }
	}
}
