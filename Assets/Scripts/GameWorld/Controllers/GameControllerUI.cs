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
        
        newDayTextBox.text = $"Day {currentDayNumText}";
        yield return new WaitForSeconds(2.5f);
        //Debug.Log("Next day number posted");
        newDayTextBox.text = $"Day {nextDayNumText}";
        //SoundFXManager.PlaySound(NewDayDing.mp4) idk something like that
        
        yield return new WaitForSeconds(1.5f);

        newDayWindow.GetComponent<Animator>().SetBool("Dissapear", true);
        //Debug.Log("Dissapear begins");
        yield return new WaitForSeconds(1.5f);
        //Debug.Log("Set false");
        newDayWindow.SetActive(false);
    }
    
}
