using GodotVoxelGame.code.client.data;

namespace GodotVoxelGame.code.common.data;

public enum BlockType
{
    Air = RenderType.Invisible,
    Grass = RenderType.Solid,
}

static class BlockTypeExtensions
{
    public static bool FullBlock(this BlockType blockType)
    {
        return (int) blockType is (int) RenderType.Solid;
    }
    
    public static bool Transparent(this BlockType blockType)
    {
        return (int) blockType is (int) RenderType.Transparent;
    }

    public static bool ShouldRenderFace(this BlockType blockType)
    {
        return (int) blockType != (int) RenderType.Solid;
    }
    
    public static bool ShouldRenderBlock(this BlockType blockType)
    {
        return (int) blockType != (int) RenderType.Invisible;
    }
}