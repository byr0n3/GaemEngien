using System.Collections.Generic;
using Engine.OpenGL;
using JetBrains.Annotations;

namespace Engine.Sample.OpenGL
{
	[MustDisposeResource]
	internal readonly struct ResourceManager : System.IDisposable
	{
		private readonly Dictionary<ShaderKey, ShaderProgram> shaders;
		private readonly Dictionary<TextureKey, Texture> textures;

		public ResourceManager()
		{
			// Subtract one to remove the invalid key.
			// @todo Optimal?
			this.shaders = new Dictionary<ShaderKey, ShaderProgram>(System.Enum.GetValues<ShaderKey>().Length - 1);
			this.textures = new Dictionary<TextureKey, Texture>(System.Enum.GetValues<TextureKey>().Length - 1);
		}

		public bool TryAdd(ShaderKey key, ShaderProgram shader) =>
			this.shaders.TryAdd(key, shader);

		public bool TryAdd(TextureKey key, Texture texture) =>
			this.textures.TryAdd(key, texture);

		public bool TryGet(ShaderKey key, out ShaderProgram shader) =>
			this.shaders.TryGetValue(key, out shader);

		public bool TryGet(TextureKey key, out Texture texture) =>
			this.textures.TryGetValue(key, out texture);

		public ShaderProgram Get(ShaderKey key) =>
			this.shaders[key];

		public Texture Get(TextureKey key) =>
			this.textures[key];

		public void Dispose()
		{
			foreach (var shader in this.shaders.Values)
			{
				shader.Dispose();
			}

			foreach (var texture in this.textures.Values)
			{
				texture.Dispose();
			}

			this.shaders.Clear();
			this.textures.Clear();
		}
	}

	internal enum ShaderKey
	{
		Invalid = 0,
		Sprite,
		Particle,
	}

	internal enum TextureKey
	{
		Invalid = 0,
		Paddle,
		Ball,
		Background,
		Block,
		SolidBlock,
		Particle,
	}
}
