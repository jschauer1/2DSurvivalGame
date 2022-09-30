using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboss : Toolbox
{
    public HitPlayer p;
    public float totalHealth1;
    // Start is called before the first frame update
    void Start()
    {
       Transform Commander = ObjectReference("Commander");
        p = Commander.GetComponent<HitPlayer>();
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        totalHealth1 = totalHealth1 - .05f;
        if (totalHealth1 <= .01)
        {
            Destroy(gameObject);
        }
    }
}
