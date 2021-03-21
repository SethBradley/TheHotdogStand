using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    float progressedTime;
    TMP_Text clockText;

    private void Start() 
    {
        clockText = transform.GetChild(0).GetComponent<TMP_Text>();
    }

    private void Update() 
    {
        progressedTime += Time.deltaTime;
        // Debug.Log(progressedTime);
        if (progressedTime >= 2f)
        {
            progressedTime = 0;

            if (int.Parse(clockText.text.Substring(2,2)) != 50)
            {
                //Debug.Log(newMinute);
                var newMinute = int.Parse(clockText.text.Substring(2,2)) + 10f;
                clockText.text = clockText.text.Replace(clockText.text.Substring(2,2), newMinute.ToString());
                return;
            }
            var newHour = int.Parse(clockText.text.Substring(0,1)) + 1f;
            clockText.text = clockText.text.Replace(clockText.text.Substring(0,1), newHour.ToString());
            clockText.text = clockText.text.Replace(clockText.text.Substring(2,2), "00");
            return;
        }

        if (int.Parse(clockText.text.Substring(0,1)) == 5)
        {
            Debug.Log("Day ends");
        }

           
    }

}
