using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Engine;
using Engine.Enums;
using glfw;
using glfw.Enums;
using JetBrains.Annotations;
using wgpu;
using wgpu.Enums;
using wgpu.Flags;
using wgpu.Structs;

const int windowWidth = 1280;
const int windowHeight = 960;

System.ReadOnlySpan<float> pointData =
[
	// x    y      z     nx    ny     nz    r     g     b
	-0.5f, -0.5f, -0.3f, 0.0f, -1.0f, 0.0f, 1.0f, 1.0f, 1.0f,
	+0.5f, -0.5f, -0.3f, 0.0f, -1.0f, 0.0f, 1.0f, 1.0f, 1.0f,
	+0.5f, +0.5f, -0.3f, 0.0f, -1.0f, 0.0f, 1.0f, 1.0f, 1.0f,
	-0.5f, +0.5f, -0.3f, 0.0f, -1.0f, 0.0f, 1.0f, 1.0f, 1.0f,

	-0.5f, -0.5f, -0.3f, 0.0f, -0.848f, 0.53f, 1.0f, 1.0f, 1.0f,
	+0.5f, -0.5f, -0.3f, 0.0f, -0.848f, 0.53f, 1.0f, 1.0f, 1.0f,
	+0.0f, +0.0f, +0.5f, 0.0f, -0.848f, 0.53f, 1.0f, 1.0f, 1.0f,

	+0.5f, -0.5f, -0.3f, 0.848f, 0.0f, 0.53f, 1.0f, 1.0f, 1.0f,
	+0.5f, +0.5f, -0.3f, 0.848f, 0.0f, 0.53f, 1.0f, 1.0f, 1.0f,
	+0.0f, +0.0f, +0.5f, 0.848f, 0.0f, 0.53f, 1.0f, 1.0f, 1.0f,

	+0.5f, +0.5f, -0.3f, 0.0f, 0.848f, 0.53f, 1.0f, 1.0f, 1.0f,
	-0.5f, +0.5f, -0.3f, 0.0f, 0.848f, 0.53f, 1.0f, 1.0f, 1.0f,
	+0.0f, +0.0f, +0.5f, 0.0f, 0.848f, 0.53f, 1.0f, 1.0f, 1.0f,

	-0.5f, +0.5f, -0.3f, -0.848f, 0.0f, 0.53f, 1.0f, 1.0f, 1.0f,
	-0.5f, -0.5f, -0.3f, -0.848f, 0.0f, 0.53f, 1.0f, 1.0f, 1.0f,
	+0.0f, +0.0f, +0.5f, -0.848f, 0.0f, 0.53f, 1.0f, 1.0f, 1.0f,
];

System.ReadOnlySpan<ushort> indexData =
[
	// Base
	0, 1, 2,
	0, 2, 3,
	// Sides
	4, 5, 6,
	7, 8, 9,
	10, 11, 12,
	13, 14, 15,
];

var indexCount = (uint)indexData.Length;

GLFW.OnError += OnGlfwError;

if (!GLFW.Initialize())
{
	return 1;
}

var modelScale = Matrix4x4.CreateScale(new Vector3(0.3f));
var modelTranslation = Matrix4x4.CreateTranslation(new Vector3(0.0f, 0.0f, 0.0f));
var modelRotation = Matrix4x4.CreateRotationZ(2.0f);
var modelMatrix = modelRotation * modelTranslation * modelScale;

var viewRotation = Matrix4x4.CreateRotationX(-3.0f * float.Pi / 4.0f);
var viewTranslation = Matrix4x4.CreateTranslation(new Vector3(0.0f, 0.0f, 1.0f));
var viewMatrix = viewRotation * viewTranslation;

const float ratio = windowWidth / (float)windowHeight;
const float near = 0.01f;
const float far = 100.0f;
const float fov = 45f * float.Pi / 180f;
var projectionMatrix = Matrix4x4.CreatePerspectiveFieldOfViewLeftHanded(fov, ratio, near, far);

var uniforms = new UniformValues
{
	ProjectionMatrix = projectionMatrix,
	ViewMatrix = viewMatrix,
	ModelMatrix = modelMatrix,
	Color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f),
	Time = 1f,
};

var window = new Window(new WindowDescriptor
{
	Width = windowWidth,
	Height = windowHeight,
	Title = "Engine Sample\0"u8,
	Hints = new WindowHints
	{
		Api = ClientApi.NoApi,
		Resizable = false,
	},
});

Debug.Assert(window.IsValid);

var instance = new Instance();

Debug.Assert(instance.IsValid);

var surface = CreateSurface(instance, window);

Debug.Assert(surface.IsValid);

var adapter = instance.RequestAdapter(new RequestAdapterOptions
{
	BackendType = BackendType.Metal,
	CompatibleSurface = surface,
});

Debug.Assert(adapter.IsValid);

var device = adapter.RequestDevice(new DeviceDescriptor
{
	Label = "Render Device"u8,
	RequiredLimits = GetRequiredLimits(adapter),
	DefaultQueue = new BasicDescriptor
	{
		Label = "Render Device Queue"u8,
	},
});

Debug.Assert(device.IsValid);

instance.Dispose();

var queue = device.Queue;

Debug.Assert(queue.IsValid);

var capabilities = surface.GetCapabilities(adapter);

var windowSize = window.Size;

var surfaceConfiguration = new SurfaceConfiguration
{
	Device = device,

	Size = windowSize,

	Format = capabilities.Formats[0],

	Usage = TextureUsage.RenderAttachment,

	PresentMode = PresentMode.Immediate,
	AlphaMode = capabilities.AlphaModes[0],
};

surface.Configure(in surfaceConfiguration);

var texture = device.CreateTexture(new TextureDescriptor
{
	Format = TextureFormat.RGBA8Unorm,
	Dimension = TextureDimension.TwoDimension,
	Size = new Extent3D(256, 256),
	MipLevelCount = 1,
	SampleCount = 1,
	Usage = TextureUsage.TextureBinding | TextureUsage.CopyDst,
});

var texels = new byte[4 * 256 * 256];

unsafe
{
	for (var i = 0; i < 256; i++)
	{
		for (var j = 0; j < 256; j++)
		{
			var offset = 4 * ((i * 256) + j);

			texels[offset] = (byte)i;
			texels[offset + 1] = (byte)j;
			texels[offset + 2] = 128;
			texels[offset + 3] = 255;
		}
	}

	fixed (byte* ptr = texels)
	{
		queue.WriteTexture(
			new TexelCopyTextureInfo
			{
				Texture = texture,
				MipLevel = 0,
				TextureAspect = TextureAspect.All,
			},
			ptr,
			texels.Length,
			new TexelCopyBufferLayout
			{
				BytesPerRow = 4 * 256,
				RowsPerImage = 256,
			},
			// @todo `texture.Size`
			new Extent3D(256, 256)
		);
	}
}

var textureView = texture.CreateView(new TextureViewDescriptor
{
	Aspect = TextureAspect.All,
	BaseArrayLayer = 0,
	ArrayLayerCount = 1,
	BaseMipLevel = 0,
	MipLevelCount = 1,
	Dimension = TextureViewDimension.TwoDimensions,
	Format = TextureFormat.RGBA8Unorm,
});

var uniformBuffer = device.CreateBuffer(new BufferDescriptor
{
	Label = "Uniform Buffer\0"u8,
	Usage = BufferUsage.CopyDst | BufferUsage.Uniform,
	Size = (ulong)Unsafe.SizeOf<UniformValues>(),
});

unsafe
{
	queue.WriteBuffer(uniformBuffer, 0, &uniforms, sizeof(UniformValues));
}

var shader = Shaders.LoadFromFile(device, "shaders/shader.wgsl", ShaderType.WGSL, "Base Shader"u8);

var bindGroupLayout = device.CreateBindGroupLayout(new BindGroupLayoutDescriptor
{
	Label = "Bind Group Layout\0"u8,

	Entries =
	[
		new BindGroupLayoutEntry
		{
			Binding = 0,
			Visibility = ShaderStage.Vertex | ShaderStage.Fragment,

			Buffer = new BufferBindingLayout
			{
				Type = BufferBindingType.Uniform,
				MinBindingSize = (ulong)Unsafe.SizeOf<UniformValues>(),
			},

			Sampler = new SamplerBindingLayout
			{
				Type = SamplerBindingType.BindingNotUsed,
			},

			StorageTexture = new StorageTextureBindingLayout
			{
				Access = StorageTextureAccess.BindingNotUsed,
			},

			Texture = new TextureBindingLayout
			{
				SampleType = TextureSampleType.BindingNotUsed,
			},
		},

		new BindGroupLayoutEntry
		{
			Binding = 1,
			Visibility = ShaderStage.Fragment,

			Buffer = new BufferBindingLayout
			{
				Type = BufferBindingType.BindingNotUsed,
			},

			Sampler = new SamplerBindingLayout
			{
				Type = SamplerBindingType.BindingNotUsed,
			},

			StorageTexture = new StorageTextureBindingLayout
			{
				Access = StorageTextureAccess.BindingNotUsed,
			},

			Texture = new TextureBindingLayout
			{
				SampleType = TextureSampleType.Float,
				ViewDimension = TextureViewDimension.TwoDimensions,
			},
		},
	],
});

var bindGroup = device.CreateBindGroup(new BindGroupDescriptor
{
	Label = "Bind Group\0"u8,

	Layout = bindGroupLayout,
	Entries =
	[
		new BindGroupEntry
		{
			Binding = 0,
			Buffer = uniformBuffer,
			Offset = 0,
			Size = (ulong)Unsafe.SizeOf<UniformValues>(),
		},

		new BindGroupEntry
		{
			Binding = 1,
			TextureView = textureView,
		},
	],
});

var pipelineLayout = device.CreatePipelineLayout(new PipelineLayoutDescriptor
{
	Label = "Pipeline Layout\0"u8,

	BindGroupLayouts = [bindGroupLayout],
});

var pipeline = device.CreateRenderPipeline(new RenderPipelineDescriptor
{
	Label = "Main Render Pipeline\0"u8,

	Vertex = new VertexState
	{
		Module = shader,
		EntryPoint = "vs_main"u8,

		Buffers =
		[
			new VertexBufferLayout
			{
				Attributes =
				[
					new VertexAttribute
					{
						ShaderLocation = 0,
						Offset = 0,
						Format = VertexFormat.Float32x3,
					},
					new VertexAttribute
					{
						ShaderLocation = 1,
						Offset = 3 * sizeof(float),
						Format = VertexFormat.Float32x3,
					},
					new VertexAttribute
					{
						ShaderLocation = 2,
						Offset = 6 * sizeof(float),
						Format = VertexFormat.Float32x3,
					},
				],

				ArrayStride = 3 * 3 * sizeof(float),
				StepMode = VertexStepMode.Vertex,
			},
		],
	},

	Fragment = new FragmentState
	{
		Module = shader,
		EntryPoint = "fs_main"u8,

		Targets =
		[
			new ColorTargetState
			{
				Format = capabilities.Formats[0],
				Blend = new BlendState
				{
					Color = new BlendState.Component
					{
						SrcFactor = BlendFactor.SrcAlpha,
						DstFactor = BlendFactor.OneMinusSrcAlpha,
						Operation = BlendOperation.Add,
					},

					Alpha = new BlendState.Component
					{
						SrcFactor = BlendFactor.Zero,
						DstFactor = BlendFactor.One,
						Operation = BlendOperation.Add,
					},
				},
				WriteMask = ColorWriteMask.All,
			},
		],
	},

	Primitive = new PrimitiveState
	{
		Topology = PrimitiveTopology.TriangleList,
		StripIndexFormat = IndexFormat.Undefined,
		FrontFace = FrontFace.CounterClockWise,
		CullMode = CullMode.None,
	},

	Layout = pipelineLayout,

	Multisample = new MultisampleState
	{
		Count = 1,
		Mask = ~0u,
		AlphaToCoverageEnabled = false,
	},

	DepthStencil = new DepthStencilState
	{
		Format = TextureFormat.Depth24Plus,
		// Enable writing to the depth buffer (a.k.a enabling depth testing).
		DepthWriteEnabled = OptionalBool.True,
		// A fragment is only blended if its depth is LESS than the current value of the Z-buffer.
		DepthCompare = CompareFunction.Less,
		// Disable stencil settings (for now).
		StencilWriteMask = 0,
		StencilReadMask = 0,
		DepthBias = 0,
		DepthBiasSlopeScale = 0,
		DepthBiasClamp = 0,
		StencilFront = new StencilFaceState
		{
			Compare = CompareFunction.Always,
			FailOperation = StencilOperation.Keep,
			DepthFailOperation = StencilOperation.Keep,
			PassOperation = StencilOperation.Keep,
		},
		StencilBack = new StencilFaceState
		{
			Compare = CompareFunction.Always,
			FailOperation = StencilOperation.Keep,
			DepthFailOperation = StencilOperation.Keep,
			PassOperation = StencilOperation.Keep,
		},
	},
});

shader.Dispose();

capabilities.Dispose();

adapter.Dispose();

var depthTexture = device.CreateTexture(new TextureDescriptor
{
	Dimension = TextureDimension.TwoDimension,
	Format = TextureFormat.Depth24Plus,
	MipLevelCount = 1,
	SampleCount = 1,
	Size = new Extent3D
	{
		Width = windowWidth,
		Height = windowHeight,
		DepthOrArrayLayers = 1,
	},
	Usage = TextureUsage.RenderAttachment,
	ViewFormats = [TextureFormat.Depth24Plus],
});

var depthTextureView = depthTexture.CreateView(new TextureViewDescriptor
{
	Aspect = TextureAspect.DepthOnly,
	BaseArrayLayer = 0,
	ArrayLayerCount = 1,
	BaseMipLevel = 0,
	MipLevelCount = 1,
	Dimension = TextureViewDimension.TwoDimensions,
	Format = TextureFormat.Depth24Plus,
});

var pointBuffer = device.CreateBuffer(new BufferDescriptor
{
	Label = "Point Buffer\0"u8,
	Usage = BufferUsage.CopyDst | BufferUsage.Vertex,
	Size = (ulong)(pointData.Length * sizeof(float)),
});

queue.WriteBuffer(pointBuffer, 0, pointData);

var indexBuffer = device.CreateBuffer(new BufferDescriptor
{
	Label = "Index Buffer\0"u8,
	Usage = BufferUsage.CopyDst | BufferUsage.Index,
	Size = (ulong)(((indexData.Length * sizeof(ushort)) + 3) & ~3),
});

queue.WriteBuffer(indexBuffer, 0, indexData);

var clearColor = new ColorD(0.05, 0.05, 0.05);

while (!window.ShouldClose)
{
	GLFW.PollEvents();

	var currentTime = (float)GLFW.Time;
	var deltaTime = currentTime - uniforms.Time;

	var colorBase = float.Sin(currentTime) / 2.0f;

	var modelMatrix2 = Matrix4x4.CreateRotationZ(currentTime) * modelTranslation * modelScale;
	var color = uniforms.Color with
	{
		X = colorBase + 0.375f,
		Y = colorBase + 0.5f,
		Z = colorBase + 0.625f,
	};

	uniforms.ModelMatrix = modelMatrix2;
	uniforms.Color = color;
	uniforms.Time = currentTime;

	unsafe
	{
		var modelMatrixOffset = (ulong)(sizeof(Matrix4x4) * 2);
		var colorOffset = modelMatrixOffset + (ulong)sizeof(Matrix4x4);
		var timeOffset = colorOffset + (ulong)sizeof(Vector3);

		queue.WriteBuffer(uniformBuffer, modelMatrixOffset, &modelMatrix2, sizeof(Matrix4x4));
		queue.WriteBuffer(uniformBuffer, colorOffset, &color, sizeof(Vector3));
		queue.WriteBuffer(uniformBuffer, timeOffset, &currentTime, sizeof(float));
	}

	var surfaceTexture = surface.CurrentTexture;

	switch (surfaceTexture.Status)
	{
		case SurfaceGetCurrentTextureStatus.SuccessOptimal:
		case SurfaceGetCurrentTextureStatus.SuccessSuboptimal:
			break;

		case SurfaceGetCurrentTextureStatus.Timeout:
		case SurfaceGetCurrentTextureStatus.Outdated:
		case SurfaceGetCurrentTextureStatus.Lost:
		{
			// @todo Handle
			break;
		}

		case SurfaceGetCurrentTextureStatus.OutOfMemory:
		case SurfaceGetCurrentTextureStatus.DeviceLost:
		default:
			Debug.Fail($"{surfaceTexture.Status}");
			break;
	}

	var targetView = surfaceTexture.Texture.CreateView(new TextureViewDescriptor
	{
		Label = "Surface Texture View"u8,
		Format = surfaceTexture.Texture.Format,
		Dimension = TextureViewDimension.TwoDimensions,
		BaseMipLevel = 0,
		MipLevelCount = 1,
		BaseArrayLayer = 0,
		ArrayLayerCount = 1,
		Aspect = TextureAspect.All,
	});

	var encoder = device.CreateCommandEncoder(new BasicDescriptor
	{
		Label = "Render Command Encoder"u8,
	});

	var renderPassEncoder = encoder.BeginRenderPass(new RenderPassEncoderDescriptor
	{
		Label = "Render Pass"u8,
		ColorAttachments =
		[
			new RenderPassColorAttachment
			{
				View = targetView,
				LoadOperation = LoadOperation.Clear,
				StoreOperation = StoreOperation.Store,
				DepthSlice = -1,
				ClearColor = clearColor,
			},
		],

		DepthStencilAttachment = new RenderPassDepthStencilAttachment
		{
			// The texture view the depth buffer should get written to.
			View = depthTextureView,
			// The initial value of the depth buffer, '1f' meaning 'far'.
			DepthClearValue = 1f,
			DepthLoadOperatin = LoadOperation.Clear,
			DepthStoreOperation = StoreOperation.Store,
			// Switch to disable writing to the depth buffer all together.
			DepthReadOnly = false,

			// We don't use stencils (yet).
			StencilClearValue = 0,
			StencilLoadOperation = LoadOperation.Clear,
			StencilStoreOperation = StoreOperation.Store,
			StencilReadOnly = true,
		},
	});

	renderPassEncoder.SetPipeline(pipeline);

	renderPassEncoder.SetVertexBuffer(0, pointBuffer);
	renderPassEncoder.SetIndexBuffer(indexBuffer, IndexFormat.Uint16);

	renderPassEncoder.SetBindGroup(0, bindGroup, 0, null);

	renderPassEncoder.DrawIndexed(indexCount, 1, 0, 0, 0);

	renderPassEncoder.End();
	renderPassEncoder.Dispose();

	var command = encoder.Finish(new BasicDescriptor
	{
		Label = "Command Buffer"u8,
	});

	queue.Submit(command);
	surface.Present();

	command.Dispose();
	encoder.Dispose();
	targetView.Dispose();
	surfaceTexture.Texture.Dispose();

	device.Poll(false, default);
}

texture.Dispose();
textureView.Dispose();

uniformBuffer.Dispose();

pointBuffer.Dispose();

indexBuffer.Dispose();

depthTextureView.Dispose();
depthTexture.Dispose();

pipeline.Dispose();

pipelineLayout.Dispose();

bindGroup.Dispose();

bindGroupLayout.Dispose();

// `Queue` will get disposed by the device.
device.Dispose();

surface.Dispose();

window.Dispose();

GLFW.Terminate();

return default;

static void OnGlfwError(ErrorCode errorCode, NativeString description)
{
	System.Console.Error.WriteLine($"[GLFW] Error {errorCode.ToString()}");

	if (description.ReadOnlySpan.Length != 0)
	{
		System.Console.Error.WriteLine(description.ToString());
	}
}

[MustDisposeResource]
static Surface CreateSurface(Instance instance, Window window)
{
	if (System.OperatingSystem.IsMacOS())
	{
		var layer = new SurfaceSourceMetalLayerDescriptor
		{
			Chain = new ChainedStruct(SType.SurfaceSourceMetalLayer),
			Layer = window.MetalLayer,
		};

		return instance.CreateSurface(new BasicDescriptor
		{
			NextInChain = layer,
			Label = "Metal Surface"u8,
		});
	}

	throw new System.PlatformNotSupportedException();
}

static Limits GetRequiredLimits(Adapter adapter)
{
	var limits = adapter.Limits;

	return Limits.Default with
	{
		MinUniformBufferOffsetAlignment = limits.MinUniformBufferOffsetAlignment,
		MinStorageBufferOffsetAlignment = limits.MinStorageBufferOffsetAlignment,

		MaxBindGroups = 1,
		MaxUniformBuffersPerShaderStage = 1,
		MaxUniformBufferBindingSize = (ulong)Unsafe.SizeOf<UniformValues>(),

		MaxVertexAttributes = 3,
		MaxVertexBuffers = 2,
		MaxBufferSize = 3 * 3 * sizeof(float) * 16,
		MaxVertexBufferArrayStride = 3 * 3 * sizeof(float),
		MaxInterStageShaderVariables = 6,

		MaxTextureDimension1D = windowHeight,
		MaxTextureDimension2D = windowWidth,
		MaxTextureArrayLayers = 1,

		MaxSampledTexturesPerShaderStage = 1,
	};
}

[StructLayout(LayoutKind.Sequential)]
internal struct UniformValues
{
	public required Matrix4x4 ProjectionMatrix { get; init; }

	public required Matrix4x4 ViewMatrix { get; init; }

	public required Matrix4x4 ModelMatrix { get; set; }

	public required Vector4 Color { get; set; }

	public required float Time { get; set; }

	private readonly float offset1;
	private readonly float offset2;
	private readonly float offset3;
}
