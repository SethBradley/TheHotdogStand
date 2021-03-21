using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SethUtils;
public class MainMenuController : MonoBehaviour
{
    public Camera mainCam;
    public bool showMenuSelection;
    public static MainMenuController instance;


    //Camera Movement and UI
    [Header("Camera Movement & UI")]
    public GameObject tapToContinueWindow;
    Vector3 startRotation;
    Vector3 startPosition;
    float CameraLerpProgress;

    //Windows
    [Header("Windows")]
    public IMenuWindow activeWindow;
    public GameObject goBackButton;

    
    private void Awake() 
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else 
            instance = this;   
        
        showMenuSelection = false;
        
        startRotation = mainCam.transform.rotation.eulerAngles;
        startPosition = mainCam.transform.position;
        CameraLerpProgress = 0f;
        
    }

    private void Update() 
    {


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit; 
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (showMenuSelection == false)
                {
                    tapToContinueWindow.SetActive(false);
                    StartCoroutine(CameraMoving());

                    showMenuSelection = true;
                    return;
                }
            }
        }

        if (activeWindow != null)
        {
            activeWindow.onOpen();
        }
    }





//Camera Control Methods
    private bool MoveCameraToMenuSelection()
    {
       
        var targetRotation = new Vector3(3.42f, -37.7f, 0f);
        var targetPosition = new Vector3(-12.626f, 0.894f, -9.922f); 
        

        mainCam.transform.rotation = Quaternion.Euler(SethUtils.PhysicsTools.ProperLerpRotation(startRotation, targetRotation, CameraLerpProgress));
        mainCam.transform.position = SethUtils.PhysicsTools.ProperLerpRotation(startPosition, targetPosition, CameraLerpProgress);

        CameraLerpProgress += Time.deltaTime * 2f;
        
        if (CameraLerpProgress >= 2f)
        {
            return true;
        }

        return false;
    }

    IEnumerator CameraMoving()
    {
        yield return new WaitUntil(MoveCameraToMenuSelection);
    }
}
