using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuSelections : MonoBehaviour
{
    NewGameMenu newGameMenu = new NewGameMenu();
    OptionsMenu optionsMenu = new OptionsMenu();

    private void Awake() 
    {
        //NewGameMenu newGameMenu = new NewGameMenu();
    }


    public void NewGameClick()
    {
       MainMenuController.instance.activeWindow = newGameMenu;
    }

    public void OptionsClick()
    {
        MainMenuController.instance.activeWindow = optionsMenu;
    }

    public void CloseActiveWindow()
    {
        
        MainMenuController.instance.windowIsActive = false;
        MainMenuController.instance.activeWindow.onClose();
        MainMenuController.instance.activeWindow = null;
    }

}



