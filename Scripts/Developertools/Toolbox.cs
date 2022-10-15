using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Toolbox : MonoBehaviour
{
    protected Vector2 Startpoint;
    protected float TimeBtwShots;
    //Control Shift to uncomment group.
    protected void onShoot(GameObject BulletType, string Reference, float speed)//Shoots a bullet at enemy type
    {
            Transform Target = FindClosestEnemy(Reference).transform;
            Vector2 Enemy = new Vector2(Target.position.x - transform.position.x, Target.position.y - transform.position.y).normalized * speed;
            var proj = Instantiate(BulletType, transform.position, Quaternion.identity);
            proj.GetComponent<Rigidbody2D>().velocity = new Vector2(Enemy.x, Enemy.y);
    }
    protected bool ifclose(float distance, string OtherObject)//Checks a radius between the two most common gameobjects
    {
        Vector2 PositionOfObject = transform.position;
        Transform closestEnemy = FindClosestEnemy(OtherObject).transform;
        float diffx = (PositionOfObject.x - closestEnemy.position.x);
        float diffy = (PositionOfObject.y - closestEnemy.position.y);
        float magnitude = (Mathf.Sqrt(Mathf.Pow(diffx, 2) + Mathf.Pow(diffy, 2)));
        if (magnitude < distance) return true;
        else return false;
    }
    protected GameObject FindClosestEnemy(string CloseEnemy)//Identifies closest enemy
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
    protected Transform ObjectReference(string Reference)//Allows for easy Game Object Referencing, checking if null
    {
        if (GameObject.Find(Reference) != null)
        {
            Transform Object = GameObject.Find(Reference).transform;
            return Object;
        }
        return null;

    }

    protected int count(string ObjectCounted)//Counts how many gameobjects of a specific tag exist
    {
        GameObject[] counts;
        counts = GameObject.FindGameObjectsWithTag(ObjectCounted);
        return counts.Length;
    }
    protected Vector2 random(float x1, float x2, float y1, float y2)//Makes randomizing within a range faster and more intuitive
    {
        Vector2 randoms;
        randoms = new Vector2(Random.Range(x1, x2), Random.Range(y1, y2));
        return randoms;
    }
    protected bool DestroyBullet(float x)//Allows for easy destruction of gameobject based on startposition.
    {
        float diffx = (transform.position.x - Startpoint.x);
        float diffy = (transform.position.y - Startpoint.y);
        float magnitude = (Mathf.Sqrt(Mathf.Pow(diffx, 2) + Mathf.Pow(diffy, 2)));
        if (magnitude > x) return true;
        return false;
    }
    
    //The time class script is a also used significantly. Definetly take a look at that to understand code better
}
