using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public int maxHp;
    public int curHp;


    private void Start()
    {
        curHp = maxHp;
    }

    public void SetHp(int value)
    {
        curHp += value;
    }
    public int GetHp()
    {
        return curHp;
    }

    public void SetMaxHp(int value)
    {
        maxHp += value;
    }

    
}
