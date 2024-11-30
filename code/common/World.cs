using Godot;

namespace GodotVoxelGame.code.common;

public partial class World : Node3D
{
	[Export] private Node3D _chunkObj;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}
}