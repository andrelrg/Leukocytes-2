using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public int floorWidth = 100;
    public int floorLength = 100;
    public float scale = 20f;

    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mf.mesh = mesh;

        Vector3[] vertices = new Vector3[floorWidth * floorLength];
        int[] triangles = new int[(floorWidth - 1) * (floorLength - 1) * 6];
        Vector2[] uv = new Vector2[vertices.Length];

        for (int z = 0; z < floorLength; z++)
        {
            for (int x = 0; x < floorWidth; x++)
            {
                vertices[z * floorWidth + x] = new Vector3(x, Mathf.PerlinNoise(x / scale, z / scale), z);
                uv[z * floorWidth + x] = new Vector2((float)x / floorWidth, (float)z / floorLength);
            }
        }

        int triangleIndex = 0;
        for (int z = 0; z < floorLength - 1; z++)
        {
            for (int x = 0; x < floorWidth - 1; x++)
            {
                int bottomLeft = z * floorWidth + x;
                int bottomRight = bottomLeft + 1;
                int topLeft = bottomLeft + floorWidth;
                int topRight = topLeft + 1;

                triangles[triangleIndex++] = bottomLeft;
                triangles[triangleIndex++] = topLeft;
                triangles[triangleIndex++] = topRight;

                triangles[triangleIndex++] = topRight;
                triangles[triangleIndex++] = bottomRight;
                triangles[triangleIndex++] = bottomLeft;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;
        mesh.RecalculateNormals();
    }
}
