using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{

    public List<GameObject> slotList;
    public List<GameObject> soliderPrefabList;


    public List<List<GameObject>> soliderList;
    public List<GameObject> firstSoliderList;
    public List<GameObject> secondSoliderList;
    public List<GameObject> thirdSoliderList;
    public List<GameObject> forthSoliderList;
    public List<GameObject> fifthSoliderList;

    /*
    private void OnGUI()
    {

        if (GUI.Button(new Rect(10, 10, 100, 100), "solider"))
        {
            Summon();
        }
    }
    */

    private void Start()
    {
        AddList();
    }

    private void AddList()
    {
        
        soliderList.Add(firstSoliderList);
        Debug.Log("fisrt add");
        soliderList.Add(secondSoliderList);
        Debug.Log("2 add");
        soliderList.Add(thirdSoliderList);
        Debug.Log("3 add");
        soliderList.Add(forthSoliderList);
        Debug.Log("4 add");
        soliderList.Add(fifthSoliderList);
        Debug.Log("5 add");
    }


    public void Summon()
    {
        if (slotList.Count == 0)
        {
            Debug.Log("소환 할 슬롯이 없습니다.");
        }
        else
        {
            // slot의 위치를 랜덤으로 고르고
            int slotNum = Random.Range(0, slotList.Count);

            // 용병도 랜덤으로 고른 후
            int soldierNum = Random.Range(0, soliderPrefabList.Count);

            // 용병 object를 slotList의 위치에 생성해준다.
            // 용병 object에 맞추어서 해당 용병끼리 모아둔 list에 넣어준다.
            GameObject soldier = Instantiate(soliderPrefabList[soldierNum], slotList[slotNum].gameObject.transform);
            InputSoldierList(soldierNum, soldier);


            //  Debug.Log(slotList[slotNum].name + "위치에" + soliderNum + "를 소환합니다.");

            slotList.RemoveAt(slotNum);

        }
    }

    private void InputSoldierList(int num, GameObject gameObject)
    {
        switch(num)
        {
            case 0:
                firstSoliderList.Add(gameObject);
                break;
            case 1:
                secondSoliderList.Add(gameObject);
                break;
            case 2:
                thirdSoliderList.Add(gameObject);
                break;
            case 3:
                forthSoliderList.Add(gameObject);
                break;
            case 4:
                fifthSoliderList.Add(gameObject);
                break;
        }
    }



    public void UpgradeFirstStat()
    {
        SoldierStat soldierStat = soliderPrefabList[0].GetComponent<SoldierStat>();

        soldierStat.curAttackSpeed++;

        for(int i = 0; i< firstSoliderList.Count; i++)
        {
            soldierStat = firstSoliderList[i].gameObject.GetComponent<SoldierStat>();
            soldierStat.attackSpeed--;
        }
    }

    public void UpgradeSecondStat()
    {
        SoldierStat soldierStat = soliderPrefabList[1].GetComponent<SoldierStat>();

        soldierStat.curAttackSpeed++;

        for (int i = 0; i < secondSoliderList.Count; i++)
        {
            soldierStat = secondSoliderList[i].gameObject.GetComponent<SoldierStat>();
            soldierStat.attackSpeed--;
        }
    }

    public void UpgradeThirdStat()
    {
        SoldierStat soldierStat = soliderPrefabList[2].GetComponent<SoldierStat>();

        soldierStat.curAttackSpeed++;

        for (int i = 0; i < thirdSoliderList.Count; i++)
        {
            soldierStat = thirdSoliderList[i].gameObject.GetComponent<SoldierStat>();
            soldierStat.attackSpeed--;
        }
    }

    public void UpgradeForthStat()
    {
        SoldierStat soldierStat = soliderPrefabList[3].GetComponent<SoldierStat>();

        soldierStat.curAttackSpeed++;

        for (int i = 0; i < forthSoliderList.Count; i++)
        {
            soldierStat = forthSoliderList[i].gameObject.GetComponent<SoldierStat>();
            soldierStat.attackSpeed--;
        }
    }

    public void UpgradeFifthStat()
    {
        SoldierStat soldierStat = soliderPrefabList[4].GetComponent<SoldierStat>();

        soldierStat.curAttackSpeed++;

        for (int i = 0; i < fifthSoliderList.Count; i++)
        {
            soldierStat = fifthSoliderList[i].gameObject.GetComponent<SoldierStat>();
            soldierStat.attackSpeed--;
        }
    }
}
