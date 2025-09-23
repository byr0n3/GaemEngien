using System.IO;
using System.Numerics;
using System.Text;
using Engine.OpenGL;

namespace Engine.Sample.OpenGL
{
	internal readonly struct Level
	{
		public readonly GameObject[,] Objects;

		public Level(GameObject[,] objects) =>
			this.Objects = objects;

		public void Draw(in SpriteRenderer renderer)
		{
			// @todo Batch render
			foreach (var @object in this.Objects)
			{
				@object.Draw(in renderer);
			}
		}

		public bool IsCompleted()
		{
			foreach (var @object in this.Objects)
			{
				if (@object.Type != 0 && !@object.Destroyed)
				{
					return false;
				}
			}

			return true;
		}

		public static Level ReadLevelFile(string filePath, int width, int height, Texture blockTexture, Texture solidBlockTexture)
		{
			if (!Path.Exists(filePath))
			{
				throw new System.ArgumentException($"Level file doesn't exist at: {Path.GetFullPath(filePath)}", nameof(filePath));
			}

			Level result;

			using (var stream = File.OpenRead(filePath))
			using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
			{
				var rows = reader.ReadUInt16();
				var columns = reader.ReadUInt16();

				var blockSize = new Vector2(width / (float)columns, height / (float)rows);

				var objects = new GameObject[rows, columns];

				for (var row = 0; row < rows; row++)
				{
					for (var column = 0; column < columns; column++)
					{
						var type = reader.ReadByte();

						// Gap block
						if (type == 0)
						{
							continue;
						}

						var position = new Vector2(blockSize.X * column, blockSize.Y * row);
						var color = type switch
						{
							1 => new Vector3(0.8f, 0.8f, 0.7f),
							2 => new Vector3(0.2f, 0.6f, 1.0f),
							3 => new Vector3(0.0f, 0.7f, 0.0f),
							4 => new Vector3(0.8f, 0.8f, 0.4f),
							5 => new Vector3(1.0f, 0.5f, 0.0f),
							_ => new Vector3(1f, 1f, 1f),
						};

						objects[row, column] = new GameObject(
							type: type,
							position: position,
							size: blockSize,
							color: color,
							rotation: 0f,
							destroyed: false,
							texture: type == 1 ? solidBlockTexture : blockTexture
						);
					}
				}

				result = new Level(objects);
			}

			return result;
		}

		public static void WriteLevelFile(Level level, string filePath)
		{
			var rows = level.Objects.GetLength(0);
			var columns = level.Objects.GetLength(1);

			using (var stream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
			using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
			{
				writer.Write((ushort)rows);
				writer.Write((ushort)columns);

				for (var row = 0; row < rows; row++)
				{
					for (var column = 0; column < columns; column++)
					{
						var @object = level.Objects[row, column];

						writer.Write(@object.Type);
					}
				}

				writer.Flush();
			}
		}
	}
}
