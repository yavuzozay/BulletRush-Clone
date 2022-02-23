using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct Bound
{
    public float maxX;
    public float minX;
    public float maxZ;
    public float minZ;

    public Bound(float maxX, float minX,float maxZ,float minZ)
    {
        this.maxX = maxX;
        this.minX = minX;
        this.maxZ = maxZ;
        this.minZ = minZ;
      
    }
}
public class Bounds : Singleton<Bounds>

{
   
    Bound GameBounds;
    Bound PlayerBounds;

    private void Awake()
    {
       GameBounds= new Bound(15f, -15f, 5f, -15f);
       PlayerBounds= new Bound(8f, -8f, 0f, -6f);
    }

    public Bound GetGameBounds()
    {
        return GameBounds;
    }
    public Bound GetPlayerBounds()
    {
        return PlayerBounds;
    }
    public void CheckBounds(Bound bound,Transform trnsform)
    {
        if (trnsform.position.x<bound.minX  )
        {
            trnsform.position = new Vector3 (bound.minX,trnsform.position.y,trnsform.position.z);
        }
       else if (trnsform.position.x>bound.maxX  )
        {
            trnsform.position = new Vector3(bound.maxX, trnsform.position.y, trnsform.position.z);
        }
        if (trnsform.position.z < bound.minZ)
        {
            trnsform.position = new Vector3(trnsform.position.x, trnsform.position.y, bound.minZ);
        }
        else if (trnsform.position.z > bound.maxZ)
        {
            trnsform.position = new Vector3(trnsform.position.x, trnsform.position.y, bound.maxZ);

        }


    }

}
