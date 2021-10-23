using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yh_title : MonoBehaviour
{
    float time;
    public Image titleM;
    public Image titleB;

    void Start()
    {
        titleB.enabled = false;
    }

    void Update()
    {
        titleM.transform.localScale = Vector3.one * (1.8f * time);
        time += Time.deltaTime;

        if (time > 3f)
        {
            time = 3f;
            titleM.transform.localScale = Vector3.one * (1.8f * time);            
            titleB.enabled = true;
            if(titleB.gameObject.transform.rotation.x != 0)
            {
                titleB.gameObject.transform.Rotate(90 * Time.deltaTime, 0, 0);
            }
        }
    }
}
