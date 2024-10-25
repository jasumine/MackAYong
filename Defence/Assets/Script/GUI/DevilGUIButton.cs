using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DevilGUIButton : MonoBehaviour
{
    private int goldCount;
    private int perCount;

    public List<int> bossDrawCost;
    public List<TextMeshProUGUI> bossCostText;

    public List<int> AbilityCost;
    public List<TextMeshProUGUI> AbilityCostText;
    public List<int> DrawPercent;
    public List<TextMeshProUGUI> DrawPercentText;


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

        DrawPercent.Add(60);
        DrawPercent.Add(20);
        DrawPercent.Add(5);
        DrawPercent.Add(1);
    }


    public void BossFirstDraw()
    {
        // 소지금이 비용보다 많거나 같다면 소환 가능.
        if (GameManager.GetInstance().devilCoin >= bossDrawCost[0])
        {
            GameManager.GetInstance().devilCoin -= bossDrawCost[0];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            GameManager.GetInstance().bossCount[0]++;
            GameManager.GetInstance().bossCountText[0].text = GameManager.GetInstance().bossCount[0].ToString();
            Debug.Log("일반 몬스터를 소환했습니다. 일반 몬스터 수 : " + GameManager.GetInstance().bossCount[0]);
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

            if (0 <= bossNum && bossNum < DrawPercent[0])
            {
                GameManager.GetInstance().bossCount[1]++;
                GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossCount[1].ToString();
                Debug.Log("희귀 몬스터를 소환했습니다. 희귀 몬스터 수 : " + GameManager.GetInstance().bossCount[1]);
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

            if (0 <= bossNum && bossNum < DrawPercent[1])
            {
                GameManager.GetInstance().bossCount[2]++;
                GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossCount[2].ToString();
                Debug.Log("영웅 몬스터를 소환했습니다. 영웅 몬스터 수 : " + GameManager.GetInstance().bossCount[2]);
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

            if (0 <= bossNum && bossNum < DrawPercent[2])
            {
                GameManager.GetInstance().bossCount[3]++;
                GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossCount[3].ToString();
                Debug.Log("전설 몬스터를 소환했습니다. 전설 몬스터 수 : " + GameManager.GetInstance().bossCount[3]);
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

            if (0 <= bossNum && bossNum < DrawPercent[3])
            {
                GameManager.GetInstance().bossCount[4]++;
                GameManager.GetInstance().bossCountText[4].text = GameManager.GetInstance().bossCount[4].ToString();
                Debug.Log("신화 몬스터를 소환했습니다. 신화 몬스터 수 : " + GameManager.GetInstance().bossCount[4]);
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

            // 몬스터의 기본 능력을 증가 시켜준다.
            for(int i = 0; i < GameManager.GetInstance().monsterPrefabs.Count; i++)
            {
                // 몬스터 마다 기본 maxHp가 다르기 때문에 각각 가져와서 증가 시킨다.
                MonsterStat mStat = GameManager.GetInstance().monsterPrefabs[i].GetComponent<MonsterStat>();

                float value = mStat.maxHp * 0.1f; // 10%
                mStat.maxHp += value;
            }


            // 현재 소환된 몬스터의 능력을 올려준다.
            for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
            {
                MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

                float value = mStat.maxHp * 0.1f; // 10%
                mStat.curHp += value;
                // 기본타입이 아닌 경우 이미 위에서 증가 시켰기 때문에 구분을 해준다.
                if (mStat.monsterType == MonsterType.basic)
                {
                    mStat.maxHp += value;
                }
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

            // 몬스터의 기본 능력을 증가 시켜준다.
            for (int i = 0; i < GameManager.GetInstance().monsterPrefabs.Count; i++)
            {
                // 몬스터 마다 기본 maxHp가 다르기 때문에 각각 가져와서 증가 시킨다.
                MonsterStat mStat = GameManager.GetInstance().monsterPrefabs[i].GetComponent<MonsterStat>();

                float value = mStat.speed * 0.01f; // 1%
                mStat.speed += value;
            }



            // 현재 소환된 몬스터의 능력을 올려준다.
            for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
            {
                MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

                float value = mStat.speed * 0.01f; // 1%
                // 기본타입이 아닌 경우 이미 위에서 증가 시켰기 때문에 구분을 해준다.
                if (mStat.monsterType==MonsterType.basic)
                {
                    mStat.speed += value;
                }
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

            // 몬스터의 기본 능력을 증가 시켜준다.
            for (int i = 0; i < GameManager.GetInstance().monsterPrefabs.Count; i++)
            {
                // 몬스터 마다 기본 maxHp가 다르기 때문에 각각 가져와서 증가 시킨다.
                MonsterStat mStat = GameManager.GetInstance().monsterPrefabs[i].GetComponent<MonsterStat>();

                float value = mStat.attackSpeed * 0.01f; // 1%
                mStat.attackSpeed += value;
            }



            // 현재 소환된 몬스터의 능력을 올려준다.
            for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
            {
                MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

                float value = mStat.speed * 0.01f; // 1%
                // 기본타입이 아닌 경우 이미 위에서 증가 시켰기 때문에 구분을 해준다.
                if (mStat.monsterType == MonsterType.basic)
                {
                    mStat.attackSpeed += value;
                }
            }
            Debug.Log("공격속도를 증가합니다.");
        }
    }

    public void IncreaseGold()
    {
        if (GameManager.GetInstance().devilCoin >= AbilityCost[3]&& goldCount <3)
        {
            goldCount++;
            // 재화에서 비용만큼 감소하고 text 업데이트
            GameManager.GetInstance().devilCoin -= AbilityCost[3];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            // 비용을 증가시켜준다. 텍스트도 업데이트.
            AbilityCost[3] += 100;
            AbilityCostText[3].text = AbilityCost[3].ToString();

            GameManager.GetInstance().monsterCoin++;

            Debug.Log("재화 획득량을 증가합니다.");
        }
    }

    public void IncreasePercent()
    {
        if (GameManager.GetInstance().devilCoin >= AbilityCost[4] && perCount <3)
        {
            perCount++;
            // 재화에서 비용만큼 감소하고 text 업데이트
            GameManager.GetInstance().devilCoin -= AbilityCost[4];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            // 비용을 증가시켜준다. 텍스트도 업데이트.
            AbilityCost[4] += 100;
            AbilityCostText[4].text = AbilityCost[4].ToString();

            
            for (int i = 0; i < DrawPercent.Count; i++)
            {
                DrawPercent[i] += 1;
                DrawPercentText[i].text = DrawPercent[i].ToString() + "%";
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
