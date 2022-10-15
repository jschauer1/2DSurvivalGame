using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Time
{
    float _TimeBtwShots;
    bool check;
    // Start is called before the first frame update
    public _Time() //Sets these paramaters on object call
    {
        _TimeBtwShots = 0;
        check = true;
    }
    public void _startmodify(float atStart)//Allows for the changing of the start time of a _Time object.
    {
        if (check == true)
        {
            _TimeBtwShots = atStart;
        }
        check = false;
    }
   public bool _wait(float starttime1) //Controls the timer aspect of _Time objects
    {
        if (_TimeBtwShots <= 0)
        {
            _TimeBtwShots = starttime1;
            return true;
        }
        else
        {
            _TimeBtwShots -= Time.deltaTime;
        }
        return false;
    }
    public void reset(float resettime)
    {
        _TimeBtwShots = resettime;
    }
    //Last recommendation is to check out the BossShoot1 script. I created a awesome player prediction algorithm! :)

}
