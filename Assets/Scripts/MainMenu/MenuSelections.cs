using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuSelections : MonoBehaviour
{
    NewGameMenu newGameMenu = new NewGameMenu();

    private void Awake() 
    {
        //NewGameMenu newGameMenu = new NewGameMenu();
    }


    public void NewGameClick()
    {
        Debug.Log("Start New Game?");
       MainMenuController.instance.activeWindow = newGameMenu;
    }

}



