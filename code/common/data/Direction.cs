using System;
using Godot;

namespace GodotVoxelGame.code.common.data;

public enum Direction
{
    North,
    East,
    South,
    West,
    Up,
    Down
}

static class DirectionExtensions
{
    public static Direction Opposite(this Direction direction)
    {
        return direction switch
        {
            Direction.North => Direction.South,
            Direction.East => Direction.West,
            Direction.South => Direction.North,
            Direction.West => Direction.East,
            Direction.Up => Direction.Down,
            Direction.Down => Direction.Up,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    private static int XOffset(this Direction direction)
    {
        return direction switch
        {
            Direction.West => -1,
            Direction.East => 1,
            _ => 0
        };
    }

    private static int YOffset(this Direction direction)
    {
        return direction switch
        {
            Direction.Down => -1,
            Direction.Up => 1,
            _ => 0
        };
    }

    private static int ZOffset(this Direction direction)
    {
        return direction switch
        {
            Direction.North => -1,
            Direction.South => 1,
            _ => 0
        };
    }

    public static Vector3 Offset(this Direction direction)
    {
        return new Vector3(XOffset(direction), YOffset(direction), ZOffset(direction));
    }
}