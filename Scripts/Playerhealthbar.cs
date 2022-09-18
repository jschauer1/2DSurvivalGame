using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhealthbar : MonoBehaviour
{
    public HitPlayer Script;
    // Start is called before the first frame update
    void Update()
    {
        Transform Bar = transform.Find("Bar");
        Bar.localScale = new Vector2(Script.totalHealth, 1f);

    }

    // Update is called once per frame

}

