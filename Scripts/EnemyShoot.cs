using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float StartTimeBetweenShots1;
    private float TimeBtwShots1;
    public GameObject pBullet1;//
    public GameObject EnemyBug;//
    public Transform pCommander1;//
    // Start is called before the first frame update
    void Start()
    {
        TimeBtwShots1 = 0f;
        pCommander1 = ObjectReference();
        Physics2D.IgnoreLayerCollision(9, 8);
    }

    private void FixedUpdate()
    {
        shoot(1, 1, 2f);
        shoot(.36f, .3f, 1f);
    }
    void shoot(float x1,float y1,float time)
    {
        if (ifclose(x1, y1))
        {
            if (TimeBtwShots1 <= 0)
            {
                Instantiate(pBullet1, transform.position, Quaternion.identity);
                TimeBtwShots1 = time;
            }
            else
            {
                TimeBtwShots1 -= Time.deltaTime;
            }

        }
    }
    Transform ObjectReference()
    {
        GameObject Object;
        Transform pObject;
        Object = GameObject.Find("Commander");
        pObject = Object.transform;
        return pObject;
    }
    bool ifclose(float x, float y)
    {
        float radiusx;
        float radiusy;
        radiusx = Mathf.Abs(pCommander1.position.x - transform.position.x);
        radiusy = Mathf.Abs(pCommander1.position.y - transform.position.y);
        if (radiusx < x && radiusy < y)
        {
            return true;
        }
        return false;
    }
}


