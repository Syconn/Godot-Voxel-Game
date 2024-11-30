using GodotVoxelGame.code.client.data;
using GodotVoxelGame.code.common.data;

namespace GodotVoxelGame.code.common.handler;

public static class ChunkHandler
{
    public static BlockType[,,] GenerateChunk(ChunkPos chunkPos)
    {
        BlockType[,,] blocks = new BlockType[World.GetChunkSize(), 1, World.GetChunkSize()];
        for (var x = 0; x < World.GetChunkSize(); x++)
        {
            for (var z = 0; z < World.GetChunkSize(); z++)
            {
                blocks[x, 0, z] = BlockType.Grass;
            }
        }
        return blocks;
    }
    
    public static BlockData[,,] GenerateChunkData(BlockType[,,] chunkPos)
    {
        BlockData[,,] data = new BlockData[World.GetChunkSize(), 1, World.GetChunkSize()];
        for (var x = 0; x < World.GetChunkSize(); x++)
        {
            for (var z = 0; z < World.GetChunkSize(); z++)
            {
                
            }
        }
        return data;
    }
}