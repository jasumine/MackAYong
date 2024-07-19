using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType
{
    PositionFirst,
    Random,
    HpFirst
}



public class SoldierStat : MonoBehaviour
{

    public TargetType targetType;

    public float attackSpeed;
    public float curAttackSpeed;
}
