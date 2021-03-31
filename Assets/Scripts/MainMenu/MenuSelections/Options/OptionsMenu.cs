using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : IMenuWindow
{
    public void onOpen()
    {
        

        MainMenuController.instance.goBackButton.gameObject.SetActive(true);
        MainMenuController.instance.MainMenuUI.transform.Find("OptionsWindow").gameObject.SetActive(true);
        
        Debug.Log("Opened Options Window");
        
    }

    public void onClose()
    {
        MainMenuController.instance.MainMenuUI.transform.Find("OptionsWindow").gameObject.SetActive(false);
        MainMenuController.instance.goBackButton.gameObject.SetActive(false);

    }




}
