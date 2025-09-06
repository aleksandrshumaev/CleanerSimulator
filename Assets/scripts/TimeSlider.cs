using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] GlobalParameters _globalParameters;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        _slider.value = _globalParameters.RestTime;
    }
}
