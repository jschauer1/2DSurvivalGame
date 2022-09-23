using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Toolbox : MonoBehaviour
{
    protected Vector2 Startpoint;
    protected float TimeBtwShots;
    //paste in and Control Shift / to uncomment.
    protected Transform ObjectReference(string Reference)
    {
        if (GameObject.Find(Reference) != null)
        {
            Transform Object = GameObject.Find(Reference).transform;
            return Object;
        }
        return null;

    }
    protected void onShoot(GameObject BulletType, string Reference, float speed)
    {
        Transform Target = FindClosestEnemy(Reference).transform;
        Vector2 Enemy = new Vector2(Target.position.x - transform.position.x, Target.position.y - transform.position.y).normalized * speed;
        var proj = Instantiate(BulletType, transform.position, Quaternion.identity);
        Vector2 Projectile = new Vector2(proj.transform.position.x, proj.transform.position.y);
        proj.GetComponent<Rigidbody2D>().velocity = new Vector2(Enemy.x, Enemy.y);
    }
    protected GameObject GameObjectReference(string Reference)
    {
        if (GameObject.Find(Reference) != null)
        {
            GameObject Object = GameObject.Find(Reference);
            return Object;
        }
        return null;
    }
    protected int count(string ObjectCounted)
    {
        GameObject[] counts;
        counts = GameObject.FindGameObjectsWithTag(ObjectCounted);
        return counts.Length;
    }
    protected Vector2 random(float x1, float x2, float y1, float y2)
    {
        Vector2 randoms;
        randoms = new Vector2(Random.Range(x1, x2), Random.Range(y1, y2));
        return randoms;
    }
    protected bool ifclose(float distance)
    {
        Transform pCommander = ObjectReference("Commander");
        Transform closestEnemy = FindClosestEnemy("EnemyBug(Clone)").transform;
        float diffx = (pCommander.position.x - closestEnemy.position.x);
        float diffy = (pCommander.position.y - closestEnemy.position.y);
        float magnitude = (Mathf.Sqrt(Mathf.Pow(diffx, 2) + Mathf.Pow(diffy, 2)));
        if (magnitude < distance) return true;
        else return false;
    }
    protected GameObject FindClosestEnemy(string CloseEnemy)
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
    protected bool DestroyBullet(float x)
    {
        float diffx = (transform.position.x - Startpoint.x);
        float diffy = (transform.position.y - Startpoint.y);
        float magnitude = (Mathf.Sqrt(Mathf.Pow(diffx, 2) + Mathf.Pow(diffy, 2)));
        if (magnitude > x) return true;
        return false;
    }
    protected bool time(float starttime)
    {
        if (TimeBtwShots <= 0)
        {
            TimeBtwShots = starttime;
            return true;
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }
        return false;
    }//time function requires you to have a variable outside function
    protected void DestroyGameObByMag(float x)
    {
        if (DestroyBullet(x))
        {
            Destroy(gameObject);
        }
    }
}
