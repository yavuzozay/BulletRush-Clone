using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

   private int _damageVal=100;
    public int damageVal { get { return _damageVal; } }
    //Range de�eri 1 ve 5 aras�nda de�er ayarlamam�z� sa�lar.
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
        /*Add force kuvvet uygulamak i�in kullan�l�r.
       * �mpulse modu tek seferlik g�� uygulanaca��nda kullan�l�r.
       * Z�plama,f�rlatma gibi durumlar i�in tercih edilebilir.
       */
        bulletRb.AddForce(transform.forward*power, ForceMode.Impulse);
    }


}
