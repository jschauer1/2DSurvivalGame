using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public float StartTimeBetweenShots;
    private float TimeBtwShots;
    public GameObject pBullet;
    public Transform bullet;
    public GameObject[] pEnemy;
    public Transform Enemy;
    public int p;
    public SpawnEnemy Script;
    public int r;
    public float listexceptiontimer;
    public GameObject closestEnemy;
    public Transform pCommander;
    public Transform EnemyBoss;


    Transform ObjectReference(string Reference)
    {
        if (GameObject.Find(Reference) != null)
        {
            Transform Object = GameObject.Find(Reference).transform;
            return Object;
        }
        return null;

    }
    GameObject GameObjectReference(string Reference)
    {
        if (GameObject.Find(Reference) != null)
        {
            GameObject Object = GameObject.Find(Reference);
            return Object;
        }
        return null;
    }
    int count(string ObjectCounted)
    {
        GameObject[] counts;
        counts = GameObject.FindGameObjectsWithTag(ObjectCounted);
        return counts.Length;
    }
    Vector2 random(float x1, float x2, float y1, float y2)
    {
        Vector2 randoms;
        randoms = new Vector2(Random.Range(x1, x2), Random.Range(y1, y2));
        return randoms;
    }
    bool ifclose(float x, float y)
    {
        float radiusx;
        float radiusy;
        //closestEnemy = FindClosestEnemy("EnemyBug(Clone)");
        Enemy = closestEnemy.transform;
        radiusx = Mathf.Abs(pCommander.position.x - Enemy.position.x);
        radiusy = Mathf.Abs(pCommander.position.y - Enemy.position.y);
        if (radiusx < x && radiusy < y)
        {
            return true;
        }
        return false;
    }
}
