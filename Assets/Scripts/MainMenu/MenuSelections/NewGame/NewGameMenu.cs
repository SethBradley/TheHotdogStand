using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameMenu : IMenuWindow
{   

    public void onOpen()
    {

        MainMenuController.instance.goBackButton.gameObject.SetActive(true);
        MainMenuController.instance.MainMenuUI.transform.Find("NewGameWindow").gameObject.SetActive(true);
        
        Debug.Log("Opened New Game Window"); 
    }
    public void onClose()
    {
        MainMenuController.instance.MainMenuUI.transform.Find("NewGameWindow").gameObject.SetActive(false);
        MainMenuController.instance.goBackButton.gameObject.SetActive(false);
    }

}
