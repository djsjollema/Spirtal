using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraRotation : MonoBehaviour
{
    float R = 10;
    float theta = 0;
    float dTheta = 0.003f;
    float y = 0;
    float dy = 0.0005f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = R * new Vector3(Mathf.Cos(theta), y, Mathf.Sin(theta));
        theta += dTheta;

        transform.LookAt(new Vector3(0, y, 0));
        y += dy;
        if(y > 2 || y < 0)
        {
            dy = -dy;
        }
    }
}
