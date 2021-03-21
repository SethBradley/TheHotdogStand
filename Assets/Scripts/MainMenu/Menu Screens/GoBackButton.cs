using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackButton : MonoBehaviour
{
    public void CloseActiveWindow()
    {
        MainMenuController.instance.activeWindow.onClose();
    }
}
