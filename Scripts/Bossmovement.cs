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
        if (ifclose(3))
        {
            rb.rotation = direction() + 90;
           
        }
        else
        {
            rotateto();
            rb.velocity = new Vector2(0f, 0f);
            rb.angularVelocity = 0;
        }
    }
    void rotateto()
    {
        Quaternion neededrotation = Quaternion.LookRotation((new Vector3(0, 0, 1)));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, neededrotation, Time.deltaTime * 10f);
    }
    float direction()
    {
        Vector2 direction = pCommander.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return angle;
    }
}

