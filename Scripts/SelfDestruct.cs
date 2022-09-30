using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : Toolbox
{
    Vector2 startPoint;
    Transform Boss;
    float Startpointx;
    float Startpointy;
    // Start is called before the first frame update
    void Start()
    {
        Boss = ObjectReference("FirstBoss");
        Startpointx = transform.position.x;
        Startpointy = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (DestructDistance(3))
        {
            Destroy(gameObject);
        }
    }
    bool DestructDistance(float x)
    {
        float diffx = (transform.position.x - Startpointx);
        float diffy = (transform.position.y - Startpointy);
        float magnitude = (Mathf.Sqrt(Mathf.Pow(diffx, 2) + Mathf.Pow(diffy, 2)));
        if (magnitude > x) return true;
        else return false;
    }
}
