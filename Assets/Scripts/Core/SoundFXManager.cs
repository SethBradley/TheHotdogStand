using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

  

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else 
            instance = this;
    }
}
