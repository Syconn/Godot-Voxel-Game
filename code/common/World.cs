using Godot;
using GodotVoxelGame.code.common.data;

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
	[Export] private int _renderDistance = 1;

	private static World _instance;
	private ChunkData[,] _loadedChunks = new ChunkData[GetRenderDistance(), GetRenderDistance()];
	
	public override void _Ready()
	{
		_instance ??= this;
		for (int chunkX = 0; chunkX < GetRenderDistance(); chunkX++)
		{
			for (int chunkZ = 0; chunkZ < GetRenderDistance(); chunkZ++)
			{
				_loadedChunks[chunkX, chunkZ] = new ChunkData(new ChunkPos(chunkX, chunkZ), GetNode<Node3D>("Chunk") as Chunk); // TODO Instantiate it
			}
		}

		foreach (var loadedChunk in _loadedChunks) loadedChunk.ChunkNode.Setup(loadedChunk);
	}

	public static BlockType GetBlock(BlockPos pos)
	{
		var chunkPos = pos.GetChunkPos();
		return _instance._loadedChunks[chunkPos.ChunkX, chunkPos.ChunkZ].GetBlock(pos);
	}
	
	public static void SetBlock(BlockType block, BlockPos pos)
	{
		var chunkPos = pos.GetChunkPos();
		_instance._loadedChunks[chunkPos.ChunkX, chunkPos.ChunkZ].SetBlock(block, pos);
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

	public static int GetRenderDistance()
	{
		return _instance._renderDistance;
	}
}