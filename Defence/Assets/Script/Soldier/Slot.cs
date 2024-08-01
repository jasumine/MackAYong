using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int drawCost = 20;
    public TextMeshProUGUI drawCostText;

    public int firstStatCost = 100;
    public TextMeshProUGUI firstStatCostText;
    public int secondStatCost = 100;
    public TextMeshProUGUI secondStatCostText;
    public int thirdStatCost = 100;
    public TextMeshProUGUI thirdStatCostText;
    public int fourthStatCost = 100;
    public TextMeshProUGUI fourthStatCostText;
    public int fifthStatCost = 100;
    public TextMeshProUGUI fifthStatCostText;

    public void Summon()
    {
        if(GameManager.GetInstance().heroCoin>= drawCost)
        {
            if (GameManager.GetInstance().slotList.Count == 0)
            {
                Debug.Log("��ȯ �� ������ �����ϴ�.");
            }
            else
            {
                // ������ ��ȭ�� �����ϰ�, ����� ������Ų��.
                GameManager.GetInstance().heroCoin -= drawCost;
                GameManager.GetInstance().heroCoinText.text = GameManager.GetInstance().heroCoin.ToString();
                drawCost += 2;
                drawCostText.text = drawCost.ToString();


                // slot�� ��ġ�� �������� ����
                int slotNum = Random.Range(0, GameManager.GetInstance().slotList.Count);

                // �뺴�� �������� �� ��
                int soldierNum = Random.Range(0, GameManager.GetInstance().soliderPrefabList.Count);

                // �뺴 object�� slotList�� ��ġ�� �������ش�.
                // �뺴 object�� ���߾ �ش� �뺴���� ��Ƶ� list�� �־��ش�.
                GameObject soldier = Instantiate(GameManager.GetInstance().soliderPrefabList[soldierNum], GameManager.GetInstance().slotList[slotNum].gameObject.transform);
                GameManager.GetInstance().InputSoldierList(soldierNum, soldier);

                SoldierStat stat = soldier.GetComponent<SoldierStat>();
                stat.mySlot = GameManager.GetInstance().slotList[slotNum].gameObject;

                //  Debug.Log(slotList[slotNum].name + "��ġ��" + soliderNum + "�� ��ȯ�մϴ�.");

                GameManager.GetInstance().slotList.RemoveAt(slotNum);

            }
        }
        else
        {
            Debug.Log("������ �����մϴ�.");
        }

    }

    // merge�� �ϸ鼭 ������ �뺴�� �ֱ� ������
    // ������ �÷��ٶ� �뺴�� ����Ʈ�� �ִ��� ������ Ȯ���ϰ�
    // ���ٸ� �ش� �ε����� ���� �� i--�� ���ش�.
    // i�� ������ ������ i--�� ���־� for���� ������ i++�� �Ǽ� �ٽ� ������ �ݺ���ƾ�� �ǵ��� �ϱ� ����.

    public void UpgradeFirstStat()
    {
        if(GameManager.GetInstance().heroCoin >= firstStatCost)
        {
            // ������ ��ȭ�� �����ϰ�, ����� ������Ų��.
            GameManager.GetInstance().heroCoin -= firstStatCost;
            GameManager.GetInstance().heroCoinText.text = GameManager.GetInstance().heroCoin.ToString();
            firstStatCost += 20;
            firstStatCostText.text = firstStatCost.ToString();

            SoldierStat soldierStat = GameManager.GetInstance().soliderPrefabList[0].GetComponent<SoldierStat>();

            soldierStat.curAttackSpeed++;

            for (int i = 0; i < GameManager.GetInstance().firstSoliderList.Count; i++)
            {
                if (GameManager.GetInstance().firstSoliderList[i] != null)
                {
                    soldierStat = GameManager.GetInstance().firstSoliderList[i].gameObject.GetComponent<SoldierStat>();
                    soldierStat.attackSpeed--;
                }
                else
                {
                    GameManager.GetInstance().firstSoliderList.RemoveAt(i);
                    i--;
                }
            }
        }
        else
        {
            Debug.Log("��ȭ�� ������ ù��° �뺴 ��ȭ�� �� �� �����ϴ�.");
        }
    }

    public void UpgradeSecondStat()
    {
        if (GameManager.GetInstance().heroCoin >= secondStatCost)
        {
            // ������ ��ȭ�� �����ϰ�, ����� ������Ų��.
            GameManager.GetInstance().heroCoin -= secondStatCost;
            GameManager.GetInstance().heroCoinText.text = GameManager.GetInstance().heroCoin.ToString();
            secondStatCost += 20;
            secondStatCostText.text = secondStatCost.ToString();

            SoldierStat soldierStat = GameManager.GetInstance().soliderPrefabList[1].GetComponent<SoldierStat>();

            soldierStat.curAttackSpeed++;

            for (int i = 0; i < GameManager.GetInstance().secondSoliderList.Count; i++)
            {
                if (GameManager.GetInstance().secondSoliderList[i] != null)
                {
                    soldierStat = GameManager.GetInstance().secondSoliderList[i].gameObject.GetComponent<SoldierStat>();
                    soldierStat.attackSpeed--;
                }
                else
                {
                    GameManager.GetInstance().secondSoliderList.RemoveAt(i);
                    i--;
                }

            }
        }
        else
        {
            Debug.Log("��ȭ�� ������ �ι�° �뺴 ��ȭ�� �� �� �����ϴ�.");
        }
    }

    public void UpgradeThirdStat()
    {

        if (GameManager.GetInstance().heroCoin >= thirdStatCost)
        {
            // ������ ��ȭ�� �����ϰ�, ����� ������Ų��.
            GameManager.GetInstance().heroCoin -= thirdStatCost;
            GameManager.GetInstance().heroCoinText.text = GameManager.GetInstance().heroCoin.ToString();
            thirdStatCost += 20;
            thirdStatCostText.text = thirdStatCost.ToString();

            SoldierStat soldierStat = GameManager.GetInstance().soliderPrefabList[2].GetComponent<SoldierStat>();

            soldierStat.curAttackSpeed++;

            for (int i = 0; i < GameManager.GetInstance().thirdSoliderList.Count; i++)
            {
                if (GameManager.GetInstance().thirdSoliderList[i] != null)
                {
                    soldierStat = GameManager.GetInstance().thirdSoliderList[i].gameObject.GetComponent<SoldierStat>();
                    soldierStat.attackSpeed--;
                }
                else
                {
                    GameManager.GetInstance().thirdSoliderList.RemoveAt(i);
                    i--;
                }
            }
        }
        else
        {
            Debug.Log("��ȭ�� ������ ����° �뺴 ��ȭ�� �� �� �����ϴ�.");
        }
    }

    public void UpgradeForthStat()
    {
        if (GameManager.GetInstance().heroCoin >= fourthStatCost)
        {
            // ������ ��ȭ�� �����ϰ�, ����� ������Ų��.
            GameManager.GetInstance().heroCoin -= fourthStatCost;
            GameManager.GetInstance().heroCoinText.text = GameManager.GetInstance().heroCoin.ToString();
            fourthStatCost += 20;
            fourthStatCostText.text = fourthStatCost.ToString();

            SoldierStat soldierStat = GameManager.GetInstance().soliderPrefabList[3].GetComponent<SoldierStat>();

            soldierStat.curAttackSpeed++;

            for (int i = 0; i < GameManager.GetInstance().forthSoliderList.Count; i++)
            {
                if (GameManager.GetInstance().forthSoliderList[i] != null)
                {
                    soldierStat = GameManager.GetInstance().forthSoliderList[i].gameObject.GetComponent<SoldierStat>();
                    soldierStat.attackSpeed--;
                }
                else
                {
                    GameManager.GetInstance().forthSoliderList.RemoveAt(i);
                    i--;
                }
            }
        }
        else
        {
            Debug.Log("��ȭ�� ������ �׹�° �뺴 ��ȭ�� �� �� �����ϴ�.");
        }
    }

    public void UpgradeFifthStat()
    {
        if (GameManager.GetInstance().heroCoin >= fifthStatCost)
        {
            // ������ ��ȭ�� �����ϰ�, ����� ������Ų��.
            GameManager.GetInstance().heroCoin -= fifthStatCost;
            GameManager.GetInstance().heroCoinText.text = GameManager.GetInstance().heroCoin.ToString();
            fifthStatCost += 20;
            firstStatCostText.text = firstStatCost.ToString();

            SoldierStat soldierStat = GameManager.GetInstance().soliderPrefabList[4].GetComponent<SoldierStat>();

            soldierStat.curAttackSpeed++;

            for (int i = 0; i < GameManager.GetInstance().fifthSoliderList.Count; i++)
            {
                if (GameManager.GetInstance().fifthSoliderList[i] != null)
                {
                    soldierStat = GameManager.GetInstance().fifthSoliderList[i].gameObject.GetComponent<SoldierStat>();
                    soldierStat.attackSpeed--;
                }
                else
                {
                    GameManager.GetInstance().fifthSoliderList.RemoveAt(i);
                    i--;
                }
            }
        }
        else
        {
            Debug.Log("��ȭ�� ������ �ټ���° �뺴 ��ȭ�� �� �� �����ϴ�.");
        }
    }
}
