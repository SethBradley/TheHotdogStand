using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour, IMenuWindow
{
    private MainMenuUI mainMenuUI;
    public void onOpen()
    {
        mainMenuUI = FindObjectOfType<MainMenuUI>();

        MainMenuController.instance.goBackButton.gameObject.SetActive(true);
        mainMenuUI.transform.Find("OptionsWindow").gameObject.SetActive(true);
        
        Debug.Log("Opened Options Window");
        
    }

    public void onClose()
    {
        mainMenuUI.transform.Find("OptionsWindow").gameObject.SetActive(false);
        MainMenuController.instance.goBackButton.gameObject.SetActive(false);

    }




}
