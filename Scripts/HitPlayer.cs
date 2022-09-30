using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : Toolbox
{
    public float totalHealth;
    private Vector2 position;
    public int dead;
    public int dead1;
    // Start is called before the first frame update
    void Start()
    {
        totalHealth = 1;
        position = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        totalHealth = totalHealth - .2f;
        if (totalHealth <= .01)
        {
            transform.position = position;
            totalHealth = 1;
            dead++;
            dead1 = count("Commander") - 1;
        }
    }
}


