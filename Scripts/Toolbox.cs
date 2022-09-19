using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Toolbox : MonoBehaviour
{
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
    protected bool ifclose(float x, float y)
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
}
