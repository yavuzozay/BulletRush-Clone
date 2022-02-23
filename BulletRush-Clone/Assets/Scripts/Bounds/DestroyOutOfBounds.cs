using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private void Update()
    {
        Destroy();
    }

    void Destroy()
    {
        if(transform.position.x<Bounds.Instance.GetGameBounds().minX-1 || transform.position.x > Bounds.Instance.GetGameBounds().maxX + 1 ||
            transform.position.z < Bounds.Instance.GetGameBounds().minZ - 1 || transform.position.z > Bounds.Instance.GetGameBounds().maxZ +1 )
        {
            Destroy(gameObject);
        }
    }

}
