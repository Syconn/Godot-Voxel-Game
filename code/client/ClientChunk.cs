using Godot;

namespace GodotVoxelGame.code.client;

[Tool]
public partial class ClientChunk : MeshInstance3D
{
    [Export] public bool Dirty;

    public override void _Ready()
    {
        // Dirty = true;
    }

    public override void _Process(double delta)
    {
        if (!Dirty) return;
        Dirty = false;
        // TODO Render Chunk 
        RenderHandler.RenderBlock(this, new Vector3(0, 0, 0));
    }
}