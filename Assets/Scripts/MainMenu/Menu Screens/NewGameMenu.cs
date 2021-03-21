using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameMenu : MonoBehaviour, IMenuWindow
{
    private MainMenuUI mainMenuUI;


    public void onOpen()
    {
        mainMenuUI = FindObjectOfType<MainMenuUI>();

        MainMenuController.instance.goBackButton.gameObject.SetActive(true);
        mainMenuUI.transform.Find("NewGameWindow").gameObject.SetActive(true);
        
        Debug.Log("Opened New Game Window");
        

        
    }
    public void onClose()
    {
        mainMenuUI.transform.Find("NewGameWindow").gameObject.SetActive(false);
        MainMenuController.instance.goBackButton.gameObject.SetActive(false);
    }

}
