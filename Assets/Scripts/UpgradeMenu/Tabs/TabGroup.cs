using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheHotdogStand
{
    public class TabGroup : MonoBehaviour
    {
        public List<TabButton> tabButtons;
        public List<GameObject> objectsToSwap;
        public TabButton selectedTab;

        public void Subscribe(TabButton button)
        {
            if (tabButtons == null)
            {
                tabButtons = new List<TabButton>();
            }

            tabButtons.Add(button);
        }


        public void onTabEnter(TabButton button)
        {
            ResetTabs();
            if (selectedTab == null || button != selectedTab)
                button.background.color = Color.green;
        }

        public void onTabExit(TabButton button)
        {
            ResetTabs();
        }

        public void onTabSelected(TabButton button)
        {
            if (selectedTab != null)
            {
                selectedTab.Deselect();    
            }

            selectedTab = button;
            
            selectedTab.Select();
            
            ResetTabs();
            
            button.background.color = Color.green;
            int index = button.transform.GetSiblingIndex();

            for (int i = 0; i < objectsToSwap.Count; i++)
            {
                if (i == index)
                {
                    objectsToSwap[i].SetActive(true);
                }

                else
                {
                    objectsToSwap[i].SetActive(false);
                }
            }
        }


        public void ResetTabs()
        {
            foreach (TabButton button in tabButtons)
            {
                if (button == selectedTab && selectedTab != null)
                {
                    continue;
                }
                
                button.background.color = Color.white;
            }
        }
    }
}
