using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar1 : MonoBehaviour
{

    public hitboss Script;
    // Start is called before the first frame update
    void Update()
    {
        Transform Bar = transform.Find("Bar");
        Bar.localScale = new Vector2(Script.totalHealth1, 1f);

    }

}
