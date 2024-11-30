using Godot;
using GodotVoxelGame.code.client.data;
using GodotVoxelGame.code.common.data;
using GodotVoxelGame.code.common.handler;

namespace GodotVoxelGame.code.client;

// Client Side
public partial class ClientChunk : MeshInstance3D
{
    [Export] private bool _dirty;
    
    public BlockData[,,] BlockData { get; set; }

    public override void _Process(double delta)
    {
        if (!_dirty) return;
        _dirty = false;
        RenderHandler.RenderChunk(this);
    }

    public void CreateRenderData(BlockType[,,] chunkDataBlocks)
    {
        BlockData = ChunkHandler.GenerateChunkData(chunkDataBlocks);
        _dirty = true;
    }
}