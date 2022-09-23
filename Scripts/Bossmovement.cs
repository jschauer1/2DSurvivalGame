using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossmovement : Toolbox
{
    public Rigidbody2D rb;
    private Transform pCommander;

    // Start is called before the first frame update
    void Start()
    {
        pCommander = ObjectReference("Commander");
        rb.rotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ifclose(2))
        {
            rb.rotation = direction() + 90;
           
        }
    }

    float direction()
    {
        Vector2 direction = pCommander.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return angle;
    }
}

