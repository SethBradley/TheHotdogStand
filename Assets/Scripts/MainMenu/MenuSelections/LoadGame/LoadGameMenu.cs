using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameMenu : IMenuWindow
{

    public void onOpen()
    {
        

        MainMenuController.instance.goBackButton.gameObject.SetActive(true);
        MainMenuController.instance.MainMenuUI.transform.Find("LoadGameWindow").gameObject.SetActive(true);
        
        Debug.Log("Opened Load Game Window"); 
    }
    public void onClose()
    {
        MainMenuController.instance.MainMenuUI.transform.Find("LoadGameWindow").gameObject.SetActive(false);
        MainMenuController.instance.goBackButton.gameObject.SetActive(false);
    }

}
