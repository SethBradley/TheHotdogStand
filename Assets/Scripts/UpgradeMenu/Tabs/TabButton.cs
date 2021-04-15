using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
namespace TheHotdogStand
{
    //Guarantee image is part of the button
    [RequireComponent(typeof(Image))]
    public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        public TabGroup tabGroup;
        public Image background;
        public UnityEvent onTabSelected;
        public UnityEvent onTabDeselected;


        private void Start() 
        {
            background = GetComponent<Image>();
            tabGroup.Subscribe(this);
        }

        public void Select()
        {
            if (onTabSelected != null)
            {
                onTabSelected.Invoke();
            }
        }

        public void Deselect()
        {
            if (onTabDeselected != null)
            {
                onTabDeselected.Invoke();
            }
        }



        public void OnPointerClick(PointerEventData eventData)
        {
            tabGroup.onTabSelected(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tabGroup.onTabEnter(this);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tabGroup.onTabExit(this);
        }


    }
}
