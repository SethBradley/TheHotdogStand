using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameMenu : MonoBehaviour, IMenuWindow
{
    private MainMenuUI mainMenuUI;


    public void onOpen()
    {
        mainMenuUI = FindObjectOfType<MainMenuUI>();

        MainMenuController.instance.goBackButton.gameObject.SetActive(true);
        mainMenuUI.transform.Find("LoadGameWindow").gameObject.SetActive(true);
        
        Debug.Log("Opened Load Game Window"); 
    }
    public void onClose()
    {
        mainMenuUI.transform.Find("LoadGameWindow").gameObject.SetActive(false);
        MainMenuController.instance.goBackButton.gameObject.SetActive(false);
    }

}
