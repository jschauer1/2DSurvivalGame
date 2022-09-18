using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovementBoss : MonoBehaviour
{
    public Transform pBullet1;
    public float speed1;
    public Transform pCommander;
    public Transform Enemy;
    public Transform listofenemy;
    public float maxDistance;
    public float MoveSpeed;
    public Rigidbody2D rb;
    public Vector2 position;
    public float Target2;
    public float Target3;
    public Vector2 Target1;
    public Vector2 Target4;
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy;
        Physics2D.IgnoreLayerCollision(8, 8);
        speed1 = 5f;
        maxDistance = 3f;
        enemy = GameObject.Find("Commander");
        listofenemy = enemy.transform;
        List<Vector2> listOfPosition = new List<Vector2>();
        listOfPosition.Add(listofenemy.position);
        Target1 = listOfPosition[0];
        Target2 = Target1.x;
        Target3 = Target1.y;
        Target4 = new Vector2(Target2, Target3);
        MoveSpeed = speed1 * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
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
