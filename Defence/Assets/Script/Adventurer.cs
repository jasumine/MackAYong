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
        Debug.Log("���谡 ���� ü�� : " + curHp);
    }
}
