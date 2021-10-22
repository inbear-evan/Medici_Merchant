using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 180 * Time.deltaTime * 0.5f, 0);
    }
}
