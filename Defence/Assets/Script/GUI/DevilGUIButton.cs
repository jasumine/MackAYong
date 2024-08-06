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



    // ==============���� �̱�================

    private void Start()
    {
        for(int i = 0; i<6;i++)
        {
            // ���� �̱� ���
            // �ܰ踶�� 20�� ���� ���� ����
            int cost = 100;
            cost += i * 20;
            bossDrawCost.Add(cost);
            // �ش� ������ text�� ǥ���Ѵ�.
            bossCostText[i].text = bossDrawCost[i].ToString();
        }

        for(int i = 0; i<5;i++)
        {
            // �ɷ�ġ ��ȭ ���
            int cost = 100;
            AbilityCost.Add(cost); // �ɷ� ����� 100���� ����
            AbilityCostText[i].text = AbilityCost[i].ToString();
        }
    }


    public void BossFirstDraw()
    {
        // �������� ��뺸�� ���ų� ���ٸ� ��ȯ ����.
        if (GameManager.GetInstance().devilCoin >= bossDrawCost[0])
        {
            GameManager.GetInstance().devilCoin -= bossDrawCost[0];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            GameManager.GetInstance().bossOneCount++;
            GameManager.GetInstance().bossCountText[0].text = GameManager.GetInstance().bossOneCount.ToString();
            Debug.Log("�Ϲ� ���͸� ��ȯ�߽��ϴ�. �Ϲ� ���� �� : " + GameManager.GetInstance().bossOneCount);
        }
    }

    public void BossSecondDraw()
    {
        // �������� ��뺸�� ���ų� ���ٸ� ��ȯ ����.
        if (GameManager.GetInstance().devilCoin >= bossDrawCost[1])
        {
            GameManager.GetInstance().devilCoin -= bossDrawCost[1];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            int bossNum = Random.Range(0, 100);

            if (0 <= bossNum && bossNum < 60)
            {
                GameManager.GetInstance().bossTwoCount++;
                GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossTwoCount.ToString();
                Debug.Log("��� ���͸� ��ȯ�߽��ϴ�. ��� ���� �� : " + GameManager.GetInstance().bossTwoCount);
            }
            else
            {
                Debug.Log("��� ���� �̱⿡ �����߽��ϴ�.");
            }
        }
    }

    public void BossThirdDraw()
    {
        // �������� ��뺸�� ���ų� ���ٸ� ��ȯ ����.
        if (GameManager.GetInstance().devilCoin >= bossDrawCost[2])
        {
            GameManager.GetInstance().devilCoin -= bossDrawCost[2];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            int bossNum = Random.Range(0, 100);

            if (0 <= bossNum && bossNum < 20)
            {
                GameManager.GetInstance().bossThreeCount++;
                GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossThreeCount.ToString();
                Debug.Log("���� ���͸� ��ȯ�߽��ϴ�. ���� ���� �� : " + GameManager.GetInstance().bossThreeCount);
            }
            else
            {
                Debug.Log("���� ���� �̱⿡ �����߽��ϴ�.");
            }
        }
    }

    public void BossForthDraw()
    {
        // �������� ��뺸�� ���ų� ���ٸ� ��ȯ ����.
        if (GameManager.GetInstance().devilCoin >= bossDrawCost[3])
        {
            GameManager.GetInstance().devilCoin -= bossDrawCost[3];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            int bossNum = Random.Range(0, 100);

            if (0 <= bossNum && bossNum < 5)
            {
                GameManager.GetInstance().bossFourCount++;
                GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossFourCount.ToString();
                Debug.Log("���� ���͸� ��ȯ�߽��ϴ�. ���� ���� �� : " + GameManager.GetInstance().bossFourCount);
            }
            else
            {
                Debug.Log("���� ���� �̱⿡ �����߽��ϴ�.");
            }
        }

    }

    public void BossFifthDraw()
    {
        // �������� ��뺸�� ���ų� ���ٸ� ��ȯ ����.
        if (GameManager.GetInstance().devilCoin >= bossDrawCost[4])
        {
            GameManager.GetInstance().devilCoin -= bossDrawCost[4];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            int bossNum = Random.Range(0, 100);

            if (0 <= bossNum && bossNum < 1)
            {
                GameManager.GetInstance().bossFiveCount++;
                GameManager.GetInstance().bossCountText[4].text = GameManager.GetInstance().bossFiveCount.ToString();
                Debug.Log("��ȭ ���͸� ��ȯ�߽��ϴ�. ��ȭ ���� �� : " + GameManager.GetInstance().bossFiveCount);
            }
            else
            {
                Debug.Log("��ȭ ���� �̱⿡ �����߽��ϴ�.");
            }
        }
    }


    //================�ɷ�ġ ���׷��̵�===============

    public void IncreaseHp()
    {
        if (GameManager.GetInstance().devilCoin >= AbilityCost[0])
        {
            // ��ȭ���� ��븸ŭ �����ϰ� text ������Ʈ
            GameManager.GetInstance().devilCoin -= AbilityCost[0];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            // ����� ���������ش�. �ؽ�Ʈ�� ������Ʈ.
            AbilityCost[0] += 10;
            AbilityCostText[0].text = AbilityCost[0].ToString();

            for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
            {
                MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

                mStat.maxHp++;
            }
            Debug.Log("hp�� �����մϴ�.");
        }

    }


    public void IncreaseSpeed()
    {
        if (GameManager.GetInstance().devilCoin >= AbilityCost[1])
        {
            // ��ȭ���� ��븸ŭ �����ϰ� text ������Ʈ
            GameManager.GetInstance().devilCoin -= AbilityCost[1];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            // ����� ���������ش�. �ؽ�Ʈ�� ������Ʈ.
            AbilityCost[1] += 10;
            AbilityCostText[1].text = AbilityCost[1].ToString();

            for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
            {
                MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

                mStat.speed++;
            }
            Debug.Log("�ӵ��� �����մϴ�.");
        }
    }


    public void IncreaseAttackSpeed()
    {
        if (GameManager.GetInstance().devilCoin >= AbilityCost[2])
        {
            // ��ȭ���� ��븸ŭ �����ϰ� text ������Ʈ
            GameManager.GetInstance().devilCoin -= AbilityCost[2];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            // ����� ���������ش�. �ؽ�Ʈ�� ������Ʈ.
            AbilityCost[2] += 10;
            AbilityCostText[2].text = AbilityCost[2].ToString();

            for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
            {
                MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

                mStat.attackSpeed++;
            }
            Debug.Log("���ݼӵ��� �����մϴ�.");
        }
    }

    public void IncreaseGold()
    {
        if (GameManager.GetInstance().devilCoin >= AbilityCost[3])
        {
            // ��ȭ���� ��븸ŭ �����ϰ� text ������Ʈ
            GameManager.GetInstance().devilCoin -= AbilityCost[3];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            // ����� ���������ش�. �ؽ�Ʈ�� ������Ʈ.
            AbilityCost[3] += 10;
            AbilityCostText[3].text = AbilityCost[3].ToString();

            for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
            {
                MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

                mStat.speed++;
            }
            Debug.Log("��ȭ ȹ�淮�� �����մϴ�.");
        }
    }

    public void IncreasePercent()
    {
        if (GameManager.GetInstance().devilCoin >= AbilityCost[4])
        {
            // ��ȭ���� ��븸ŭ �����ϰ� text ������Ʈ
            GameManager.GetInstance().devilCoin -= AbilityCost[4];
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

            // ����� ���������ش�. �ؽ�Ʈ�� ������Ʈ.
            AbilityCost[4] += 10;
            AbilityCostText[4].text = AbilityCost[4].ToString();

            for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
            {
                MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

                mStat.speed++;
            }
            Debug.Log("�̱� ȹ����� �����մϴ�.");
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
