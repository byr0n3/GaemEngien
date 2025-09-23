using Engine.Sample.OpenGL;

const int windowWidth = 1280;
const int windowHeight = 960;

// return Testing.Run(windowWidth, windowHeight);
return RunBreakout();
// WriteLevel();

static int RunBreakout()
{
	var breakout = new Breakout(windowWidth, windowHeight);

	while (breakout.Running)
	{
		breakout.Update();
	}

	breakout.Dispose();

	return default;
}

static void WriteLevel()
{
	var objects = new GameObject[8, 15]
	{
		{ Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5) },
		{ Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5), Obj(5) },
		{ Obj(4), Obj(4), Obj(4), Obj(4), Obj(4), Obj(0), Obj(0), Obj(0), Obj(0), Obj(0), Obj(4), Obj(4), Obj(4), Obj(4), Obj(4) },
		{ Obj(4), Obj(1), Obj(4), Obj(1), Obj(4), Obj(0), Obj(0), Obj(1), Obj(0), Obj(0), Obj(4), Obj(1), Obj(4), Obj(1), Obj(4) },
		{ Obj(3), Obj(3), Obj(3), Obj(3), Obj(3), Obj(0), Obj(0), Obj(0), Obj(0), Obj(0), Obj(3), Obj(3), Obj(3), Obj(3), Obj(3) },
		{ Obj(3), Obj(3), Obj(1), Obj(3), Obj(3), Obj(3), Obj(3), Obj(3), Obj(3), Obj(3), Obj(3), Obj(3), Obj(1), Obj(3), Obj(3) },
		{ Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2) },
		{ Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2), Obj(2) },
	};

	var level = new Level(objects);

	Level.WriteLevelFile(level, "./levels/one.lvl");

	return;

	static GameObject Obj(byte type) =>
		new(type, default, default, default, default, default, default);
}
