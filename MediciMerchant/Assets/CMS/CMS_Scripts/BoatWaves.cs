using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatWaves : MonoBehaviour
{
    public float distance = 0.5f;
    public float waveHeight = 1.5f;
    public float waveFrequency = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - waveHeight * Mathf.Sin(Time.time * Mathf.PI * 2.0f * waveFrequency
                + (Mathf.PI * 2.0f * distance)),transform.position.z);

    }
}
