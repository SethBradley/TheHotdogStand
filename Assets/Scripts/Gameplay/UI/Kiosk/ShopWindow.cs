using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWindow : MonoBehaviour
{

    public void CancelOrderButton()
    {
        PlayerController.instance.ClearOrder();
    }
}
