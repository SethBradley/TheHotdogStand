using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuSelections : MonoBehaviour
{
    NewGameMenu newGameMenu = new NewGameMenu();
    LoadGameMenu loadGameMenu = new LoadGameMenu();
    OptionsMenu optionsMenu = new OptionsMenu();


    private void Awake() 
    {
        //NewGameMenu newGameMenu = new NewGameMenu();
    }


    public void NewGameClick()
    {
       MainMenuController.instance.activeWindow = newGameMenu;
    }

    public void LoadGameClick()
    {
        MainMenuController.instance.activeWindow = loadGameMenu;
    }

    public void OptionsClick()
    {
        MainMenuController.instance.activeWindow = optionsMenu;
    }

    public void QuitClick()
    {
        Debug.Log("Quit application");
        Application.Quit();
    }

    public void CloseActiveWindow()
    {
        
        MainMenuController.instance.windowIsActive = false;
        MainMenuController.instance.activeWindow.onClose();
        MainMenuController.instance.activeWindow = null;
    }

    public void CloseActiveSubWindow()
    {
        MainMenuController.instance.MainMenuUI.transform.Find("NewGameOverwriteWindow").gameObject.SetActive(false);

    }

}



