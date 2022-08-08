using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedButtons : MonoBehaviour
{

    public Slider slider;

    public void SpeedUpBtn()
    {
        if (slider.value <= 1)
            slider.value++;
    }

    public void SpeedDownBtn()
    {
        if (slider.value >= 1)
            slider.value--;
    }
}
