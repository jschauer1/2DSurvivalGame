using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller2 : MonoBehaviour
{     
    Rigidbody2D rb;
    public float walkSpeed = 50f;
    float speedLimiter = 0.7f;
    float Horizontal;
    float Vertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        if (Horizontal != 0 && Vertical != 0)
        {
            Horizontal *= speedLimiter;
            Vertical *= speedLimiter;
        }
          
        rb.velocity = new Vector2(Horizontal * walkSpeed, Vertical * walkSpeed);
    }

}

