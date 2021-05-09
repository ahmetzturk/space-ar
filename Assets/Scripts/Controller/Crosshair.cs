using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Controller
{
    public class Crosshair : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [HideInInspector] public bool isShooting = false;
        void Start()
        {

        }

        void Update()
        {

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isShooting = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isShooting = false;
        }
    }
}
