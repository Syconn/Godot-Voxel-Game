using Godot;

namespace GodotVoxelGame.code.common;

[Tool]
public partial class World : Node3D
{
	// private PackedScene _chunkScene = GD.Load<PackedScene>("res://scenes/chunk.tscn");
	// var instance = _chunkScene.Instantiate();
	// AddChild(instance);
	
	[Export] private long _seed = 1;
	[Export] private int _worldHeight = 40;
	[Export] private int _chunkSize = 16;

	private static World _instance;
	
	public override void _Ready()
	{
		_instance ??= this;
	}

	public static World GetWorld()
	{
		return _instance;
	}

	public static long GetSeed()
	{
		return _instance._seed;
	}
	
	public static int GetWorldHeight()
	{
		return _instance._worldHeight;
	}
	
	public static int GetChunkSize()
	{
		return _instance._chunkSize;
	}
}