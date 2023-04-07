using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.UIButtons
{
    public class ControlButtons : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
    {
        public float Direction { get; private set; }
        public void OnPointerDown(PointerEventData eventData)
        {
            Direction = 1;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Direction = 0;
        }
    }
}