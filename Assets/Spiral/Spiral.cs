using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour
{
    Mesh Mesh;
    const int numberOfSegments = 180; //aantal segementen. Ieder segment bestaat uit twee driehoeken
    float rin = 2f; //breedte binnencirkel
    float rout = 5f; //breedte buitenscirkel
    float Theta = 0;
    float dTheta = .08f; //nauwkeurigheid, hoe kleiner, hoe mooier
    float y = 0;
    float dy = 0.05f; //de helling die de spiraal maakt

    [SerializeField] LineRenderer lineRenderer;

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
        const int numberOfVertices = (numberOfSegments *2) + 2;
        const int NumberOfTriangles = (numberOfSegments * 2 * 3);

        Vector3[] vertices = new Vector3[numberOfVertices];

        //Debug.Log(numberOfVertices);

      

        for(int i = 0; i< numberOfVertices; i++)
        {
            if(i%2 == 0)
            {
                vertices[i] = CylinderToCarthesian(rin, Theta,y);
            } 
            else
            {
                vertices[i] = CylinderToCarthesian(rout, Theta,y);
                Theta += dTheta;
                y += dy;
            }
            
        }

        int[] triangles = new int[NumberOfTriangles];

        for (int i = 0; i < NumberOfTriangles; i++)
        {
            if (i % 6 == 0)
                triangles[i] = i / 6 * 2;
            else if (i % 6 == 1)
                triangles[i] = (i / 6 * 2) + 1;
            else if (i % 6 == 2)
                triangles[i] = (i / 6 * 2) + 3;
            else if (i % 6 == 3)
                triangles[i] = (i / 6 * 2);
            else if (i % 6 == 4)
                triangles[i] = (i / 6 * 2) + 3;
            else if (i % 6 == 5)
                triangles[i] = (i / 6 * 2) + 2;
        }

        Mesh.Clear();
        Mesh.vertices = vertices;
        Mesh.triangles = triangles;

        /* lineRenderer, moet ik nog uitzoeken.. 
        lineRenderer.positionCount = 10;

        for (int i = 0;i< 10;i++)
        {
            if(i %2 == 0)
            {
                Debug.Log(i/2);
                lineRenderer.SetPosition(i/2, vertices[i]);
            }

        }
        */
    }

    Vector3 CylinderToCarthesian(float radius, float Theta, float y_sp)
    {
        float x = radius * Mathf.Cos(Theta);
        float y = y_sp;
        float z = radius * Mathf.Sin(Theta);
        return new Vector3(x, y, z);
    }
}
