using Godot;
using GodotVoxelGame.code.client;
using GodotVoxelGame.code.common.data;

namespace GodotVoxelGame.code.common;

public partial class Chunk : Node3D
{
	public void Setup(ChunkData chunkData)
	{
		var clientChunk = GetNode<MeshInstance3D>("ChunkRenderer") as ClientChunk;
		clientChunk?.CreateRenderData(chunkData.Blocks);
	}
}