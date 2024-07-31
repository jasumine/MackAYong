using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{

    public void Summon()
    {
        if (GameManager.GetInstance().slotList.Count == 0)
        {
            Debug.Log("소환 할 슬롯이 없습니다.");
        }
        else
        {
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

    // merge를 하면서 없어진 용병이 있기 때문에
    // 스탯을 올려줄때 용병이 리스트에 있는지 없는지 확인하고
    // 없다면 해당 인덱스를 지운 후 i--를 해준다.
    // i를 지웠기 때문에 i--를 해주어 for문이 끝나면 i++이 되서 다시 원래의 반복루틴이 되도록 하기 위함.

    public void UpgradeFirstStat()
    {
        SoldierStat soldierStat = GameManager.GetInstance().soliderPrefabList[0].GetComponent<SoldierStat>();

        soldierStat.curAttackSpeed++;

        for(int i = 0; i< GameManager.GetInstance().firstSoliderList.Count; i++)
        {
            if(GameManager.GetInstance().firstSoliderList[i] != null)
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

    public void UpgradeSecondStat()
    {
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

    public void UpgradeThirdStat()
    {
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

    public void UpgradeForthStat()
    {
        SoldierStat soldierStat = GameManager.GetInstance().soliderPrefabList[3].GetComponent<SoldierStat>();

        soldierStat.curAttackSpeed++;

        for (int i = 0; i < GameManager.GetInstance().forthSoliderList.Count; i++)
        {
            if(GameManager.GetInstance().forthSoliderList[i] != null)
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

    public void UpgradeFifthStat()
    {
        SoldierStat soldierStat = GameManager.GetInstance().soliderPrefabList[4].GetComponent<SoldierStat>();

        soldierStat.curAttackSpeed++;

        for (int i = 0; i < GameManager.GetInstance().fifthSoliderList.Count; i++)
        {
            if(GameManager.GetInstance().fifthSoliderList[i] != null)
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
}
