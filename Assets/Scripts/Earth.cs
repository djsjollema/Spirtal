using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    float Radius;
    [SerializeField] GameObject Amsterdam;
    [SerializeField] GameObject Parijs;

    void Start()
    {
        Radius = (transform.localScale.y / 2);
    }

    void Update()
    {
        //transform.Rotate(new Vector3(0, 0.2f, 0));
        Amsterdam.transform.position= ConvertSphericalToCartesian(52, 4.8f);
        Parijs.transform.position= ConvertSphericalToCartesian(49, 2f);
    }

    Vector3 ConvertSphericalToCartesian(float colattitude, float longitude)
    {
        float lattitude = 90 - colattitude;
        float x = Radius * Mathf.Sin(lattitude * Mathf.Deg2Rad) * Mathf.Cos((longitude) * Mathf.Deg2Rad);
        float y = Radius * Mathf.Cos(lattitude * Mathf.Deg2Rad);
        float z = Radius * Mathf.Sin(lattitude * Mathf.Deg2Rad) * Mathf.Sin((longitude) * Mathf.Deg2Rad);
        return new Vector3(x, y, z);    
    }
}
