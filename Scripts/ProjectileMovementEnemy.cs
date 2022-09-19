using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovementEnemy : Toolbox
{
    public Transform pBullet1;//
    private float speed1;
    private float MoveSpeed;
    private Vector2 Target1;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 8);
        Physics2D.IgnoreLayerCollision(7, 8);
        speed1 = 1f;
        Transform enemy = ObjectReference("Commander");
        Target1 = enemy.position;
        MoveSpeed = speed1 * Time.deltaTime;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shoot();
    }
    void shoot()
    {
        if (pBullet1.position.x == Target1.x && pBullet1.position.y == Target1.y)
        {
            Destroy(gameObject);
        }
        pBullet1.position = Vector2.MoveTowards(pBullet1.position, Target1, MoveSpeed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }


}


