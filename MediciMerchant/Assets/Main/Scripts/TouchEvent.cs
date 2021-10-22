using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchEvent : MonoBehaviour
{
    public GameObject coinTouchFx;

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject)
        {
            coinTouchFx.transform.position = EventSystem.current.currentSelectedGameObject.transform.position;
            if (coinTouchFx.GetComponent<ParticleSystem>().isPaused) coinTouchFx.GetComponent<ParticleSystem>().Play();
        }
    }
}
