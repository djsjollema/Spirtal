using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraRotation : MonoBehaviour
{
    float R = 10;
    float theta = 0;
    float dTheta = 0.0005f;
    float y = 0;
    float dy = 0.005f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float cam_x = R * Mathf.Cos(theta);
        float cam_y = y;
        float cam_z = R * Mathf.Sin(theta);
        
        transform.position = new Vector3(R * Mathf.Cos(theta), y , R * Mathf.Sin(theta));
        theta += dTheta;

        transform.LookAt(new Vector3(0, y, 0));
        
        if(y > 10)
        {
            dy = -Mathf.Abs(dy);
        } 

        if(y<-1)
        {
            dy = Mathf.Abs(dy);
        }

        y += dy;

        //Debug.Log(y + " " +  dy);
    }
}
