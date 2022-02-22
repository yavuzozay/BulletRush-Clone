using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField] protected float _healValue;
    [SerializeField] protected float _speed;
    [SerializeField]private GameObject particleEffect;

    //Diðer classlardan eriþilebilir fakat deðiþtirilemez.
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
    private void Die()
    {
            Destroy(this.gameObject, .35f);
    }
    //Patlama efekti
    public virtual void OnDestroy()
    {
        Instantiate(particleEffect, transform.position, particleEffect.transform.rotation);
    }

    protected abstract void Movement();

}
