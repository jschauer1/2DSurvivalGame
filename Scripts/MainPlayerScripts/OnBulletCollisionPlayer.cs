using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBulletCollisionPlayer : Toolbox
{
    public float totalHealth;
    private Vector2 position;
    public int dead;
    public int dead1;
    _TrackPlayerInfo checkmon = new _TrackPlayerInfo();

    // Start is called before the first frame update
    void Start()
    {
        totalHealth = 1;
        position = new Vector2(0, 0);
    }
    public void _OnHeal()
    {
        if (totalHealth != 1)
        {
            if (checkmon._getmoney() >= 2)
            {
                totalHealth = 1;
                checkmon._totalmoney(-2);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        totalHealth = totalHealth - .1f;

        if (totalHealth <= .01)
        {
            float check2 = checkmon._getmoney();
            transform.position = position;
            totalHealth = 1;
            dead++;
            checkmon._totalmoney(-Mathf.CeilToInt(check2 / 2)) ;
            dead1 = count("Commander") - 1;
        }
    }
}


