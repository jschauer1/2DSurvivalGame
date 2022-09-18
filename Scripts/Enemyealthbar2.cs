
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyealthbar2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform Bar = transform.Find("Bar");
        Bar.localScale = new Vector2(.7f, 1f);

    }

    // Update is called once per frame

}

