namespace GodotVoxelGame.code.common.data;

public record ChunkPos(int ChunkX, int ChunkZ)
{
    public BlockPos WorldPos(BlockPos chunkBlockPos)
    {
        return new BlockPos(ChunkX * World.GetChunkSize() + chunkBlockPos.X, chunkBlockPos.Y, ChunkZ * World.GetChunkSize() + chunkBlockPos.Z);
    }
}