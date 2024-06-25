using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : MonoBehaviour
{
    public float maxHp;
    public float curHp;

    public float speed;

    private void Start()
    {
        curHp = maxHp;
    }


    private void OnGUI()
    {
        if(GUI.Button(new Rect (120, 10, 100, 100), "hp����"))
        {
            IncreaseHp();
        }

        if(GUI.Button(new Rect (120, 120, 100, 100), "speed ����"))
        {
            IncreaseSpeed();
        }
    }

    private void IncreaseHp()
    {
        maxHp++;
        curHp++;
        Debug.Log("hp�� �����մϴ�.");
    }

    private void IncreaseSpeed()
    {
        speed++;
        Debug.Log("�ӵ��� �����մϴ�.");
    }
}
