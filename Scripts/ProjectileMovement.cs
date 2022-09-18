using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private float speed;
    private Vector2 Target;
    public Transform pBullet;
    public Transform Player;
    public Transform enemyDistance;
    private GameObject enemy;
    private Transform listofenemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = FindClosestEnemy("EnemyBug(Clone)");
        listofenemy = enemy.transform;
        List<Vector2> listOfPosition = new List<Vector2>();
        listOfPosition.Add(listofenemy.position);
        speed = 1f;
        Target = listOfPosition[0];
    }

    // Update is called once per frame
    void Update()
    {
        pBullet.position = Vector2.MoveTowards(pBullet.position, Target, speed * Time.deltaTime);
        if (transform.position.x == Target.x && transform.position.y == Target.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
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
}

