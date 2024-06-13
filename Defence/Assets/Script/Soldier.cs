using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soldier : MonoBehaviour
{    
    private SoldierStat soldierStat;
    public GameObject target;

    private void Start()
    {
        soldierStat = GetComponent<SoldierStat>();
    }

    private void Update()
    {
        SetTarget();
        AttackTarget();
    }

    private void AttackTarget()
    {
        // 공격속도를 고려해서 공격하기.
        Debug.Log(target.name + "을 공격합니다.");
    }


    private void SetTarget()
    {
        switch (soldierStat.targetType)
        {
            case TargetType.PositionFirst:
                AttackPositionFirst();
                break;

            case TargetType.Random:
                AttackRandom();
                break;

            case TargetType.HpFirst:
                HpFirst();
                break;
        }
    }



    private void AttackPositionFirst()
    {
        target = GameManager.instance.usingMonsterList[0];
    }

    private void AttackRandom()
    {
        int num = GameManager.instance.usingMonsterList.Count;

        int randNum = Random.Range(0,num);

        target = GameManager.instance.usingMonsterList[randNum];
    }

    private void HpFirst()
    {
        // 몬스터의 hp 정보를 받아와서 가장 높은 hp를 타겟으로한다.
        // 비교할 hp 값과, 타겟으로 해야되는 i의 값을 저장한후
        // hp의 값으로 비교를하고, 최종적으로 i가 되는 몬스터를 target으로 해준다.

        //int higestI;

        //for(int i = GameManager.instance.usingMonsterList.Count -1; i>=0; i--)
        //{
        //    MonsterStat monStat = GameManager.instance.usingMonsterList[i].GetComponent<MonsterStat>();
        //    if (monStat.curHp)
        //}
    }

}
