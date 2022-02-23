using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField] protected float _healValue;
    [SerializeField] protected float _speed;
    [SerializeField]private GameObject particleEffect;

    //Diğer classlardan erişilebilir fakat değiştirilemez.
    public float healValue
    {
        get { return _healValue; }
    }

    private void Update()
    {
        if (healValue <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {

        Instantiate(particleEffect, transform.position, particleEffect.transform.rotation);

        Destroy(this.gameObject, .35f);
    }
 

    protected abstract void Movement();

}
