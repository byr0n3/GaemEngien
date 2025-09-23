using System.Diagnostics;
using System.Runtime.CompilerServices;
using Engine.Shared;
using Engine.OpenGL.Enums;
using glfw;

// Meant to be an internal class, but not all functionality has been fully implemented by the engine yet.
#pragma warning disable CS1591

[assembly: DisableRuntimeMarshalling]

namespace Engine.OpenGL
{
	public static class GL
	{
		private static readonly unsafe delegate*unmanaged<ErrorFlag> getError;
		private static readonly unsafe delegate*unmanaged<Capability, void> enable;
		private static readonly unsafe delegate*unmanaged<int, int, int, int, void> viewport;
		private static readonly unsafe delegate*unmanaged<float, float, float, float, void> clearColor;
		private static readonly unsafe delegate*unmanaged<ClearBuffer, void> clear;
		private static readonly unsafe delegate*unmanaged<int, uint*, void> genBuffers;
		private static readonly unsafe delegate*unmanaged<BufferTarget, uint, void> bindBuffer;
		private static readonly unsafe delegate*unmanaged<BufferTarget, nint, void*, BufferUsage, void> bufferData;
		private static readonly unsafe delegate*unmanaged<BufferTarget, int, nint, void*, void> bufferSubData;
		private static readonly unsafe delegate*unmanaged<ShaderType, uint> createShader;
		private static readonly unsafe delegate*unmanaged<uint, nint, NativeString*, int*, void> shaderSource;
		private static readonly unsafe delegate*unmanaged<uint, ShaderIvParameter, int*, void> getShaderIv;
		private static readonly unsafe delegate*unmanaged<uint, int, int*, byte*, void> getShaderInfoLog;
		private static readonly unsafe delegate*unmanaged<uint, void> compileShader;
		private static readonly unsafe delegate*unmanaged<uint, void> deleteShader;
		private static readonly unsafe delegate*unmanaged<uint> createProgram;
		private static readonly unsafe delegate*unmanaged<uint, uint, void> attachShader;
		private static readonly unsafe delegate*unmanaged<uint, void> linkProgram;
		private static readonly unsafe delegate*unmanaged<uint, ProgramIvParameter, int*, void> getProgramIv;
		private static readonly unsafe delegate*unmanaged<uint, int, int*, byte*, void> getProgramInfoLog;
		private static readonly unsafe delegate*unmanaged<uint, void> useProgram;
		private static readonly unsafe delegate*unmanaged<uint, int, VertexDataType, NativeBool, int, void*, void> vertexAttribPointer;
		private static readonly unsafe delegate*unmanaged<uint, void> enableVertexAttribArray;
		private static readonly unsafe delegate*unmanaged<int, uint*, void> genVertexArrays;
		private static readonly unsafe delegate*unmanaged<uint, void> bindVertexArray;
		private static readonly unsafe delegate*unmanaged<DrawMode, int, int, void> drawArrays;
		private static readonly unsafe delegate*unmanaged<DrawMode, int, IndexType, void*, void> drawElements;
		private static readonly unsafe delegate*unmanaged<int, uint*, void> deleteVertexArrays;
		private static readonly unsafe delegate*unmanaged<int, uint*, void> deleteBuffers;
		private static readonly unsafe delegate*unmanaged<uint, void> deleteProgram;
		private static readonly unsafe delegate*unmanaged<int, float, float, void> uniform2F;
		private static readonly unsafe delegate*unmanaged<int, float, float, float, void> uniform3F;
		private static readonly unsafe delegate*unmanaged<int, float, float, float, float, void> uniform4F;
		private static readonly unsafe delegate*unmanaged<int, int, void> uniform1I;
		private static readonly unsafe delegate*unmanaged<int, int, NativeBool, float*, void> uniformMatrix4Fv;
		private static readonly unsafe delegate*unmanaged<uint, NativeString, int> getUniformLocation;
		private static readonly unsafe delegate*unmanaged<int, uint*, void> genTextures;
		private static readonly unsafe delegate*unmanaged<int, uint*, void> deleteTextures;
		private static readonly unsafe delegate*unmanaged<TextureTarget, uint, void> bindTexture;
		private static readonly unsafe delegate*unmanaged<TextureTarget, TextureParameter, int, void> texParameteri;
		private static readonly unsafe delegate*unmanaged<TextureTarget, void> generateMipmap;
		private static readonly unsafe delegate*unmanaged<TextureUnit, void> activeTexture;
		private static readonly unsafe delegate*unmanaged<PixelStoreParameter, int, void> pixelStorei;
		private static readonly unsafe delegate*unmanaged<BlendFactor, BlendFactor, void> blendFunc;
		private static readonly unsafe delegate*unmanaged<int, uint*, void> genFramebuffers;
		private static readonly unsafe delegate*unmanaged<int, uint*, void> deleteFramebuffers;
		private static readonly unsafe delegate*unmanaged<FramebufferTarget, uint, void> bindFramebuffer;
		private static readonly unsafe delegate*unmanaged<FramebufferTarget, FramebufferStatus> checkFramebufferStatus;
		private static readonly unsafe delegate*unmanaged<int, uint*, void> genRenderBuffers;
		private static readonly unsafe delegate*unmanaged<int, uint, void> bindRenderBuffer;
		private static readonly unsafe delegate*unmanaged<int, uint*, void> deleteRenderBuffers;
		private static readonly unsafe delegate*unmanaged<int, RenderBufferInternalFormat, int, int, void> renderBufferStorage;

		private static readonly unsafe delegate*unmanaged<TextureTarget, int, TextureFormat, int, int, int, TextureFormat, TextureType, void
			*, void>
			texImage2D;

		private static readonly unsafe delegate*unmanaged<FramebufferTarget, FramebufferTextureAttachment, FramebufferTextureTarget, uint,
			int, void> framebufferTexture2D;

		private static readonly unsafe delegate*unmanaged<FramebufferTarget, FramebufferRenderBufferAttachment, int, uint, void>
			framebufferRenderBuffer;

		private static readonly unsafe delegate*unmanaged<int, int, RenderBufferInternalFormat, int, int, void>
			renderBufferStorageMultisample;

		private static readonly unsafe delegate*unmanaged<int, int, int, int, int, int, int, int, BlitMask, BlitFilter, void>
			blitFramebuffer;

		public static unsafe ErrorFlag Error =>
			GL.getError();

		static unsafe GL()
		{
			GL.getError = (delegate*unmanaged<ErrorFlag>)GL.GetProcAddress("glGetError\0"u8);
			GL.enable = (delegate*unmanaged<Capability, void>)GL.GetProcAddress("glEnable\0"u8);
			GL.viewport = (delegate*unmanaged<int, int, int, int, void>)GL.GetProcAddress("glViewport\0"u8);
			GL.clearColor = (delegate*unmanaged<float, float, float, float, void>)GL.GetProcAddress("glClearColor\0"u8);
			GL.clear = (delegate*unmanaged<ClearBuffer, void>)GL.GetProcAddress("glClear\0"u8);
			GL.genBuffers = (delegate*unmanaged<int, uint*, void>)GL.GetProcAddress("glGenBuffers\0"u8);
			GL.bindBuffer = (delegate*unmanaged<BufferTarget, uint, void>)GL.GetProcAddress("glBindBuffer\0"u8);
			GL.bufferData = (delegate*unmanaged<BufferTarget, nint, void*, BufferUsage, void>)GL.GetProcAddress("glBufferData\0"u8);
			GL.bufferSubData = (delegate* unmanaged<BufferTarget, int, nint, void*, void>)GL.GetProcAddress("glBufferSubData\0"u8);
			GL.createShader = (delegate*unmanaged<ShaderType, uint>)GL.GetProcAddress("glCreateShader\0"u8);
			GL.shaderSource = (delegate*unmanaged<uint, nint, NativeString*, int*, void>)GL.GetProcAddress("glShaderSource\0"u8);
			GL.getShaderIv = (delegate*unmanaged<uint, ShaderIvParameter, int*, void>)GL.GetProcAddress("glGetShaderiv\0"u8);
			GL.getShaderInfoLog = (delegate*unmanaged<uint, int, int*, byte*, void>)GL.GetProcAddress("glGetShaderInfoLog\0"u8);
			GL.compileShader = (delegate*unmanaged<uint, void>)GL.GetProcAddress("glCompileShader\0"u8);
			GL.createProgram = (delegate*unmanaged<uint>)GL.GetProcAddress("glCreateProgram\0"u8);
			GL.attachShader = (delegate*unmanaged<uint, uint, void>)GL.GetProcAddress("glAttachShader\0"u8);
			GL.linkProgram = (delegate*unmanaged<uint, void>)GL.GetProcAddress("glLinkProgram\0"u8);
			GL.getProgramIv = (delegate*unmanaged<uint, ProgramIvParameter, int*, void>)GL.GetProcAddress("glGetProgramiv\0"u8);
			GL.getProgramInfoLog = (delegate*unmanaged<uint, int, int*, byte*, void>)GL.GetProcAddress("glGetProgramInfoLog\0"u8);
			GL.useProgram = (delegate*unmanaged<uint, void>)GL.GetProcAddress("glUseProgram\0"u8);
			GL.deleteShader = (delegate*unmanaged<uint, void>)GL.GetProcAddress("glDeleteShader\0"u8);
			GL.vertexAttribPointer =
				(delegate*unmanaged<uint, int, VertexDataType, NativeBool, int, void*, void>)GL.GetProcAddress("glVertexAttribPointer\0"u8);
			GL.enableVertexAttribArray = (delegate*unmanaged<uint, void>)GL.GetProcAddress("glEnableVertexAttribArray\0"u8);
			GL.genVertexArrays = (delegate*unmanaged<int, uint*, void>)GL.GetProcAddress("glGenVertexArrays\0"u8);
			GL.bindVertexArray = (delegate*unmanaged<uint, void>)GL.GetProcAddress("glBindVertexArray\0"u8);
			GL.drawArrays = (delegate*unmanaged<DrawMode, int, int, void>)GL.GetProcAddress("glDrawArrays\0"u8);
			GL.drawElements = (delegate*unmanaged<DrawMode, int, IndexType, void*, void>)GL.GetProcAddress("glDrawElements\0"u8);
			GL.deleteVertexArrays = (delegate*unmanaged<int, uint*, void>)GL.GetProcAddress("glDeleteVertexArrays\0"u8);
			GL.deleteBuffers = (delegate*unmanaged<int, uint*, void>)GL.GetProcAddress("glDeleteBuffers\0"u8);
			GL.deleteProgram = (delegate*unmanaged<uint, void>)GL.GetProcAddress("glDeleteProgram\0"u8);
			GL.uniform2F = (delegate*unmanaged<int, float, float, void>)GL.GetProcAddress("glUniform2f\0"u8);
			GL.uniform3F = (delegate*unmanaged<int, float, float, float, void>)GL.GetProcAddress("glUniform3f\0"u8);
			GL.uniform4F = (delegate*unmanaged<int, float, float, float, float, void>)GL.GetProcAddress("glUniform4f\0"u8);
			GL.uniform1I = (delegate*unmanaged<int, int, void>)GL.GetProcAddress("glUniform1i\0"u8);
			GL.uniformMatrix4Fv = (delegate*unmanaged<int, int, NativeBool, float*, void>)GL.GetProcAddress("glUniformMatrix4fv\0"u8);
			GL.getUniformLocation = (delegate*unmanaged<uint, NativeString, int>)GL.GetProcAddress("glGetUniformLocation\0"u8);
			GL.genTextures = (delegate*unmanaged<int, uint*, void>)GL.GetProcAddress("glGenTextures\0"u8);
			GL.deleteTextures = (delegate*unmanaged<int, uint*, void>)GL.GetProcAddress("glDeleteTextures\0"u8);
			GL.bindTexture = (delegate*unmanaged<TextureTarget, uint, void>)GL.GetProcAddress("glBindTexture\0"u8);
			GL.texParameteri = (delegate*unmanaged<TextureTarget, TextureParameter, int, void>)GL.GetProcAddress("glTexParameteri\0"u8);
			GL.generateMipmap = (delegate*unmanaged<TextureTarget, void>)GL.GetProcAddress("glGenerateMipmap\0"u8);
			GL.texImage2D =
				(delegate*unmanaged<TextureTarget, int, TextureFormat, int, int, int, TextureFormat, TextureType, void*, void>)
				GL.GetProcAddress("glTexImage2D\0"u8);
			GL.activeTexture = (delegate*unmanaged<TextureUnit, void>)GL.GetProcAddress("glActiveTexture\0"u8);
			GL.pixelStorei = (delegate*unmanaged<PixelStoreParameter, int, void>)GL.GetProcAddress("glPixelStorei\0"u8);
			GL.blendFunc = (delegate* unmanaged<BlendFactor, BlendFactor, void>)GL.GetProcAddress("glBlendFunc\0"u8);
			GL.genFramebuffers = (delegate*unmanaged<int, uint*, void>)GL.GetProcAddress("glGenFramebuffers\0"u8);
			GL.deleteFramebuffers = (delegate*unmanaged<int, uint*, void>)GL.GetProcAddress("glDeleteFramebuffers\0"u8);
			GL.bindFramebuffer = (delegate*unmanaged<FramebufferTarget, uint, void>)GL.GetProcAddress("glBindFramebuffer\0"u8);
			GL.checkFramebufferStatus =
				(delegate*unmanaged<FramebufferTarget, FramebufferStatus>)GL.GetProcAddress("glCheckFramebufferStatus\0"u8);
			GL.framebufferTexture2D =
				(delegate*unmanaged<FramebufferTarget, FramebufferTextureAttachment, FramebufferTextureTarget, uint, int, void>)
				GL.GetProcAddress("glFramebufferTexture2D\0"u8);
			GL.genRenderBuffers = (delegate*unmanaged<int, uint*, void>)GL.GetProcAddress("glGenRenderbuffers\0"u8);
			GL.bindRenderBuffer = (delegate*unmanaged<int, uint, void>)GL.GetProcAddress("glBindRenderbuffer\0"u8);
			GL.deleteRenderBuffers = (delegate*unmanaged<int, uint*, void>)GL.GetProcAddress("glDeleteRenderbuffers\0"u8);
			GL.renderBufferStorage =
				(delegate*unmanaged<int, RenderBufferInternalFormat, int, int, void>)GL.GetProcAddress("glRenderbufferStorage\0"u8);
			GL.framebufferRenderBuffer =
				(delegate*unmanaged<FramebufferTarget, FramebufferRenderBufferAttachment, int, uint, void>)GL.GetProcAddress(
					"glFramebufferRenderbuffer\0"u8);
			GL.renderBufferStorageMultisample =
				(delegate*unmanaged<int, int, RenderBufferInternalFormat, int, int, void>)GL.GetProcAddress(
					"glRenderbufferStorageMultisample\0"u8);
			GL.blitFramebuffer =
				(delegate*unmanaged<int, int, int, int, int, int, int, int, BlitMask, BlitFilter, void>)GL.GetProcAddress(
					"glBlitFramebuffer\0"u8);
		}

		public static unsafe void Enable(Capability capability)
		{
			GL.enable(capability);
			GL.Validate();
		}

		public static unsafe void Viewport(int x, int y, int width, int height)
		{
			GL.viewport(x, y, width, height);
			GL.Validate();
		}

		public static unsafe void ClearColor(float red, float green, float blue, float alpha)
		{
			GL.clearColor(red, green, blue, alpha);
			GL.Validate();
		}

		public static unsafe void Clear(ClearBuffer buffer)
		{
			GL.clear(buffer);
			GL.Validate();
		}

		public static unsafe void GenBuffers(int count, uint* buffers)
		{
			GL.genBuffers(count, buffers);
			GL.Validate();
		}

		public static unsafe uint GenBuffer()
		{
			uint buffer;

			GL.GenBuffers(1, &buffer);

			return buffer;
		}

		public static unsafe void BindBuffer(BufferTarget target, uint buffer)
		{
			GL.bindBuffer(target, buffer);
			GL.Validate();
		}

		public static unsafe void BufferData(BufferTarget target, nint size, void* data, BufferUsage usage)
		{
			GL.bufferData(target, size, data, usage);
			GL.Validate();
		}

		public static unsafe void BufferSubData(BufferTarget target, int offset, nint size, void* data)
		{
			GL.bufferSubData(target, offset, size, data);
			GL.Validate();
		}

		public static unsafe uint CreateShader(ShaderType type)
		{
			var shader = GL.createShader(type);

			GL.Validate();

			return shader;
		}

		public static unsafe void ShaderSource(uint shader, nint count, NativeString* strings, int* lengths)
		{
			GL.shaderSource(shader, count, strings, lengths);
			GL.Validate();
		}

		public static unsafe int GetShaderIv(uint shader, ShaderIvParameter parameter)
		{
			int result;

			GL.getShaderIv(shader, parameter, &result);

			return result;
		}

		public static unsafe int GetShaderInfoLog(uint shader, scoped System.Span<byte> buffer)
		{
			int length;

			fixed (byte* ptr = buffer)
			{
				GL.getShaderInfoLog(shader, buffer.Length, &length, ptr);
			}

			return length;
		}

		public static unsafe void CompileShader(uint shader)
		{
			GL.compileShader(shader);
			GL.Validate();
		}

		public static unsafe uint CreateProgram()
		{
			var program = GL.createProgram();

			GL.Validate();

			return program;
		}

		public static unsafe void AttachShader(uint program, uint shader)
		{
			GL.attachShader(program, shader);
			GL.Validate();
		}

		public static unsafe void LinkProgram(uint program)
		{
			GL.linkProgram(program);
			GL.Validate();
		}

		public static unsafe void UseProgram(uint program)
		{
			GL.useProgram(program);
			GL.Validate();
		}

		public static unsafe int GetProgramIv(uint program, ProgramIvParameter parameter)
		{
			int result;

			GL.getProgramIv(program, parameter, &result);

			return result;
		}

		public static unsafe int GetProgramInfoLog(uint program, scoped System.Span<byte> buffer)
		{
			int length;

			fixed (byte* ptr = buffer)
			{
				GL.getProgramInfoLog(program, buffer.Length, &length, ptr);
			}

			return length;
		}

		public static unsafe void DeleteShader(uint shader)
		{
			GL.deleteShader(shader);
			GL.Validate();
		}

		public static unsafe void VertexAttribPointer(uint index,
													  int size,
													  VertexDataType type,
													  bool normalized,
													  int stride,
													  void* pointer)
		{
			GL.vertexAttribPointer(index, size, type, normalized, stride, pointer);
			GL.Validate();
		}

		public static unsafe void EnableVertexAttribArray(uint index)
		{
			GL.enableVertexAttribArray(index);
			GL.Validate();
		}

		public static unsafe void GenVertexArrays(int count, uint* arrays)
		{
			GL.genVertexArrays(count, arrays);
			GL.Validate();
		}

		public static unsafe uint GenVertexArray()
		{
			uint array;

			GL.genVertexArrays(1, &array);

			GL.Validate();

			return array;
		}

		public static unsafe void BindVertexArray(uint array)
		{
			GL.bindVertexArray(array);
			GL.Validate();
		}

		public static unsafe void DrawArrays(DrawMode mode, int first, int count)
		{
			GL.drawArrays(mode, first, count);
			GL.Validate();
		}

		public static unsafe void DrawElements(DrawMode mode, int count, IndexType type, VoidPointer indices)
		{
			GL.drawElements(mode, count, type, indices);
			GL.Validate();
		}

		public static unsafe void DeleteVertexArrays(int count, uint* arrays)
		{
			GL.deleteVertexArrays(count, arrays);
			GL.Validate();
		}

		public static unsafe void DeleteBuffers(int count, uint* arrays)
		{
			GL.deleteBuffers(count, arrays);
			GL.Validate();
		}

		public static unsafe void DeleteProgram(uint program)
		{
			GL.deleteProgram(program);
			GL.Validate();
		}

		public static unsafe void Uniform2F(int location, float v0, float v1)
		{
			GL.uniform2F(location, v0, v1);
			GL.Validate();
		}

		public static unsafe void Uniform3F(int location, float v0, float v1, float v2)
		{
			GL.uniform3F(location, v0, v1, v2);
			GL.Validate();
		}

		public static unsafe void Uniform4F(int location, float v0, float v1, float v2, float v3)
		{
			GL.uniform4F(location, v0, v1, v2, v3);
			GL.Validate();
		}

		public static unsafe void Uniform1I(int location, int v0)
		{
			GL.uniform1I(location, v0);
			GL.Validate();
		}

		public static unsafe void UniformMatrix4Fv(int location, int count, bool transpose, float* value)
		{
			GL.uniformMatrix4Fv(location, count, transpose, value);
			GL.Validate();
		}

		public static unsafe int GetUniformLocation(uint program, NativeString name) =>
			GL.getUniformLocation(program, name);

		public static unsafe void GenTextures(int count, uint* textures)
		{
			GL.genTextures(count, textures);
			GL.Validate();
		}

		public static unsafe uint GenTexture()
		{
			uint texture;

			GL.GenTextures(1, &texture);

			return texture;
		}

		public static unsafe void DeleteTextures(int count, uint* textures)
		{
			GL.deleteTextures(count, textures);
			GL.Validate();
		}

		public static unsafe void DeleteTexture(uint texture) =>
			GL.DeleteTextures(1, &texture);

		public static unsafe void BindTexture(TextureTarget target, uint texture)
		{
			GL.bindTexture(target, texture);
			GL.Validate();
		}

		public static unsafe void TextureParameteri(TextureTarget target, TextureParameter parameter, int value)
		{
			GL.texParameteri(target, parameter, value);
			GL.Validate();
		}

		public static unsafe void GenerateMipmap(TextureTarget target)
		{
			GL.generateMipmap(target);
			GL.Validate();
		}

		public static unsafe void TextureImage2D(TextureTarget target,
												 int level,
												 TextureFormat internalFormat,
												 int width,
												 int height,
												 TextureFormat format,
												 TextureType type,
												 void* data)
		{
			GL.texImage2D(target, level, internalFormat, width, height, 0, format, type, data);
			GL.Validate();
		}

		public static unsafe void ActiveTexture(TextureUnit texture)
		{
			GL.activeTexture(texture);
			GL.Validate();
		}

		public static unsafe void PixelStore(PixelStoreParameter parameter, int value)
		{
			GL.pixelStorei(parameter, value);
			GL.Validate();
		}

		public static unsafe void BlendFunc(BlendFactor src, BlendFactor dst)
		{
			GL.blendFunc(src, dst);
			GL.Validate();
		}

		public static unsafe void GenFramebuffers(int count, uint* buffers)
		{
			GL.genFramebuffers(count, buffers);
			GL.Validate();
		}

		public static unsafe uint GenFramebuffer()
		{
			uint buffer;

			GL.GenFramebuffers(1, &buffer);

			return buffer;
		}

		public static unsafe void DeleteFramebuffers(int count, uint* arrays)
		{
			GL.deleteFramebuffers(count, arrays);
			GL.Validate();
		}

		public static unsafe void BindFramebuffer(FramebufferTarget target, uint framebuffer)
		{
			GL.bindFramebuffer(target, framebuffer);
			GL.Validate();
		}

		public static unsafe FramebufferStatus CheckFramebufferStatus(FramebufferTarget target) =>
			GL.checkFramebufferStatus(target);

		public static unsafe void FramebufferTexture2D(FramebufferTextureAttachment attachment,
													   FramebufferTextureTarget target,
													   uint texture)
		{
			GL.framebufferTexture2D(FramebufferTarget.ReadAndWrite, attachment, target, texture, 0);
			GL.Validate();
		}

		public static unsafe void GenRenderBuffers(int count, uint* buffers)
		{
			GL.genRenderBuffers(count, buffers);
			GL.Validate();
		}

		public static unsafe uint GenRenderBuffer()
		{
			uint buffer;

			GL.GenRenderBuffers(1, &buffer);

			return buffer;
		}

		public static unsafe void BindRenderBuffer(uint renderBuffer)
		{
			const int target = 0x8D41;

			GL.bindRenderBuffer(target, renderBuffer);
			GL.Validate();
		}

		public static unsafe void DeleteRenderBuffers(int count, uint* arrays)
		{
			GL.deleteRenderBuffers(count, arrays);
			GL.Validate();
		}

		public static unsafe void RenderBufferStorage(RenderBufferInternalFormat internalFormat, int width, int height)
		{
			const int target = 0x8D41;

			GL.renderBufferStorage(target, internalFormat, width, height);
			GL.Validate();
		}

		public static unsafe void RenderbufferStorageMultisample(int samples,
																 RenderBufferInternalFormat internalFormat,
																 int width,
																 int height)
		{
			const int target = 0x8D41;

			GL.renderBufferStorageMultisample(target, samples, internalFormat, width, height);
			GL.Validate();
		}

		public static unsafe void FramebufferRenderBuffer(FramebufferTarget target,
														  FramebufferRenderBufferAttachment attachment,
														  uint renderBuffer)
		{
			const int renderBufferTarget = 0x8D41;

			GL.framebufferRenderBuffer(target, attachment, renderBufferTarget, renderBuffer);
			GL.Validate();
		}

		public static unsafe void BlitFramebuffer(int srcX0,
												  int srcY0,
												  int srcX1,
												  int srcY1,
												  int dstX0,
												  int dstY0,
												  int dstX1,
												  int dstY1,
												  BlitMask mask,
												  BlitFilter filter)
		{
			GL.blitFramebuffer(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
			GL.Validate();
		}

		private static nint GetProcAddress(NativeString name)
		{
			var address = GLFW.GetProcAddress(name);

			Debug.Assert(address != default, $"Method '{name.ToString()}' not found.");

			return address;
		}

		[Conditional("DEBUG")]
		internal static void Validate([CallerMemberName] string? method = null)
		{
			var error = GL.Error;

			Debug.Assert(error == ErrorFlag.None, $"{method} error: {error}");
		}
	}
}
