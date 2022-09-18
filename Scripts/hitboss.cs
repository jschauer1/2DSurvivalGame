using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboss : MonoBehaviour
{
    public float totalHealth;
    // Start is called before the first frame update
    void Start()
    {
        totalHealth = 1;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        totalHealth = totalHealth - .05f;
        if (totalHealth <= .01)
        {
            Destroy(gameObject);
        }
    }
}
