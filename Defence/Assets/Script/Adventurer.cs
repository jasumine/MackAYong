using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : MonoBehaviour
{
    public float maxHp = 3;
    public float curHp;


    private void Start()
    {
        curHp = maxHp;
    }


    public void SetHealth()
    {
        curHp--;
        Debug.Log("모험가 진영 체력 : " + curHp);
    }
}
