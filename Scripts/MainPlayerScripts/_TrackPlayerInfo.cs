using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TrackPlayerInfo 
{
    public static int _SavedMoney = 0;
    public void _totalmoney(int moninput)
    {
        _SavedMoney = _SavedMoney + moninput;
    }
    public int _getmoney()
    {
        return _SavedMoney;
    }

}
