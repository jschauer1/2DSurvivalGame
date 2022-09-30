using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyHealthBar : MonoBehaviour
{
     public FriendlyShoot Script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform Bar = transform.Find("Bar");
        Bar.localScale = new Vector2(Script.totalHealth, 1f);
    }
}
