using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField] protected float _healValue;
    [SerializeField] protected float _speed;
    private Bullet bullet;
    private Animator animator;

    //Diðer classlardan eriþilebilir fakat deðiþtirilemez.
    public float healValue
    {
        get { return _healValue; }
    }
    public void ChangeHP(int amount)
    {
       _healValue -= amount;
        if (_healValue < 0)
            _healValue = 0;

    }
    private void Update()
    {
        if (healValue <= 0)
        {
            Die();
        }
        Bounds.Instance.CheckBounds(Bounds.Instance.GetGameBounds(), transform);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
           
            bullet = other.gameObject.GetComponent<Bullet>();
            if (bullet != null)
                ChangeHP(bullet.damageVal);
            Destroy(other.gameObject);
        }
    }
   public abstract void Die();
    


    protected abstract void Movement();

}
