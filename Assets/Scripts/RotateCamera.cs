using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    float Radius = 28;
    float PolarCoordinate = - 0.8f + Mathf.PI / 2;
    float Azimuth = 0;
    float dAzimuth = 0.002f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ConvertSphericalToCartesian();
        transform.LookAt(Vector3.zero);
        Azimuth += dAzimuth;


    }

    Vector3 ConvertSphericalToCartesian()
    {
        float x = Radius * Mathf.Sin(PolarCoordinate) * Mathf.Cos(Azimuth);
        float y = Radius * Mathf.Cos(PolarCoordinate);
        float z = Radius * Mathf.Sin(PolarCoordinate) * Mathf.Sin(Azimuth);
        return new Vector3(x, y, z);
    }
}
