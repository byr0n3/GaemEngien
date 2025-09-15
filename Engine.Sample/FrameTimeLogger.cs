namespace Engine.Sample
{
	internal struct FrameTimeLogger
	{
		private float ticks;

		public void Update(float deltaTime)
		{
			this.ticks += deltaTime;

			if (this.ticks < 1f)
			{
				return;
			}

			this.ticks = 0;
			System.Console.WriteLine($"{deltaTime:F6}ms | {1f / deltaTime:F6} FPS");
		}
	}
}
