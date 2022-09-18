using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossmovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public float lookRadiusx;
    public float lookRadiusy;
    public float magnitude;
    public Vector3 randomx;
    public Vector2 randommovement;
    public Transform pCommander;
    public float health;
    public float SpawnPositionx;
    public float SpawnPositiony;
    public float OriginalSpawnx;
    public float OriginalSpawny;
    // Start is called before the first frame update
    void Start()
    {
        pCommander = ObjectReference("Commander");
        rb.rotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ifclose(2, 2))
        {
            rb.rotation = direction() + 90;
           
        }
    }
    bool ifclose(float x, float y)
    {
        float radiusx;
        float radiusy;
        radiusx = Mathf.Abs(pCommander.position.x - transform.position.x);
        radiusy = Mathf.Abs(pCommander.position.y - transform.position.y);
        if (radiusx < x && radiusy < y)
        {
            return true;
        }
        return false;
    }
    float direction()
    {
        Vector2 direction = pCommander.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return angle;
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
