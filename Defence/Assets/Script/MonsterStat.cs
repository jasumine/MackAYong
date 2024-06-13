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

}
