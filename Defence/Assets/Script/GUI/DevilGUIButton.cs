using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilGUIButton : MonoBehaviour
{
    // ==============���� �̱�================

    public void BossFirstDraw()
    {
        GameManager.GetInstance().bossOneCount++;
        Debug.Log("�Ϲ� ���͸� ��ȯ�߽��ϴ�. �Ϲ� ���� �� : " + GameManager.GetInstance().bossOneCount);
    }

    public void BossSecondDraw()
    {
        int bossNum = Random.Range(0, 100);

        if (0 <= bossNum && bossNum < 60)
        {
            GameManager.GetInstance().bossTwoCount++;
            Debug.Log("��� ���͸� ��ȯ�߽��ϴ�. ��� ���� �� : " + GameManager.GetInstance().bossTwoCount);
        }
        else
        {
            Debug.Log("��� ���� �̱⿡ �����߽��ϴ�.");
        }
    }

    public void BossThirdDraw()
    {
        int bossNum = Random.Range(0, 100);

        if (0 <= bossNum && bossNum < 20)
        {
            GameManager.GetInstance().bossThreeCount++;
            Debug.Log("���� ���͸� ��ȯ�߽��ϴ�. ���� ���� �� : " + GameManager.GetInstance().bossThreeCount);
        }
        else
        {
            Debug.Log("���� ���� �̱⿡ �����߽��ϴ�.");
        }
    }

    public void BossForthDraw()
    {
        int bossNum = Random.Range(0, 100);

        if (0 <= bossNum && bossNum < 5)
        {
            GameManager.GetInstance().bossFourCount++;
            Debug.Log("���� ���͸� ��ȯ�߽��ϴ�. ���� ���� �� : " + GameManager.GetInstance().bossFourCount);
        }
        else
        {
            Debug.Log("���� ���� �̱⿡ �����߽��ϴ�.");
        }
    }

    public void BossFifthDraw()
    {
        int bossNum = Random.Range(0, 100);

        if (0 <= bossNum && bossNum < 1)
        {
            GameManager.GetInstance().bossFiveCount++;
            Debug.Log("��ȭ ���͸� ��ȯ�߽��ϴ�. ��ȭ ���� �� : " + GameManager.GetInstance().bossFiveCount);
        }
        else
        {
            Debug.Log("��ȭ ���� �̱⿡ �����߽��ϴ�.");
        }
    }


    //================�ɷ�ġ ���׷��̵�===============

    public void IncreaseHp()
    {
        for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
        {
            MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

            mStat.maxHp++;
        }
        Debug.Log("hp�� �����մϴ�.");
    }


    public void IncreaseSpeed()
    {
        for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
        {
            MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

            mStat.speed++;
        }
        Debug.Log("�ӵ��� �����մϴ�.");
    }


    public void IncreaseAttackSpeed()
    {
        for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
        {
            MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

            mStat.attackSpeed++;
        }
        Debug.Log("���ݼӵ��� �����մϴ�.");
    }

    public void IncreaseGold()
    {
        for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
        {
            MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

            mStat.speed++;
        }
        Debug.Log("��ȭ ȹ�淮�� �����մϴ�.");
    }

    public void IncreasePercent()
    {
        for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
        {
            MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

            mStat.speed++;
        }
        Debug.Log("�̱� ȹ����� �����մϴ�.");
    }

    // ================Set Active==================

    public GameObject drawPannelObject;
    public GameObject abilityPannelObject;

    public void DrawPanelActiveTrue()
    {
        drawPannelObject.SetActive(true);
    }

    public void DrawPanelActiveFalse()
    {
        drawPannelObject.SetActive(false);
    }

    public void AbilityPanelActiveTrue()
    {
        abilityPannelObject.SetActive(true);
    }

    public void AbilityPanelActiveFalse()
    {
        abilityPannelObject.SetActive(false);
    }
}
