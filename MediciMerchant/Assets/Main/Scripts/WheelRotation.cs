using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelRotation : MonoBehaviour
{
    public Image wheel1;
    public Image wheel2;
    int dir;

    float prevSliderValue = 0;
    float sliderValue = 0;
    // Update is called once per frame
    void FixedUpdate()
    {

        sliderValue = transform.GetComponent<Slider>().value;
        if (sliderValue < prevSliderValue)
        {
            dir = 1;
        }
        else if (sliderValue > prevSliderValue)
        {
            dir = -1;
        }
        else if(sliderValue == prevSliderValue)
        {
            dir = 0;
        }

        prevSliderValue = sliderValue;

        wheel1.gameObject.transform.Rotate(0, 0, dir * 180 * Time.deltaTime);
        wheel2.gameObject.transform.Rotate(0, 0, dir * 180 * Time.deltaTime);


    }
}
