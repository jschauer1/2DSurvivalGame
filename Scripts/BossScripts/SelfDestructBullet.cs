using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructBullet : Toolbox
{
    float Startpointx;
    float Startpointy;
    // Start is called before the first frame update
    void Start()
    {
        Startpointx = transform.position.x;
        Startpointy = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (DestroyBullet(3))
        {
            Destroy(gameObject);
        }
    }

}
