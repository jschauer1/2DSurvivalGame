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
        Startpoint = transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DestroyGameObByMag(2);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }


}


