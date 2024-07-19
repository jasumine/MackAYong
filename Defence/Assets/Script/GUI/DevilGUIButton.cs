using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilGUIButton : MonoBehaviour
{
    public List<GameObject> bossMonsterPrefab;

    public int bossOneCount;
    public int bossTwoCount;
    public int bossThreeCount;
    public int bossFourCount;
    public int bossFiveCount;

    // ==============보스 뽑기================

    public void BossFirstDraw()
    {
        bossOneCount++;
        Debug.Log("일반 몬스터를 소환했습니다. 일반 몬스터 수 : " + bossOneCount);
    }

    public void BossSecondDraw()
    {
        int bossNum = Random.Range(0, 100);

        if (0 <= bossNum && bossNum < 60)
        {
            bossTwoCount++;
            Debug.Log("희귀 몬스터를 소환했습니다. 희귀 몬스터 수 : " + bossTwoCount);
        }
        else
        {
            Debug.Log("희귀 몬스터 뽑기에 실패했습니다.");
        }
    }

    public void BossThirdDraw()
    {
        int bossNum = Random.Range(0, 100);

        if (0 <= bossNum && bossNum < 20)
        {
            bossThreeCount++;
            Debug.Log("영웅 몬스터를 소환했습니다. 영웅 몬스터 수 : " + bossThreeCount);
        }
        else
        {
            Debug.Log("영웅 몬스터 뽑기에 실패했습니다.");
        }
    }

    public void BossForthDraw()
    {
        int bossNum = Random.Range(0, 100);

        if (0 <= bossNum && bossNum < 5)
        {
            bossFourCount++;
            Debug.Log("전설 몬스터를 소환했습니다. 전설 몬스터 수 : " + bossFourCount);
        }
        else
        {
            Debug.Log("전설 몬스터 뽑기에 실패했습니다.");
        }
    }

    public void BossFifthDraw()
    {
        int bossNum = Random.Range(0, 100);

        if (0 <= bossNum && bossNum < 1)
        {
            bossFiveCount++;
            Debug.Log("신화 몬스터를 소환했습니다. 신화 몬스터 수 : " + bossFiveCount);
        }
        else
        {
            Debug.Log("신화 몬스터 뽑기에 실패했습니다.");
        }
    }


    //================능력치 업그레이드===============

    public void IncreaseHp()
    {
        for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
        {
            MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

            mStat.maxHp++;
        }
        Debug.Log("hp를 증가합니다.");
    }


    public void IncreaseSpeed()
    {
        for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
        {
            MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

            mStat.speed++;
        }
        Debug.Log("속도를 증가합니다.");
    }


    public void IncreaseAttackSpeed()
    {
        for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
        {
            MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

            mStat.attackSpeed++;
        }
        Debug.Log("공격속도를 증가합니다.");
    }

    public void IncreaseGold()
    {
        for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
        {
            MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

            mStat.speed++;
        }
        Debug.Log("재화 획득량을 증가합니다.");
    }

    public void IncreasePercent()
    {
        for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
        {
            MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

            mStat.speed++;
        }
        Debug.Log("뽑기 획득률을 증가합니다.");
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
