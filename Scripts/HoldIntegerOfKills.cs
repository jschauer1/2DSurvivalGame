using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HoldIntegerOfKills : Toolbox
{
    public Text output;
    int kills;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        kills = count("EnemyBug(Clone)");
        output.text = "Hello," + kills.ToString();
    }
}