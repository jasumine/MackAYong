using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpecialMonster : MonoBehaviour
{
    public GameObject bossObject;

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
        // ���� ���� �� ���� �ð�
        if(isFadeAway == false)
        {
            coolTime -= Time.deltaTime;
        }

        if (isFadeAway == false && coolTime < 0 )
        {
            bossObject.SetActive(false);
            creatTime = creatTimeMax;
            isFadeAway = true;
            Debug.Log("Ư�� ���Ͱ� �ð��� ������ ���� ������ϴ�.");
        }

        // ���Ͱ� ����� �� ��Ÿ��
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
            Debug.Log("Ư�� ���͸� ��ȯ �߽��ϴ�.");

            bossObject.SetActive(true);
            GameManager.instance.monsterList.Add(bossObject);

            Monster monsterScript = bossObject.GetComponent<Monster>();
            MonsterStat monsterStat = bossObject.GetComponent<MonsterStat>();
            monsterStat.curHp = monsterStat.maxHp;
            bossObject.transform.position = monsterScript.wayPoints[0].position;
            monsterScript.targetPoint = monsterScript.wayPoints[1];
            monsterScript.monsterState = MonsterState.move;

            coolTime = coolTimeMax;
            isFadeAway = false;
        }
    }


}

