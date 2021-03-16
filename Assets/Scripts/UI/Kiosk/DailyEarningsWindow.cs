using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DailyEarningsWindow : MonoBehaviour
{
    public TMP_Text text;
    public float currentEarnings;

    void Start()
    {
        PlayerController.AddToDailyEarning += AddToDailyEarnings;
        
    }

    void AddToDailyEarnings(float costOfOrder)
    {
        currentEarnings += costOfOrder;

        text.text = ("$" + currentEarnings.ToString("F2"));
    }

}
