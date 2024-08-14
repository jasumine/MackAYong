using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpecialMonster : MonoBehaviour
{
    public GameObject summonBotton;

    public float coolTime;
    public float coolTimeMax;
    public float creatTime;
    public float creatTimeMax;

    public bool isSpecialCoolDown;
    public bool isFadeAway;


    void Start()
    {
        isSpecialCoolDown = true;
        isFadeAway  = true;
    }

    void Update()
    {
        // 몬스터 생성 후 생존 시간
        if(isFadeAway == false)
        {
            coolTime -= Time.deltaTime;
        }

        if (isFadeAway == false && coolTime < 0 )
        {
            GameManager.GetInstance().monsterPrefabs[6].SetActive(false);
            creatTime = creatTimeMax;
            isFadeAway = true;
            Debug.Log("특별 몬스터가 시간이 지남에 따라 사라집니다.");
        }

        // 몬스터가 사라진 후 쿨타임
        if(isFadeAway == true)
        {
            creatTime -= Time.deltaTime;
        }

        if(isFadeAway == true && creatTime <0 )
        {
            isSpecialCoolDown=true;
            summonBotton.SetActive(true);
        }
    }


public void SpecialBossDraw()
    {
        if (isSpecialCoolDown == true)
        {

            isSpecialCoolDown = false;
            summonBotton.SetActive(false);
            Debug.Log("특별 몬스터를 소환 했습니다.");

            GameManager.GetInstance().monsterPrefabs[6].SetActive(true);
            GameManager.instance.monsterList.Add(GameManager.GetInstance().monsterPrefabs[6]);

            Monster monsterScript = GameManager.GetInstance().monsterPrefabs[6].GetComponent<Monster>();
            MonsterStat monsterStat = GameManager.GetInstance().monsterPrefabs[6].GetComponent<MonsterStat>();
            monsterStat.curHp = monsterStat.maxHp;
            GameManager.GetInstance().monsterPrefabs[6].transform.position = monsterScript.wayPoints[0].position;
            monsterScript.targetPoint = monsterScript.wayPoints[1];
            monsterScript.monsterState = MonsterState.move;

            coolTime = coolTimeMax;
            isFadeAway = false;
        }
    }


}


