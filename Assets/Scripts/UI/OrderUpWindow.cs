using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using SethUtils;

public class OrderUpWindow : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    Vector2 startPos;

    bool deliverToCustomer;

    public static Action OnAttemptToDeliver;


    private void Awake() 
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        startPos = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.60f;
    }

    public void OnDrag(PointerEventData eventData)
    {
    Debug.Log("OnDrag"); 
    rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        
        OnAttemptToDeliver();

        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        rectTransform.anchoredPosition = startPos;



    }

     public void OnPointerDown(PointerEventData eventData)
     {
         Debug.Log("OnPointerDown");
     }

}
