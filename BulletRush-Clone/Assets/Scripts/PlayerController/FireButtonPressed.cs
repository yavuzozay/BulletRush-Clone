using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireButtonPressed : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    private PlayerController playerController;

    private void Awake()
    {
        playerController = PlayerData.Instance.gameObject.GetComponent<PlayerController>();/*Player data singleton oldu�u i�in bu �ekilde eri�ebiliriz.
                                                                                            * Player tagi ile de eri�ebilirdik..*/
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
