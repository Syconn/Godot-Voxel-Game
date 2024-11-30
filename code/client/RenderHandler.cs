using System.Collections.Generic;
using Godot;

namespace GodotVoxelGame.code.client;

public class RenderHandler
{
    private static List<Vector3> _vertices;
    private static List<Vector2> _uvs;
    private static List<int> _indices;
    private static int _faceCount;
    private const float TexDiv = 0.5f;

    public static void RenderBlock(MeshInstance3D instance, Vector3 pos)
    {
        _vertices = new List<Vector3>();
        _uvs = new List<Vector2>();
        _indices = new List<int>();
        _faceCount = 0;
        
        BlockWithCulling(pos);
        GenerateMesh(instance);
    }

    private static void BlockWithCulling(Vector3 pos)
    {
        // if block_is_air(pos + Vector3(0, 1, 0)): UP
        if (true)
        {
            _vertices.Add(pos + new Vector3(-0.5f, 0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(0.5f, 0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(0.5f, 0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(-0.5f, 0.5f, 0.5f));

            AddTris();
            AddUVs(0, 0);
        }

        // if block_is_air(pos + Vector3(1, 0, 0)): EAST
        if (true)
        {
            _vertices.Add(pos + new Vector3(0.5f, 0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(0.5f, 0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(0.5f, -0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(0.5f, -0.5f, 0.5f));

            AddTris();
            AddUVs(0, 0);
        }

        // if block_is_air(pos + Vector3(0, 0, 1)): SOUTH
        if (true)
        {
            _vertices.Add(pos + new Vector3(-0.5f, 0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(0.5f, 0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(0.5f, -0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(-0.5f, -0.5f, 0.5f));

            AddTris();
            AddUVs(0, 0);
        }

        // if block_is_air(pos + Vector3(-1, 0, 0)): WEST
        if (true)
        {
            _vertices.Add(pos + new Vector3(-0.5f, 0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(-0.5f, 0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(-0.5f, -0.5f, 0.5f));
            _vertices.Add(pos + new Vector3(-0.5f, -0.5f, -0.5f));

            AddTris();
            AddUVs(0, 0);
        }

        // if block_is_air(pos + Vector3(0, 0, -1)) NORTH
        if (true)
        {
            _vertices.Add(pos + new Vector3(0.5f, 0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(-0.5f, 0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(-0.5f, -0.5f, -0.5f));
            _vertices.Add(pos + new Vector3(0.5f, -0.5f, -0.5f));

            AddTris();
            AddUVs(0, 0);
        }

        if (true) // BOTTOM
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

        foreach (var i in _indices)
        {
            meshTool.AddIndex(i);
        }

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