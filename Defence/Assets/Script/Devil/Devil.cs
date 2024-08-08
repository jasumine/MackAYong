using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil : MonoBehaviour
{
    public float maxSKillTime;
    public float curSkillTime;

    public bool isUseSkill;


    private void Start()
    {
        isUseSkill = true;
    }

    private void Update()
    {
        if (isUseSkill == false)
        {
            SkillCount();
        }
    }

    private void SkillCount()
    {
        curSkillTime += Time.deltaTime;

        if (curSkillTime > maxSKillTime)
        {
            isUseSkill = true;
            curSkillTime = 0;
        }
    }


    public void UseSkill()
    {
        if (isUseSkill == true)
        {
            isUseSkill = false;

            Debug.Log("마왕 스킬을 사용합니다.");
        }
    }
}
