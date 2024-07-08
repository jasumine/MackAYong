using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : MonoBehaviour
{
    public float maxHp;
    public float curHp;

    public float speed;
    public float attackSpeed;

    private void Start()
    {
        curHp = maxHp;
    }

    public void SetHp(float damage)
    {
        curHp -= damage;
    }
}
