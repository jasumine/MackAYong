using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Soldier : MonoBehaviour
{    
    private SoldierStat soldierStat;


    public GameObject bulletPrefab;
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
        soldierStat.curAttackSpeed += Time.deltaTime;

        if (soldierStat.curAttackSpeed >= soldierStat.attackSpeed)
        {

            soldierStat.curAttackSpeed = 0;

            GameObject bullet = Instantiate(bulletPrefab, this.transform);

            SoldierBullet soldierBullet = bullet.GetComponent<SoldierBullet>();

            soldierBullet.SetTarget(target);

            Debug.Log(target.name + "�� �����մϴ�.");
        }

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
        if (GameManager.instance.monsterList[0] == null 
            || GameManager.instance.monsterList[0].activeInHierarchy==false)
        {
            GameManager.instance.monsterList.RemoveAt(0);
        }

        target = GameManager.instance.monsterList[0];
    }

    private void AttackRandom()
    {
        int num = GameManager.instance.monsterList.Count;
        int randNum = Random.Range(0,num);
        if (GameManager.instance.monsterList[randNum] == null 
            || GameManager.instance.monsterList[0].activeInHierarchy == false)
        {
            GameManager.instance.monsterList.RemoveAt(randNum);
        }
        target = GameManager.instance.monsterList[randNum];
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
