
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : Toolbox
{
    public Enemymovement script;
    public Transform Bar;
    // Start is called before the first frame update
    void Update()
    {
        Bar.localScale = new Vector2(script.health, 1f);
    }


}

