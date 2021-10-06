using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public GameObject arCam;
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(90, arCam.transform.rotation.y + 90,0);
    }
}
