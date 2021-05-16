using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


    public class Page1 : MonoBehaviour
    {
        
        public TMP_Text normalHotdogCountText;
        public TMP_Text hotdogTier2CountText;
        public TMP_Text hotdogTier3CountText;

        public TMP_Text normalBunCountText;
        public TMP_Text bunTier2CountText;
        public TMP_Text bunTier3CountText;
        
        
        private void Awake() 
        {
            
            UpdateStats();
        }


        public void UpdateStats()
        {
            string normalDogsCount = SaveData.current.count_playerInventory[0].ToString();
            string normalBunsCount = SaveData.current.count_playerInventory[3].ToString();

            normalHotdogCountText.text = $"Normal Hotdog.....................$1.00({normalDogsCount})";
            normalBunCountText.text = $"Normal Bun.....................$1.00({normalBunsCount})";

            if (SaveData.current.achievementRewardClaimedArray[2])
            {
                string tier2DogsCount = SaveData.current.count_playerInventory[1].ToString();
                string tier2BunsCount = SaveData.current.count_playerInventory[4].ToString();

                hotdogTier2CountText.text = $"Organic Hotdog.....................$1.00({tier2DogsCount})";
                bunTier2CountText.text = $"Rubber Bun.....................$1.00({tier2BunsCount})";
            }

            if (SaveData.current.achievementRewardClaimedArray[3])
            {
                string tier3DogsCount = SaveData.current.count_playerInventory[2].ToString();
                string tier3BunsCount = SaveData.current.count_playerInventory[5].ToString();

                hotdogTier3CountText.text = $"Organic Hotdog.....................$1.00({tier3DogsCount})";
                bunTier3CountText.text = $"Rubber Bun.....................$1.00({tier3BunsCount})";
            }
        }

    }

