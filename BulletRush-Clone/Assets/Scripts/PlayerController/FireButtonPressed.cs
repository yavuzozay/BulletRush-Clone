using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireButtonPressed : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    private PlayerController playerController;

    private void Awake()
    {
        playerController = PlayerData.Instance.gameObject.GetComponent<PlayerController>();/*Player data singleton olduðu için bu þekilde eriþebiliriz.
                                                                                            * Player tagi ile de eriþebilirdik..*/
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
