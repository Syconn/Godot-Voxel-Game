using System.Collections.Generic;
using Godot;
using GodotVoxelGame.code.client.data;
using GodotVoxelGame.code.common;
using GodotVoxelGame.code.common.data;

namespace GodotVoxelGame.code.client;

public static class RenderHandler
{
    private static List<Vector3> _vertices;
    private static List<Vector2> _uvs;
    private static List<int> _indices;
    private static int _faceCount;
    private const float TexDiv = 0.5f;

    public static void RenderBlock(MeshInstance3D instance, Vector3 pos, BlockData blockData)
    {
        ClearRender();
        BlockWithCulling(pos, blockData);
        GenerateMesh(instance);
    }
    
    public static void RenderChunk(ClientChunk clientChunk)
    {
        ClearRender();
        for (var x = 0; x < World.GetChunkSize(); x++)
        {
            for (var z = 0; z < World.GetChunkSize(); z++)
            {
                BlockWithCulling(new Vector3(x, 0, z), clientChunk.BlockData[x, 0, z]);
            }
        }
        GenerateMesh(clientChunk);
    }

    private static void ClearRender()
    {
        _vertices = new List<Vector3>();
        _uvs = new List<Vector2>();
        _indices = new List<int>();
        _faceCount = 0;
    }

    private static void BlockWithCulling(Vector3 pos, BlockData blockData)
    {
        if (blockData.Faces[(int) Direction.Up].Visible)
        {
            _vertices.Add(pos + new Vector3(-0.5f, 0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(0.5f, 0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(0.5f, 0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(-0.5f, 0.5f, 0.5f));

            AddTris();
            AddUVs(0, 0);
        }

        if (blockData.Faces[(int) Direction.East].Visible)
        {
            _vertices.Add(pos + new Vector3(0.5f, 0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(0.5f, 0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(0.5f, -0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(0.5f, -0.5f, 0.5f));

            AddTris();
            AddUVs(0, 0);
        }

        if (blockData.Faces[(int) Direction.South].Visible)
        {
            _vertices.Add(pos + new Vector3(-0.5f, 0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(0.5f, 0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(0.5f, -0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(-0.5f, -0.5f, 0.5f));

            AddTris();
            AddUVs(0, 0);
        }

        if (blockData.Faces[(int) Direction.West].Visible)
        {
            _vertices.Add(pos + new Vector3(-0.5f, 0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(-0.5f, 0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(-0.5f, -0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(-0.5f, -0.5f, -0.5f));

            AddTris();
            AddUVs(0, 0);
        }

        if (blockData.Faces[(int) Direction.North].Visible)
        {
            _vertices.Add(pos + new Vector3(0.5f, 0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(-0.5f, 0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(-0.5f, -0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(0.5f, -0.5f, -0.5f));

            AddTris();
            AddUVs(0, 0);
        }

        if (blockData.Faces[(int) Direction.Down].Visible)
        {
            _vertices.Add(pos + new Vector3(-0.5f, -0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(0.5f, -0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(0.5f, -0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(-0.5f, -0.5f, -0.5f));

            AddTris();
            AddUVs(0, 0);
        }
    }

    private static void GenerateMesh(MeshInstance3D instance)
    {
        var meshTool = new SurfaceTool();
        meshTool.Begin(Mesh.PrimitiveType.Triangles);
        for (int i = 0; i < _vertices.Count; i++)
        {
            meshTool.SetUV(_uvs[i]);
            meshTool.AddVertex(_vertices[i]);
        }

        foreach (var i in _indices) meshTool.AddIndex(i);
        meshTool.GenerateNormals();
        instance.Mesh = meshTool.Commit();
    }

    private static void AddUVs(int x, int y)
    {
        _uvs.Add(new Vector2(TexDiv * x, TexDiv * y));
        _uvs.Add(new Vector2(TexDiv * x + TexDiv, TexDiv * y));
        _uvs.Add(new Vector2(TexDiv * x + TexDiv, TexDiv * y + TexDiv));
        _uvs.Add(new Vector2(TexDiv * x, TexDiv * y + TexDiv));
    }

    private static void AddTris()
    {
        _indices.Add(_faceCount * 4 + 0);
        _indices.Add(_faceCount * 4 + 1);
        _indices.Add(_faceCount * 4 + 2);
        _indices.Add(_faceCount * 4 + 0);
        _indices.Add(_faceCount * 4 + 2);
        _indices.Add(_faceCount * 4 + 3);
        _faceCount += 1;
    }
}