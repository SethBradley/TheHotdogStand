using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatienceMeter : MonoBehaviour
{
    public Slider _slider;
    public Gradient _gradient;
    public Image fill;


    private void Update() 
    {
        _slider.value -= Time.deltaTime;

        fill.color = _gradient.Evaluate(_slider.normalizedValue);

        if (this._slider.value <= 0)
        {
            GameObject.Destroy(gameObject);
        }    
    }


}
