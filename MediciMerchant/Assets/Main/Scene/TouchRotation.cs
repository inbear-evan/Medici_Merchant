using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotation : MonoBehaviour
{
    private Vector2 firstFingerPosition; // first finger position
    private Vector2 lastFingerPosition; // last finger position
    public SyncMap syncMapCompass;

    // Start is called before the first frame update
    void Start()
    {

    }

    private float speed = 3f;

    Touch touch;
    float xAngleTemp , xAngle, yAngleTemp ,yAngle;
    void Update()
    {

        //touch = Input.GetTouch(0);

        //if (touch.phase == TouchPhase.Moved)
        //{
        //    if (touch.deltaPosition)
        //    {

        //    }

        //    transform.Rotate(0f, 0f, -Input.GetAxis("Mouse X") * speed, Space.World);
        //    //transform.Rotate(-Input.GetAxis("Mouse Y") * speed, 0f, 0f);
        //}


        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                firstFingerPosition = Input.GetTouch(0).position;
               xAngleTemp = xAngle;
               yAngleTemp = yAngle;

            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                lastFingerPosition = Input.GetTouch(0).position;
                xAngle = xAngleTemp + (lastFingerPosition.x - firstFingerPosition.x) * 180 / Screen.width;
                //transform.Rotate(0, 0, xAngle);

                //transform.localRotation = Quaternion.Euler(0, 0, -xAngle);

                syncMapCompass.localCompass.eulerAngles += new Vector3(0,0,-xAngle);
            }
        }
    }
}
