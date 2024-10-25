using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityData
{
    public int ID;
    public string name;
    public string Type;
    public string Grade;
    public string Discription;
    public string target1;
    public string target2;
    public string EffectType1;
    public int value;
    public bool isActive = false;

    public Action<AbilityEffect> ExecuteAbility;
}


public class AbilityEffect
{
    public void ApplyEffectMethod(int _id, string _name)
    {
        // 효과 적용 로직 구현
        Debug.Log(_id + ", " + _name + " 능력이 적용되었습니다.");
    }
}