using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : Toolbox
{
    private float speed;
    private Vector2 Target;
    public Transform pBullet;
    public Transform Player;
    public Transform enemyDistance;
    private GameObject enemy;
    private Transform listofenemy;
    float Startpointx;
    float Startpointy;


    // Update is called once per frame
    // Start is called before the first frame update
    void Start()
    {
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

