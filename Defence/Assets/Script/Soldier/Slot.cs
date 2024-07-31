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
            Debug.Log("��ȯ �� ������ �����ϴ�.");
        }
        else
        {
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

    // merge�� �ϸ鼭 ������ �뺴�� �ֱ� ������
    // ������ �÷��ٶ� �뺴�� ����Ʈ�� �ִ��� ������ Ȯ���ϰ�
    // ���ٸ� �ش� �ε����� ���� �� i--�� ���ش�.
    // i�� ������ ������ i--�� ���־� for���� ������ i++�� �Ǽ� �ٽ� ������ �ݺ���ƾ�� �ǵ��� �ϱ� ����.

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
