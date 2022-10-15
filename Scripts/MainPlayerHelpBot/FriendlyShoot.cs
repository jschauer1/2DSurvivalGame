using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyShoot : Toolbox
{
    [SerializeField]GameObject Bullet;
    public float totalHealth;
    [SerializeField]Rigidbody2D rb;
    _Time timer = new _Time();
    Transform Commander;
    OnBulletCollisionPlayer p;
    // Start is called before the first frame update
    void Start()
    {
        Commander = ObjectReference("Commander");
        Physics2D.IgnoreLayerCollision(6, 7);
        TimeBtwShots = 1;
        totalHealth = 1;
        p = Commander.GetComponent<OnBulletCollisionPlayer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (ifclose(1.5f, "EnemyBug(Clone)"))
       {
            rb.rotation = direction() + 90;
            if (timer._wait(1))
            {
                onShoot(Bullet, "EnemyBug(Clone)", 5f);
            }
       }
        rb.velocity = new Vector2(0, 0);
        if (p.dead1 != 0)
        {
            Destroy(gameObject);
            p.dead1 = p.dead1 - 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        totalHealth = totalHealth - .15f;
        if (totalHealth <= .01)
        {
            Destroy(gameObject);
        }
    }
    float direction()
    {
        Vector2 direction = FindClosestEnemy("EnemyBug(Clone)").transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return angle;
    }
}
