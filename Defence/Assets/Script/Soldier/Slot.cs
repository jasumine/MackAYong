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
                Debug.Log("소환 할 슬롯이 없습니다.");
            }
            else
            {
                // 소지한 재화를 감소하고, 비용을 증가시킨다.
                GameManager.GetInstance().heroCoin -= drawCost;
                GameManager.GetInstance().heroCoinText.text = GameManager.GetInstance().heroCoin.ToString();
                drawCost += 2;
                drawCostText.text = drawCost.ToString();


                // slot의 위치를 랜덤으로 고르고
                int slotNum = Random.Range(0, GameManager.GetInstance().slotList.Count);

                // 용병도 랜덤으로 고른 후
                int soldierNum = Random.Range(0, GameManager.GetInstance().soliderPrefabList.Count);

                // 용병 object를 slotList의 위치에 생성해준다.
                // 용병 object에 맞추어서 해당 용병끼리 모아둔 list에 넣어준다.
                GameObject soldier = Instantiate(GameManager.GetInstance().soliderPrefabList[soldierNum], GameManager.GetInstance().slotList[slotNum].gameObject.transform);
                GameManager.GetInstance().InputSoldierList(soldierNum, soldier);

                SoldierStat stat = soldier.GetComponent<SoldierStat>();
                stat.mySlot = GameManager.GetInstance().slotList[slotNum].gameObject;

                //  Debug.Log(slotList[slotNum].name + "위치에" + soliderNum + "를 소환합니다.");

                GameManager.GetInstance().slotList.RemoveAt(slotNum);

            }
        }
        else
        {
            Debug.Log("코인이 부족합니다.");
        }

    }

    // merge를 하면서 없어진 용병이 있기 때문에
    // 스탯을 올려줄때 용병이 리스트에 있는지 없는지 확인하고
    // 없다면 해당 인덱스를 지운 후 i--를 해준다.
    // i를 지웠기 때문에 i--를 해주어 for문이 끝나면 i++이 되서 다시 원래의 반복루틴이 되도록 하기 위함.

    public void UpgradeFirstStat()
    {
        if(GameManager.GetInstance().heroCoin >= firstStatCost)
        {
            // 소지한 재화를 감소하고, 비용을 증가시킨다.
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
            Debug.Log("재화가 부족해 첫번째 용병 강화를 할 수 없습니다.");
        }
    }

    public void UpgradeSecondStat()
    {
        if (GameManager.GetInstance().heroCoin >= secondStatCost)
        {
            // 소지한 재화를 감소하고, 비용을 증가시킨다.
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
            Debug.Log("재화가 부족해 두번째 용병 강화를 할 수 없습니다.");
        }
    }

    public void UpgradeThirdStat()
    {

        if (GameManager.GetInstance().heroCoin >= thirdStatCost)
        {
            // 소지한 재화를 감소하고, 비용을 증가시킨다.
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
            Debug.Log("재화가 부족해 세번째 용병 강화를 할 수 없습니다.");
        }
    }

    public void UpgradeForthStat()
    {
        if (GameManager.GetInstance().heroCoin >= fourthStatCost)
        {
            // 소지한 재화를 감소하고, 비용을 증가시킨다.
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
            Debug.Log("재화가 부족해 네번째 용병 강화를 할 수 없습니다.");
        }
    }

    public void UpgradeFifthStat()
    {
        if (GameManager.GetInstance().heroCoin >= fifthStatCost)
        {
            // 소지한 재화를 감소하고, 비용을 증가시킨다.
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
            Debug.Log("재화가 부족해 다섯번째 용병 강화를 할 수 없습니다.");
        }
    }
}
