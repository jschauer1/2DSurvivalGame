using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : Toolbox
{
    public Transform pBullet;
    public Transform Player;
    public Transform enemyDistance;
    void Start()
    {
        Startpoint = transform.position;
    }
    void FixedUpdate()
    {
        if (DestroyBullet(3))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}

