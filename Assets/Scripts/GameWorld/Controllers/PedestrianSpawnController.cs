using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SethUtils;
public class PedestrianSpawnController : MonoBehaviour
{
    public static PedestrianSpawnController instance;
    public List<GameObject> pedestriansInScene;

    private void Start() 
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else 
            instance = this;   

        StartCoroutine(SpawnAllNPCs());
    }



    public void CycleNPC(Pedestrian _pedestrian)
    {
        _pedestrian.gameObject.SetActive(false);
        _pedestrian._checkedTargets?.Clear();
        _pedestrian._customerOrder?.Clear();
        var previousExit = _pedestrian._target;
        var newExit = _pedestrian.GetRandomExit();
        if (newExit != previousExit)
        {
            _pedestrian._target =newExit;
            _pedestrian._exitTarget = _pedestrian._target;
        }

        else
        {
        _pedestrian._target = _pedestrian.GetRandomExit();
        }
        
        

        StartCoroutine(RespawnNPCTimer(_pedestrian));


    }
    IEnumerator RespawnNPCTimer(Pedestrian _pedestrian)
    {
        Debug.Log("Wait");
        yield return new WaitForSeconds(5);
        Debug.Log("Done with wait");
        _pedestrian.transform.position = _pedestrian.GetRandomExit().transform.position;
        _pedestrian.gameObject.SetActive(true);   
    }


    IEnumerator SpawnAllNPCs()
    {
        var listOfExits = GameController.instance.exits;

        foreach (var pedestrian in pedestriansInScene)
        {
            var randomExit = listOfExits[SethUtils.MathTools.RandomNumberGeneration(0, listOfExits.Count)];
            
            GameObject newPedestrian = Instantiate(pedestrian) as GameObject;
            newPedestrian.transform.position = randomExit.transform.localPosition;
            Debug.Log("NPC Spawned at " + randomExit.name + " and their current target is " + newPedestrian.GetComponent<Pedestrian>()._exitTarget);
            
            yield return new WaitForSeconds(4);
        }
    }
}
