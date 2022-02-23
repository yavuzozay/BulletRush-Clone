using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField]private Vector3 offset;

    private void Awake()
    {
        playerTransform = PlayerData.Instance.transform;
    }


    private void LateUpdate()
    {

        //Lateupdate updateden sonra çalýþýr bu sayede jittering yaþamayýz..
        FollowPlayer();
    }
    void FollowPlayer()
    {
        transform.position = playerTransform.position+offset;
    }

}
