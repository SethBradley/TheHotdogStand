using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControllerUI : MonoBehaviour
{
    public GameObject endDayWindow;
    public GameObject newDayWindow;


    public void TickNewDay(int currentDay)
    {
        StartCoroutine(CoroutineStartNewDay());
    }


    IEnumerator CoroutineStartNewDay()
    {
        string currentDayNumText = GameController.instance.currentDay.ToString();
        string nextDayNumText = (GameController.instance.currentDay + 1).ToString();
        var newDayTextBox = newDayWindow.transform.Find("DayText").GetComponent<TMP_Text>();
        
        yield return new WaitForSeconds(2.5f);

        newDayTextBox.text = $"Day {nextDayNumText}";
        //

    }
}
