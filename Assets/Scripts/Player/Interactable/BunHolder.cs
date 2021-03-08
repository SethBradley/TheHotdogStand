using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BunHolder : MonoBehaviour, IPlayer_Interactable
{
    public GameObject bunWindow;
    public static Action<bool> BunHolderSelected;

       
    public void OnSelected()
    {
        BunHolderSelected(true);
        
    }
    public void OnDeselected()
    {
       BunHolderSelected(false);
    }




}
