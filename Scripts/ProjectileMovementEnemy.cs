using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovementEnemy : Toolbox
{
    
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(7, 8);
        Physics2D.IgnoreLayerCollision(13, 8);
        Startpoint = transform.position;

    }

    // Update is called once per frame
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


