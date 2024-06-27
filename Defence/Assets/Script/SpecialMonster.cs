using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMonster : MonoBehaviour
{
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
        }
    }


private void SpecialBossDraw()
    {
        isSpecialCoolDown = false;
        Debug.Log("Ư�� ���͸� ��ȯ �߽��ϴ�.");

        bossObject.SetActive(true);
        bossObject.transform.position = startPoint.position;


        coolTime = coolTimeMax;
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


