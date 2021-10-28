using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yh_screentilt : MonoBehaviour
{
    private void Awake()
    {
        Input.gyro.enabled = false;
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        Input.gyro.enabled = true;
    }

    void Update()
    {
   
        //if (-Input.gyro.rotationRate.y >= -15)
        {
            //Debug.Log(Input.gyro.rotationRate.y);
            transform.Rotate(0, -Input.gyro.rotationRate.y / 2, 0);
        }
    }

}


/* 
transform.Rotate(Mathf.Clamp(Input.acceleration.y, -0.5f, 0.5f), Mathf.Clamp(Input.acceleration.x, -0.5f, 0.5f), 0);
float y = Mathf.Clamp(Input.acceleration.y, -1f, 1f);
float x = Mathf.Clamp(Input.acceleration.x, -1f, 1f);
float z = 0;
Vector3 dir = new Vector3(x, y, z);
transform.Rotate(dir);
*/
