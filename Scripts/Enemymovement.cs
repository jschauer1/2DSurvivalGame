using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : Toolbox
{
    private float moveSpeed;
    private Vector3 randomx;
    private float moves;
    private Transform Commander;
    public float health;
    private float SpawnPositionx;
    private float SpawnPositiony;
    private float OriginalSpawnx;
    private float OriginalSpawny;
    private Vector2 check;
    private Vector2 checktime;
    private float NotChangeTimeBtwCheck;
    private float TimeBtwCheck;
    [SerializeField] Rigidbody2D rb;
    void Start()
    {
        onstart();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        test();
        move();
        rb.velocity = new Vector2(0f, 0f);
    }

    void onstart()
    {
        health = 1f;
        moveSpeed = .8f;
        SpawnPositionx = transform.position.x + 1f;
        SpawnPositiony = transform.position.y + 1f;
        OriginalSpawnx = transform.position.x;
        OriginalSpawny = transform.position.y;
        randomx = random(SpawnPositionx, OriginalSpawnx, SpawnPositiony, OriginalSpawny);
        TimeBtwCheck = .5f;
        NotChangeTimeBtwCheck = TimeBtwCheck;
    }
    void move() 
    {
        Commander = FindClosestEnemy("Commander").transform;
        moves = moveSpeed * Time.deltaTime;
        if (health <= 0.01f)
        {
            Destroy(gameObject);
        }
        if (ifclose(1))
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
            if (ifclose(1) == false)
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        health = health - .2f;
    }
}