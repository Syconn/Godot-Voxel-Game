using Godot;
using GodotVoxelGame.code.common.handler;

namespace GodotVoxelGame.code.common.data;

// SERVER SIDE
public class ChunkData
{
    public ChunkPos ChunkPos { get; }
    public Chunk ChunkNode { get; }
    public BlockType[,,] Blocks { get; }
    
    public ChunkData(ChunkPos chunkPos, Chunk chunkNode)
    {
        ChunkPos = chunkPos;
        ChunkNode = chunkNode;
        Blocks = ChunkHandler.GenerateChunk(chunkPos);
    }
    
    public void SetBlock(BlockType type, BlockPos pos)
    {
        var chunkPos = pos.GetPosInChunk();
        Blocks[chunkPos.X, chunkPos.Y, chunkPos.Z] = type; // TODO HANDLE UPDATING RENDER
    }

    public BlockType GetBlock(BlockPos pos)
    {
        var chunkPos = pos.GetPosInChunk();
        return Blocks[chunkPos.X, chunkPos.Y, chunkPos.Z];
    }
}