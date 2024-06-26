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
        // ���� ���� �� ���� �ð�
        if(isFadeAway == false)
        {
            coolTime += Time.deltaTime;
        }

        if (isFadeAway == false && coolTime > coolTimeMax)
        {
            bossObject.SetActive(false);
            creatTime = 0;
            isFadeAway = true;
            Debug.Log("Ư�� ���Ͱ� �ð��� ������ ���� ������ϴ�.");
        }

        // ���Ͱ� ����� �� ��Ÿ��
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
        Debug.Log("Ư�� ���͸� ��ȯ �߽��ϴ�.");

        bossObject.SetActive(true);
        bossObject.transform.position = startPoint.position;


        coolTime = 0;
        isFadeAway = false;
    }


    private void OnGUI()
    {
        if (GUI.Button(new Rect(500, 10, 100, 100), "Ư�� ����"))
        {
            if (isSpecialCoolDown == true)
            {
                SpecialBossDraw();
            }
        }
    }


}


