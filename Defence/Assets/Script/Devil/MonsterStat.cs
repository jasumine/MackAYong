using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    basic,
    special,
    boss
}



public class MonsterStat : MonoBehaviour
{

    public float maxHp;
    public float curHp;

    public float speed;
    public float attackSpeed;

    public MonsterType monsterType;

    private void Start()
    {
        curHp = maxHp;
    }

    public void SetHp(float damage)
    {
        curHp -= damage;
    }
}
