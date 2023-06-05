using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField]private Vector3 offset;

    private void Awake()
    {
        playerTransform = Player.Instance.transform;
    }


    private void LateUpdate()
    {

        FollowPlayer();
    }
    void FollowPlayer()
    {
        transform.position = playerTransform.position+offset;
    }

}
