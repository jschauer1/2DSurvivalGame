using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitboss : MonoBehaviour
{
    public float totalHealth;
    public Vector2 position;
    public float timer;
    public float StartTimer;
    public float canTakeDamage;
    // Start is called before the first frame update
    void Start()
    {
        totalHealth = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
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
