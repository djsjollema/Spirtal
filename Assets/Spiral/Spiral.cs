using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour
{
    Mesh Mesh;
    const int numberOfSegments = 500; //aantal segementen. Ieder segment bestaat uit twee driehoeken
    float rin = 3f; //breedte binnencirkel
    float rout = 5f; //breedte buitenscirkel
    float Theta = 0;
    float dTheta = -0.05f; //nauwkeurigheid, hoe kleiner, hoe mooier
    float y = 0;
    float dy = 0.02f; //de helling die de spiraal maakt

    void Start()
    {
        Mesh = new Mesh();
        Mesh = GetComponent<MeshFilter>().mesh;

        GenerateSpiral();
    }

    void Update()
    {

    }

    private void GenerateSpiral()
    {
        const int numberOfVertices = (numberOfSegments * 2) + 2;
        const int numberOfTriangles = (numberOfSegments * 2 * 3);

        Vector3[] vertices = new Vector3[numberOfVertices];
        Color[] colors = new Color[numberOfVertices]; // kleuren array voor de vertices

        // Bereken de totale hoogte voor het kleurverloop
        float minHeight = 0;
        float maxHeight = dy * (numberOfSegments - 1);

        for (int i = 0; i < numberOfVertices; i++)
        {
            if (i % 2 == 0)
            {
                vertices[i] = CylinderToCarthesian(rin, Theta, y);
            }
            else
            {
                vertices[i] = CylinderToCarthesian(rout, Theta, y);
                Theta += dTheta;
                y += dy;
            }

            // Bereken de kleur op basis van de y-positie (hoogte)
            float t = Mathf.InverseLerp(minHeight, maxHeight, vertices[i].y);
            colors[i] = Color.Lerp(Color.black, Color.white, t);
        }

        int[] triangles = new int[numberOfTriangles];

        for (int i = 0; i < numberOfSegments; i++)
        {
            int vertIndex = i * 2;
            int triIndex = i * 6;

            // Eerste driehoek
            triangles[triIndex] = vertIndex;
            triangles[triIndex + 1] = vertIndex + 1;
            triangles[triIndex + 2] = vertIndex + 3;

            // Tweede driehoek
            triangles[triIndex + 3] = vertIndex;
            triangles[triIndex + 4] = vertIndex + 3;
            triangles[triIndex + 5] = vertIndex + 2;
        }

        Mesh.Clear();
        Mesh.vertices = vertices;
        Mesh.triangles = triangles;
        Mesh.colors = colors; // kleuren toepassen
    }

    Vector3 CylinderToCarthesian(float radius, float Theta, float y_sp)
    {
        float x = radius * Mathf.Cos(Theta);
        float y = y_sp;
        float z = radius * Mathf.Sin(Theta);
        return new Vector3(x, y, z);
    }
}
