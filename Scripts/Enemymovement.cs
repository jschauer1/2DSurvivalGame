using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    public float moveSpeed;
    public float lookRadiusx;
    public float direction;
    public float lookRadiusy;
    public float magnitude;
    public Vector3 randomx;
    public Vector2 randommovement;
    private float moves;
    private Transform Commander;
    public float health;
    public float SpawnPositionx;
    public float SpawnPositiony;
    public float OriginalSpawnx;
    public float OriginalSpawny;
    public Vector2 check;
    public Vector2 checktime;
    public float NotChangeTimeBtwCheck;
    public float TimeBtwCheck;
    void Start()
    {
        onstart();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        test();
        move();
        
    }

    void onstart()
    {
        health = 1f;
        moveSpeed = 1f;
        SpawnPositionx = transform.position.x + 1f;
        SpawnPositiony = transform.position.y + 1f;
        OriginalSpawnx = transform.position.x;
        OriginalSpawny = transform.position.y;
        Commander = ObjectReference("Commander");
        randomx = random(SpawnPositionx, OriginalSpawnx, SpawnPositiony, OriginalSpawny);
        TimeBtwCheck = .5f;
        NotChangeTimeBtwCheck = TimeBtwCheck;
    }
    void move() 
    {
        moves = moveSpeed * Time.deltaTime;
        if (health <= 0.01f)
        {
            Destroy(gameObject);
        }
        if (ifclose(1, 1))
        {
            transform.position = Vector2.MoveTowards(transform.position, Commander.position, moves);

        }
        else
        {
            if (transform.position != randomx)
            {
                transform.position = Vector2.MoveTowards(transform.position, randomx, moves);
            }
            else
            {
                randomx = random(SpawnPositionx, OriginalSpawnx, SpawnPositiony, OriginalSpawny);
            }
        }
    }
    void test()
    {
        check = transform.position;//Saved for the check
        float automatic = NotChangeTimeBtwCheck / 2;
        if (Mathf.Approximately(Mathf.Round(TimeBtwCheck*10), Mathf.Round(automatic*10)))//Checks if the time is one, Eventually checks if bots is moving
        {
            checktime = transform.position;//gets a value to store and check with a constantly updating version(the variable check)
        }
        else if (TimeBtwCheck <= 0)
        {
            if (ifclose(1, 1) == false)
            {
                if (Mathf.Round((check.x * 100)) == Mathf.Round(checktime.x * 100) && Mathf.Round((check.y * 100)) == Mathf.Round(checktime.y * 100))
                {
                    randomx = random(SpawnPositionx, OriginalSpawnx, SpawnPositiony, OriginalSpawny);
                }
            }
            TimeBtwCheck = NotChangeTimeBtwCheck;
        }
      TimeBtwCheck -= Time.deltaTime;
    }
    Vector2 random(float x1, float x2,float y1,float y2)
    {
        Vector2 randoms;
        randoms = new Vector2(Random.Range(x1, x2), Random.Range(y1, y2));
        return randoms;
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
    bool ifclose(float x, float y)
    {
        float radiusx;
        float radiusy;
        radiusx = Mathf.Abs(Commander.position.x - transform.position.x);
        radiusy = Mathf.Abs(Commander.position.y - transform.position.y);
        if (radiusx < x && radiusy < y)
        {
            return true;
        }
        return false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        health = health - .2f;
    }
}