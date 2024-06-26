using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMonster : MonoBehaviour
{
    MonsterStat mStat;

    public GameObject bossObject;
    public Transform startPoint;

    public float coolTime;
    public float coolTimeMax;
    public float creatTime;
    public float creatTimeMax;

    public bool isSpecialCoolDown;
    public bool isFadeAway;





  

    void Start()
    {
        mStat = GetComponent<MonsterStat>();
        isSpecialCoolDown = true;
        isFadeAway  = true;
    }

    void Update()
    {
        // 몬스터 생성 후 생존 시간
        if(isFadeAway == false)
        {
            coolTime += Time.deltaTime;
        }

        if (isFadeAway == false && coolTime > coolTimeMax)
        {
            bossObject.SetActive(false);
            creatTime = 0;
            isFadeAway = true;
            Debug.Log("특별 몬스터가 시간이 지남에 따라 사라집니다.");
        }

        // 몬스터가 사라진 후 쿨타임
        if(isFadeAway == true)
        {
            creatTime += Time.deltaTime;
        }

        if(isFadeAway == true && creatTime > creatTimeMax)
        {
            isSpecialCoolDown=true;
        }
    }


private void SpecialBossDraw()
    {
        isSpecialCoolDown = false;
        Debug.Log("특별 몬스터를 소환 했습니다.");

        bossObject.SetActive(true);
        bossObject.transform.position = startPoint.position;


        coolTime = 0;
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


