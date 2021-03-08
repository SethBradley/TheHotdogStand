using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotdogHolder : MonoBehaviour, IPlayer_Interactable
{
    public static Action<bool> HotdogHolderSelected;

        public void OnSelected()
    {
        HotdogHolderSelected(true);
    }

    public void OnDeselected()
    {
        HotdogHolderSelected(false);
    }


}
