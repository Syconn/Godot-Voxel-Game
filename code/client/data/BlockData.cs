using System;
using Godot;
using GodotVoxelGame.code.common.data;

namespace GodotVoxelGame.code.client.data;

public readonly record struct BlockData(BlockType Type, FaceData[] Faces);

public readonly record struct FaceData(bool Visible, int TextureX, int TextureZ);