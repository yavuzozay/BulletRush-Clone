using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireButtonPressed : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    private PlayerController playerController;

    private void Awake()
    {
        playerController = Player.Instance.gameObject.GetComponent<PlayerController>();
    }
   
    public void OnPointerDown(PointerEventData eventData)
    {
        playerController.isFireBtnPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerController.isFireBtnPressed = false;

    }
}
