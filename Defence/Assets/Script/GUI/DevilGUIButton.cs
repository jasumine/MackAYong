using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DevilGUIButton : MonoBehaviour
{
    public List<int> bossDrawCost;
    public List<TextMeshProUGUI> bossCostText;

    public List<int> AbilityCost;
    public List<TextMeshProUGUI> AbilityCostText;



    // ==============보스 뽑기================

    private void Start()
    {
        for(int i = 0; i<6;i++)
        {
            // 보스 뽑기 비용
            // 단계마다 20씩 차이 나게 설정
            int cost = 100;
            cost += i * 20;
            bossDrawCost.Add(cost);
            // 해당 가격을 text로 표시한다.
            bossCostText[i].text = bossDrawCost[i].ToString();
        }

        for(int i = 0; i<5;i++)
        {
            // 능력치 강화 비용
            int cost = 100;
            AbilityCost.Add(cost); // 능력 비용은 100으로 설정
            AbilityCostText[i].text = AbilityCost[i].ToString();
        }
    }


    public void BossFirstDraw()
    {
        // 소지금이 비용보다 많거나 같다면 소환 가능.
        if (GameManager.GetInstance().devilCoin >= bossDrawCost[0])
        {
            GameManager.GetInstance().devilCoin -= bossDrawCost[0];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            GameManager.GetInstance().bossOneCount++;
            GameManager.GetInstance().bossCountText[0].text = GameManager.GetInstance().bossOneCount.ToString();
            Debug.Log("일반 몬스터를 소환했습니다. 일반 몬스터 수 : " + GameManager.GetInstance().bossOneCount);
        }
    }

    public void BossSecondDraw()
    {
        // 소지금이 비용보다 많거나 같다면 소환 가능.
        if (GameManager.GetInstance().devilCoin >= bossDrawCost[1])
        {
            GameManager.GetInstance().devilCoin -= bossDrawCost[1];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            int bossNum = Random.Range(0, 100);

            if (0 <= bossNum && bossNum < 60)
            {
                GameManager.GetInstance().bossTwoCount++;
                GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossTwoCount.ToString();
                Debug.Log("희귀 몬스터를 소환했습니다. 희귀 몬스터 수 : " + GameManager.GetInstance().bossTwoCount);
            }
            else
            {
                Debug.Log("희귀 몬스터 뽑기에 실패했습니다.");
            }
        }
    }

    public void BossThirdDraw()
    {
        // 소지금이 비용보다 많거나 같다면 소환 가능.
        if (GameManager.GetInstance().devilCoin >= bossDrawCost[2])
        {
            GameManager.GetInstance().devilCoin -= bossDrawCost[2];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            int bossNum = Random.Range(0, 100);

            if (0 <= bossNum && bossNum < 20)
            {
                GameManager.GetInstance().bossThreeCount++;
                GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossThreeCount.ToString();
                Debug.Log("영웅 몬스터를 소환했습니다. 영웅 몬스터 수 : " + GameManager.GetInstance().bossThreeCount);
            }
            else
            {
                Debug.Log("영웅 몬스터 뽑기에 실패했습니다.");
            }
        }
    }

    public void BossForthDraw()
    {
        // 소지금이 비용보다 많거나 같다면 소환 가능.
        if (GameManager.GetInstance().devilCoin >= bossDrawCost[3])
        {
            GameManager.GetInstance().devilCoin -= bossDrawCost[3];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            int bossNum = Random.Range(0, 100);

            if (0 <= bossNum && bossNum < 5)
            {
                GameManager.GetInstance().bossFourCount++;
                GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossFourCount.ToString();
                Debug.Log("전설 몬스터를 소환했습니다. 전설 몬스터 수 : " + GameManager.GetInstance().bossFourCount);
            }
            else
            {
                Debug.Log("전설 몬스터 뽑기에 실패했습니다.");
            }
        }

    }

    public void BossFifthDraw()
    {
        // 소지금이 비용보다 많거나 같다면 소환 가능.
        if (GameManager.GetInstance().devilCoin >= bossDrawCost[4])
        {
            GameManager.GetInstance().devilCoin -= bossDrawCost[4];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            int bossNum = Random.Range(0, 100);

            if (0 <= bossNum && bossNum < 1)
            {
                GameManager.GetInstance().bossFiveCount++;
                GameManager.GetInstance().bossCountText[4].text = GameManager.GetInstance().bossFiveCount.ToString();
                Debug.Log("신화 몬스터를 소환했습니다. 신화 몬스터 수 : " + GameManager.GetInstance().bossFiveCount);
            }
            else
            {
                Debug.Log("신화 몬스터 뽑기에 실패했습니다.");
            }
        }
    }


    //================능력치 업그레이드===============

    public void IncreaseHp()
    {
        if (GameManager.GetInstance().devilCoin >= AbilityCost[0])
        {
            // 재화에서 비용만큼 감소하고 text 업데이트
            GameManager.GetInstance().devilCoin -= AbilityCost[0];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            // 비용을 증가시켜준다. 텍스트도 업데이트.
            AbilityCost[0] += 10;
            AbilityCostText[0].text = AbilityCost[0].ToString();

            for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
            {
                MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

                mStat.maxHp++;
            }
            Debug.Log("hp를 증가합니다.");
        }

    }


    public void IncreaseSpeed()
    {
        if (GameManager.GetInstance().devilCoin >= AbilityCost[1])
        {
            // 재화에서 비용만큼 감소하고 text 업데이트
            GameManager.GetInstance().devilCoin -= AbilityCost[1];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            // 비용을 증가시켜준다. 텍스트도 업데이트.
            AbilityCost[1] += 10;
            AbilityCostText[1].text = AbilityCost[1].ToString();

            for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
            {
                MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

                mStat.speed++;
            }
            Debug.Log("속도를 증가합니다.");
        }
    }


    public void IncreaseAttackSpeed()
    {
        if (GameManager.GetInstance().devilCoin >= AbilityCost[2])
        {
            // 재화에서 비용만큼 감소하고 text 업데이트
            GameManager.GetInstance().devilCoin -= AbilityCost[2];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            // 비용을 증가시켜준다. 텍스트도 업데이트.
            AbilityCost[2] += 10;
            AbilityCostText[2].text = AbilityCost[2].ToString();

            for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
            {
                MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

                mStat.attackSpeed++;
            }
            Debug.Log("공격속도를 증가합니다.");
        }
    }

    public void IncreaseGold()
    {
        if (GameManager.GetInstance().devilCoin >= AbilityCost[3])
        {
            // 재화에서 비용만큼 감소하고 text 업데이트
            GameManager.GetInstance().devilCoin -= AbilityCost[3];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            // 비용을 증가시켜준다. 텍스트도 업데이트.
            AbilityCost[3] += 10;
            AbilityCostText[3].text = AbilityCost[3].ToString();

            for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
            {
                MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

                mStat.speed++;
            }
            Debug.Log("재화 획득량을 증가합니다.");
        }
    }

    public void IncreasePercent()
    {
        if (GameManager.GetInstance().devilCoin >= AbilityCost[4])
        {
            // 재화에서 비용만큼 감소하고 text 업데이트
            GameManager.GetInstance().devilCoin -= AbilityCost[4];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            // 비용을 증가시켜준다. 텍스트도 업데이트.
            AbilityCost[4] += 10;
            AbilityCostText[4].text = AbilityCost[4].ToString();

            for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
            {
                MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

                mStat.speed++;
            }
            Debug.Log("뽑기 획득률을 증가합니다.");
        }
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
