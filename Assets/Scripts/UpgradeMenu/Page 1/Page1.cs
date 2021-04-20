using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TheHotdogStand
{
    public class Page1 : MonoBehaviour
    {
        
        public TMP_Text NormalHotdogCountText;
        //public TMP_Text Hotdog2CountText;
        //public TMP_Text Hotdog3CountText;

        public TMP_Text NormalBunCountText;
        //public TMP_Text Bun2CountText;
        //public TMP_Text Bun3CountText;
        
        private void Awake() 
        {
            UpdateStats();
        }


        public void UpdateStats()
        {
            string normalDogsCount = SaveData.current.count_playerInventory[0].ToString();
            string normalBunsCount = SaveData.current.count_playerInventory[1].ToString();

            NormalHotdogCountText.text = $"Normal Hotdog.....................$1.00({normalDogsCount})";
            NormalBunCountText.text = $"Normal Bun.....................$1.00({normalBunsCount})";

        }

    }
}
