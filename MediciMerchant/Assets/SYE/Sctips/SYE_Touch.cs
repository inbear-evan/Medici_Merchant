using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SYE_Touch : MonoBehaviour
{
    public ParticleSystem[] touchEffect;
    ParticleSystem ps;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        int rnd = Random.Range(0, touchEffect.Length);
        if (touchEffect != null)
        {
            ps = touchEffect[rnd].GetComponent<ParticleSystem>();
        }

        if (Input.touchCount != 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                //Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                //ps.transform.position = pos;

                //ps.transform.position = touch.position;

                ps.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                ps.transform.position = new Vector3(ps.transform.position.x, ps.transform.position.y, 10);
                ps.Stop(); ps.Play();
            }
        }
    }
}
