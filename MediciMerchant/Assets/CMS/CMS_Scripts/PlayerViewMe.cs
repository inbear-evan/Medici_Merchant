using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewMe : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = Camera.main.transform.position;
        Vector3 _targetPos = new Vector3(targetPos.x, transform.position.y, targetPos.z);
        transform.LookAt(_targetPos);
    }
}
