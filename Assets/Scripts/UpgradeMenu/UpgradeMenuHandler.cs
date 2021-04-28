using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


    public class UpgradeMenuHandler : MonoBehaviour
    {
        public TMP_Text dayText;
        public TMP_Text moneyText;

        //Events
        public EventHandler<float> onMoneyUpdate;
        public EventHandler<int> onInventoryCountUpdate;

        private void Awake() 
        {
            string currentDay = SaveData.current.currentDay.ToString();
            dayText.text = $"Day {currentDay}";

            UpdateMoney();

        }

        public void UpdateMoney()
        {
            string currentMoney = SaveData.current.totalMoney.ToString("F2");
            moneyText.text = $"${currentMoney}";
        }


        public void LoadNextDayButton()
        {
            Debug.Log("Load Next Day");
            GameManager.instance.SaveGameData();
            GameManager.instance.LoadNextDay();
        }
    }

