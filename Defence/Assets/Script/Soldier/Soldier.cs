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

    private void OnTriggerStay2D(Collider2D collision)
    {
        SoldierStat otherStat = collision.GetComponent<SoldierStat>();

        if (otherStat.myName == this.soldierStat.myName)
        {
            if (otherStat.level == this.soldierStat.level)
            {
                // 같은 용병이고, 레벨이 같으면 합성이 가능하다.
                soldierStat.isMerge = true;

                // 합성이 가능하다면 drag중인 오브젝트이다. drag중인 오브젝트를 삭제
                if (otherStat.canMerge == true)
                {
                    // merge진행
                    // 1. other을 삭제한다.(드래그중인 오브젝트 삭제) + slot 추가(빈 슬롯이기 때문)
                    GameManager.GetInstance().slotList.Add(otherStat.mySlot);
                    Destroy(collision.gameObject);

                    // 2. 내 위치에서 다른 용병을 생성한다.(랜덤)
                    int soldierNum = Random.Range(0, GameManager.GetInstance().soliderPrefabList.Count); // 랜덤 선택

                    // 랜덤용병을 현재 용병의 slot에 생성, list에 넣어준다.
                    GameObject mergesoldier = Instantiate(GameManager.GetInstance().soliderPrefabList[soldierNum], soldierStat.mySlot.transform);
                    GameManager.GetInstance().InputSoldierList(soldierNum, mergesoldier);

                    // 새로생긴 용병에 현재 slot정보를 넣어준다.
                    SoldierStat stat = mergesoldier.GetComponent<SoldierStat>();
                    stat.mySlot = soldierStat.mySlot;

                    // 3. 해당 용병은 내 래벨의 +1을 해준다.
                    SoldierStat mergeSoldierStat = mergesoldier.GetComponent<SoldierStat>();
                    mergeSoldierStat.level = soldierStat.level + 1;

                    // 레벨업에 따른 추가 스탯
                    if(mergeSoldierStat.level > 1)
                    {
                        mergeSoldierStat.attackSpeed -= ((mergeSoldierStat.level-1) * 0.1f);
                    }


                    // 4. 현재 오브젝트를 지운다.
                    Destroy(this.gameObject);

                }

            }
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == this.gameObject.tag)
        {
            SoldierStat otherStat = collision.GetComponent<SoldierStat>();

            if (otherStat.level == this.soldierStat.level)
            {
                // 같은 용병이고, 레벨이 같으면 합성이 가능하다.
                soldierStat.isMerge = true;

                // 합성이 가능하다면 drag중인 오브젝트이다. drag중인 오브젝트를 삭제
                if (otherStat.canMerge ==true)
                {
                    // merge진행
                    // 1. other을 삭제한다.(드래그중인 오브젝트 삭제) + slot 추가(빈 슬롯이기 때문)
                    GameManager.GetInstance().slotList.Add(otherStat.mySlot);
                    Destroy(collision.gameObject);

                    // 2. 내 위치에서 다른 용병을 생성한다.(랜덤)
                    int soldierNum = Random.Range(0, GameManager.GetInstance().soliderPrefabList.Count); // 랜덤 선택
                    
                    // 랜덤용병을 현재 용병의 slot에 생성, list에 넣어준다.
                    GameObject mergesoldier = Instantiate(GameManager.GetInstance().soliderPrefabList[soldierNum], soldierStat.mySlot.transform);
                    GameManager.GetInstance().InputSoldierList(soldierNum, mergesoldier);

                    // 새로생긴 용병에 현재 slot정보를 넣어준다.
                    SoldierStat stat = mergesoldier.GetComponent<SoldierStat>();
                    stat.mySlot = soldierStat.mySlot;

                    // 3. 해당 용병은 내 래벨의 +1을 해준다.
                    SoldierStat mergeSoldierStat = mergesoldier.GetComponent<SoldierStat>();
                    mergeSoldierStat.level = soldierStat.level + 1;


                    // 4. 현재 오브젝트를 지운다.
                    Destroy(this.gameObject);

                }
                
            }
        }
    }
    */
    private void OnTriggerExit2D(Collider2D collision)
    {
        soldierStat.isMerge = false;
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
            // 스킬 쿨타임이 되면 스킬을 사용한다.
            curSkillTime = 0;
            state = SoldierState.Skill;
        }
    }


    private void UseSkill()
    {
       // Debug.Log("스킬을 사용합니다.");
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

           // Debug.Log(target.name + "을 공격합니다.");
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
        // 몬스터의 hp 정보를 받아와서 가장 높은 hp를 타겟으로한다.
        // 비교할 hp 값과, 타겟으로 해야되는 i의 값을 저장한후
        // hp의 값으로 비교를하고, 최종적으로 i가 되는 몬스터를 target으로 해준다.

        // 몬스터 리스트가 0 이라면 idle이고,
        // else라면 attack으로

        //int higestI;

        //for(int i = GameManager.instance.usingMonsterList.Count -1; i>=0; i--)
        //{
        //    MonsterStat monStat = GameManager.instance.usingMonsterList[i].GetComponent<MonsterStat>();
        //    if (monStat.curHp)
        //}
    }

}
