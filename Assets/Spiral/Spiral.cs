using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour
{
    Mesh Mesh;
    const int numberOfSegments = 4;
    float rin = 1f;
    float rout = 2f;
    float Theta = 0;
    float dTheta = .5f;
    float y = 0;
    float dy = 0.2f;

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
        //const int NumberOfTriangles = (numberOfSegments * 2 * 3);

        Vector3[] vertices = new Vector3[numberOfVertices];

      

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

        int[] triangles = new int[] 
        {
            0,1,3,
            0,3,2,
            2,3,5,
            2,5,4,
            4,5,7,
            4,7,6,
            6,7,9,
            6,9,8
        };

        lineRenderer.SetPosition(0, vertices[0]);
        lineRenderer.SetPosition(1, vertices[1]);

        Mesh.Clear();
        Mesh.vertices = vertices;
        Mesh.triangles = triangles;

        for(int i = 0;i< numberOfVertices;i++)
        {
            Debug.Log(vertices[i]);
        }
    }

    Vector3 CylinderToCarthesian(float radius, float Theta, float y_sp)
    {
        float x = radius * Mathf.Cos(Theta);
        float y = y_sp;
        float z = radius * Mathf.Sin(Theta);
        return new Vector3(x, y, z);
    }
}
