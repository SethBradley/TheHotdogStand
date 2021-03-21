using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawnController : MonoBehaviour
{
    public static PedestrianSpawnController instance;
    public List<Pedestrian> pedestriansInScene;

    private void Awake() 
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else 
            instance = this;   

    }
    public void CycleNPC(Pedestrian _pedestrian)
    {
        _pedestrian.gameObject.SetActive(false);
        _pedestrian._checkedTargets?.Clear();
        _pedestrian._customerOrder?.Clear();
        _pedestrian._target = _pedestrian.GetRandomExit();
        _pedestrian._exitTarget = _pedestrian._target;
        

        StartCoroutine(RespawnNPCTimer(_pedestrian));


    }
    IEnumerator RespawnNPCTimer(Pedestrian _pedestrian)
    {
        Debug.Log("Wait");
        yield return new WaitForSeconds(5);
        Debug.Log("Done with wait");
        _pedestrian.gameObject.SetActive(true);   
    }
}
