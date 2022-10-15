using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBulletCollisionBoss : Toolbox
{
    public OnBulletCollisionPlayer p;
    public float totalHealth1;
    _TrackPlayerInfo addmon = new _TrackPlayerInfo();
    // Start is called before the first frame update
    void Start()
    {
       Transform Commander = ObjectReference("Commander");
        p = Commander.GetComponent<OnBulletCollisionPlayer>();
        totalHealth1 = 1;
    }
    void FixedUpdate()
    {
        if (p.dead == 1)
        {
            totalHealth1 = 1;
            p.dead = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.CompareTag("CommanderBullet"))
        {
            totalHealth1 = totalHealth1 - .05f;
            if (totalHealth1 <= .01)
            {
                addmon._totalmoney(10);
                Destroy(gameObject);
            }
        }

    }
}
