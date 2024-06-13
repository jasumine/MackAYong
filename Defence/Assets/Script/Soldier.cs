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
        // ���ݼӵ��� ����ؼ� �����ϱ�.
        Debug.Log(target.name + "�� �����մϴ�.");
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
        // ������ hp ������ �޾ƿͼ� ���� ���� hp�� Ÿ�������Ѵ�.
        // ���� hp ����, Ÿ������ �ؾߵǴ� i�� ���� ��������
        // hp�� ������ �񱳸��ϰ�, ���������� i�� �Ǵ� ���͸� target���� ���ش�.

        //int higestI;

        //for(int i = GameManager.instance.usingMonsterList.Count -1; i>=0; i--)
        //{
        //    MonsterStat monStat = GameManager.instance.usingMonsterList[i].GetComponent<MonsterStat>();
        //    if (monStat.curHp)
        //}
    }

}
