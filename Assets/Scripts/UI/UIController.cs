using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
        void Start()
    {
        BunHolder.BunHolderSelected += ToggleBunWindow;
        HotdogHolder.HotdogHolderSelected += ToggleHotdogWindow;
        
        
    }

    void ToggleBunWindow(bool boolean)
    {
        SetActiveObjectAndChildren(transform.Find("BunHolderWindow"), boolean);
    }

    void ToggleHotdogWindow(bool boolean)
    {
        SetActiveObjectAndChildren(transform.Find("HotdogHolderWindow"), boolean);

    }



    void SetActiveObjectAndChildren(Transform parent, bool boolean)
    {
                
        foreach (Transform child in parent)
        {
            child.gameObject.SetActive(boolean);
            if (child.childCount > 1)
            {
                SetActiveObjectAndChildren(child, boolean);
            }
        }
        parent.gameObject.SetActive(boolean);
    }


}
