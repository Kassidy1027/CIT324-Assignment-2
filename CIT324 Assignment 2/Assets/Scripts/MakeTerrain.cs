using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTerrain : MonoBehaviour
{

    void Start()
    {

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        Perlin surface = new Perlin();

        for (int v = 0; v < vertices.Length; v++)
        {
            // Original Code
            // vertices[v].y = Random.Range(0f, 10f); // generates new value for the height of each vertice

            // 1st Replacement Line
            // vertices[v].y = Mathf.Sin(vertices[v].x * 10);

            // 2nd Replacement Line
            vertices[v].y = surface.Noise(vertices[v].x * 2 + 0.1365143f, vertices[v].z * 2 + 1.21688f) * 10;

        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds(); // we call this to ensure bounding volume is correct (as recommended by APIs)
        mesh.RecalculateNormals(); // again, recommended by APIs

        gameObject.AddComponent<MeshCollider>();
    }
}