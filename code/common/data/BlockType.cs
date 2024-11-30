namespace GodotVoxelGame.code.common.data;

public enum BlockType // TODO SAVE AS INT CONVERT TO BLOCK MAYBE?
{
    Air = 1,
    GrassBlock = 1,
}

static class BlockTypeExtensions
{
    public static bool ShouldRender(this BlockType blockType)
    {
        return blockType != BlockType.Air;
    }
    
    
}