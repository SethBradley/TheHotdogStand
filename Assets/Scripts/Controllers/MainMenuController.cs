using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SethUtils;
public class MainMenuController : MonoBehaviour
{
    public Camera mainCam;
    public bool showMenuSelection;


    //Camera Movement
    Vector3 startRotation;
    Vector3 startPosition;
    float CameraLerpProgress;

    
    private void Awake() 
    {
        showMenuSelection = false;
        
        startRotation = mainCam.transform.rotation.eulerAngles;
        startPosition = mainCam.transform.position;
        CameraLerpProgress = 0f;
        
    }

    private void Update() 
    {
        RaycastHit hit; 
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (showMenuSelection == false)
                {

                    StartCoroutine(CameraMoving());
                    showMenuSelection = true;
                    return;
                }
            
                var touchedInteractable = hit.transform.name;
            }
        }
    }





//Camera Control Methods
    private bool MoveCameraToMenuSelection()
    {
        Debug.Log("MoveCameraToSelection;");
        
        var targetRotation = new Vector3(3.42f, -37.7f, 0f);
        var targetPosition = new Vector3(-12.626f, 0.894f, -9.922f); 
        

        mainCam.transform.rotation = Quaternion.Euler(SethUtils.PhysicsTools.ProperLerpRotation(startRotation, targetRotation, CameraLerpProgress));
        mainCam.transform.position = SethUtils.PhysicsTools.ProperLerpRotation(startPosition, targetPosition, CameraLerpProgress);

        CameraLerpProgress += Time.deltaTime * 2f;

        if (Time.deltaTime >= 2f)
        {
            Debug.Log("Camera arrived at destination");
            return true;
        }

        return false;
    }

    IEnumerator CameraMoving()
    {
        Debug.Log("Begin Coroutine");
        yield return new WaitUntil(MoveCameraToMenuSelection);
        Debug.Log("Coroutine Finished");
    }
}
