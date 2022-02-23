using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

   private int _damageVal=100;
    public int damageVal { get { return _damageVal; } }
    //Range deðeri 1 ve 5 arasýnda deðer ayarlamamýzý saðlar.
    //                     min,max value
    [SerializeField][Range(1f,5f)] private float speed;
    Rigidbody bulletRb;

    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        ThrowBullet(speed);
      
    }
    private void ThrowBullet(float power)
    {
        /*Add force kuvvet uygulamak için kullanýlýr.
       * Ýmpulse modu tek seferlik güç uygulanacaðýnda kullanýlýr.
       * Zýplama,fýrlatma gibi durumlar için tercih edilebilir.
       */
        bulletRb.AddForce(transform.forward*power, ForceMode.Impulse);
    }


}
