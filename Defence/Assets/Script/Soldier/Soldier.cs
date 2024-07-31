using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public enum SoldierState
{
    Idle,
    Attack,
    Skill
}


public class Soldier : MonoBehaviour
{    
    private SoldierStat soldierStat;

    public float maxSkillTime;
    public float curSkillTime = 0;


    public SoldierState state;

    public GameObject bulletPrefab;
    public GameObject target;


    private void Start()
    {
        soldierStat = GetComponent<SoldierStat>();
        state = SoldierState.Idle;
    }

    private void Update()
    {
        if(state != SoldierState.Skill)
        {
            SKillCount();
        }
        SetState();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == this.gameObject.tag)
        {
            SoldierStat otherStat = collision.GetComponent<SoldierStat>();

            if (otherStat.level == this.soldierStat.level)
            {
                // dragging true�� ������Ʈ�� �����Ѵ�.
                if(otherStat.isDragging==true)
                {
                    // merge����
                    // 1. otherStat�� �����Ѵ�.(�巡������ ������Ʈ ����) + slot�� �߰�
                    GameManager.GetInstance().slotList.Add(otherStat.mySlot);
                    Destroy(collision.gameObject);
                    // 2. �� ��ġ���� �ٸ� �뺴�� �����Ѵ�.(����)
                    int soldierNum = Random.Range(0, GameManager.GetInstance().soliderPrefabList.Count); // ���� ����
                    
                    // �����뺴�� ���� �뺴�� slot�� ����, list�� �־��ش�.
                    GameObject soldier = Instantiate(GameManager.GetInstance().soliderPrefabList[soldierNum], soldierStat.mySlot.transform);
                    GameManager.GetInstance().InputSoldierList(soldierNum, soldier);

                    // ���λ��� �뺴�� ���� slot������ �־��ش�.
                    SoldierStat stat = soldier.GetComponent<SoldierStat>();
                    stat.mySlot = soldierStat.mySlot;

                    // 3. �ش� �뺴�� �� ������ +1�� ���ش�.
                    SoldierStat mergeSoldierStat = soldier.GetComponent<SoldierStat>();
                    mergeSoldierStat.level = soldierStat.level + 1;


                    // 4. ���� ������Ʈ�� �����.
                    Destroy(this);

                }
                
            }
        }
    }





    private void SetState()
    {
        switch(state)
        {
            case SoldierState.Idle:
                SetTarget();
                break;

            case SoldierState.Attack:
                SetTarget();
                AttackTarget();
                break;

            case SoldierState.Skill:
                UseSkill();
                break;
        }
    }


    private void SKillCount()
    {
        curSkillTime += Time.deltaTime;

        if (curSkillTime > maxSkillTime)
        {
            // ��ų ��Ÿ���� �Ǹ� ��ų�� ����Ѵ�.
            curSkillTime = 0;
            state = SoldierState.Skill;
        }
    }


    private void UseSkill()
    {
       // Debug.Log("��ų�� ����մϴ�.");
        state = SoldierState.Idle;
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

           // Debug.Log(target.name + "�� �����մϴ�.");
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
        if(GameManager.instance.monsterList.Count==0)
        {
            state = SoldierState.Idle;
        }
        else
        {
            state = SoldierState.Attack;
            if (GameManager.instance.monsterList[0] == null
            || GameManager.instance.monsterList[0].activeInHierarchy == false)
            {
                GameManager.instance.monsterList.RemoveAt(0);
            }

            target = GameManager.instance.monsterList[0];
        }
    }

    private void AttackRandom()
    {
        if (GameManager.instance.monsterList.Count == 0)
        {
            state = SoldierState.Idle;
        }
        else
        {
            state = SoldierState.Attack;
            int num = GameManager.instance.monsterList.Count;
            int randNum = Random.Range(0, num);
            if (GameManager.instance.monsterList[randNum] == null
                || GameManager.instance.monsterList[0].activeInHierarchy == false)
            {
                GameManager.instance.monsterList.RemoveAt(randNum);
            }
            target = GameManager.instance.monsterList[randNum];
        }
    }

    private void HpFirst()
    {
        // ������ hp ������ �޾ƿͼ� ���� ���� hp�� Ÿ�������Ѵ�.
        // ���� hp ����, Ÿ������ �ؾߵǴ� i�� ���� ��������
        // hp�� ������ �񱳸��ϰ�, ���������� i�� �Ǵ� ���͸� target���� ���ش�.

        // ���� ����Ʈ�� 0 �̶�� idle�̰�,
        // else��� attack����

        //int higestI;

        //for(int i = GameManager.instance.usingMonsterList.Count -1; i>=0; i--)
        //{
        //    MonsterStat monStat = GameManager.instance.usingMonsterList[i].GetComponent<MonsterStat>();
        //    if (monStat.curHp)
        //}
    }

}
