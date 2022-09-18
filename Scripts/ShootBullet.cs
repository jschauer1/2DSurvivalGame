using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public float StartTimeBetweenShots;
    private float TimeBtwShots;
    public GameObject pBullet;//
    public Transform bullet;//


    public bool howclose;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        TimeBtwShots = StartTimeBetweenShots;

    }

    private void FixedUpdate()
    {
        shoot();
    }
    void shoot()
    {
            if (ifclose(1f, 1f))
            {
                if (TimeBtwShots <= 0)
                {
                    Instantiate(pBullet, transform.position, Quaternion.identity);
                    TimeBtwShots = StartTimeBetweenShots;
                }
                else
                {
                    TimeBtwShots -= Time.deltaTime;
                }
            

        }
    }
    GameObject FindClosestEnemy(string CloseEnemy)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(CloseEnemy);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    bool ifclose(float x, float y)
    {
        float radiusx;
        float radiusy;
        Transform pCommander = ObjectReference("Commander");
        Transform closestEnemy = FindClosestEnemy("EnemyBug(Clone)").transform;
        radiusx = Mathf.Abs(pCommander.position.x - closestEnemy.position.x);
        radiusy = Mathf.Abs(pCommander.position.y - closestEnemy.position.y);
        if (radiusx < x && radiusy < y)
        {
            return true;
        }
        return false;
    }
    Transform ObjectReference(string Reference)
    {
        if (GameObject.Find(Reference) != null)
        {
            Transform Object = GameObject.Find(Reference).transform;
            return Object;
        }
        return null;
 
    }

}
        

