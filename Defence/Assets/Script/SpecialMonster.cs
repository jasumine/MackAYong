using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpecialMonster : MonoBehaviour
{
    public GameObject bossObject;
 
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
            bossObject.SetActive(false);
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
        }
    }


private void SpecialBossDraw()
    {
        isSpecialCoolDown = false;
        Debug.Log("특별 몬스터를 소환 했습니다.");

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


    private void OnGUI()
    {
        if (GUI.Button(new Rect(500, 10, 100, 100), "특별 몬스터"))
        {
            if (isSpecialCoolDown == true)
            {
                SpecialBossDraw();
            }
        }
    }


}


