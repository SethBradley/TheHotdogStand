using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int selectedSaveSlot;
    public SaveData selectedSaveData;
    //Loading Screen
    public GameObject loadingScreen;
  

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else 
            instance = this;

        SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU, LoadSceneMode.Additive);
    }

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    public void LoadGame()
    {
        loadingScreen.gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU);
        SceneManager.LoadSceneAsync((int)SceneIndexes.GAMEWORLD, LoadSceneMode.Additive);

        

        StartCoroutine(GetLoadGameProgress());

        
    }
    public void GameWorldToUpgradeMenu()
    {
        SceneManager.UnloadSceneAsync((int)SceneIndexes.GAMEWORLD);
        SceneManager.LoadSceneAsync((int)SceneIndexes.UPGRADE_MENU, LoadSceneMode.Additive);
        

        StartCoroutine(GetLoadGameProgress());
    }

    public void SaveGameData()
    {
        SerializationManager.Save(SaveData.current.savePath, SaveData.current);
    }

    public IEnumerator GetLoadGameProgress()
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return null;
            }
        }
        
        //yield return new WaitForSeconds(4);
        
        
        loadingScreen.gameObject.SetActive(false);
    }

    public void ChangeActiveScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
    }

    public void LoadNextDay()
    {
        loadingScreen.gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync((int)SceneIndexes.UPGRADE_MENU);
        SceneManager.LoadSceneAsync((int)SceneIndexes.GAMEWORLD, LoadSceneMode.Additive);

        StartCoroutine(GetLoadGameProgress());
    }
}
