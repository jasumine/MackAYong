using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType
{
    PositionFirst,
    Random,
    HpFirst
}

public enum SoldierName
{
    Magician,
    Sheep,
    Tanker,
    Warrior,
    Wolf
}



public class SoldierStat : MonoBehaviour
{
    public GameObject mySlot;

    public string myName;
    public int level = 1;

    public TargetType targetType;

    public float attackSpeed = 2;
    public float curAttackSpeed;

    public bool isDragging = false;
    public bool isMerge = false;
    public bool canMerge = false;


}
