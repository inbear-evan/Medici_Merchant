using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doongdoong : MonoBehaviour
{
    public AnimationCurve ac;
    float curTime;
    Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        float value = ac.Evaluate(curTime);
        transform.localPosition = origin + new Vector3(0, value, 0);
    }

}