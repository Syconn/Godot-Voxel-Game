using Godot;

namespace GodotVoxelGame.code.common.data;

public class BlockPos
{
    public int X { get; }
    public int Y { get; }
    public int Z { get; }

    public BlockPos(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public BlockPos(Vector3 position)
    {
        X = (int) position.X;
        Y = (int) position.Y;
        Z = (int) position.Z;
    }

    public Vector3 GetVector3()
    {
        return new Vector3(X, Y, Z);
    }

    public ChunkPos GetChunkPos()
    {
        return new ChunkPos(X / World.GetChunkSize(), Z / World.GetChunkSize());
    }
    
    public BlockPos GetPosInChunk()
    {
        return new BlockPos(X % World.GetChunkSize(), Y, Z % World.GetChunkSize());
    }

    public BlockPos Translate(Vector3 vector)
    {
        return new BlockPos(X + (int) vector.X, Y + (int) vector.Y, Z + (int) vector.Z);
    }

    public BlockPos Offset(Direction direction)
    {
        return Translate(direction.Offset());
    }
}