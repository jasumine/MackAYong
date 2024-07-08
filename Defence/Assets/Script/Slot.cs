using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{

    public List<GameObject> slotList;
    public List<GameObject> soliderList;



    private void OnGUI()
    {

        if (GUI.Button(new Rect(10, 10, 100, 100), "solider"))
        {
            Summon();
        }
    }

    private void Summon()
    {
        if (slotList.Count == 0)
        {
            Debug.Log("��ȯ �� ������ �����ϴ�.");
        }
        else
        {
            // slot�� ��ġ�� �������� ����
            int slotNum = Random.Range(0, slotList.Count);

            // �뺴�� �������� �� ��
            int soliderNum = Random.Range(0, soliderList.Count);

            // �뺴 object�� slotList�� ��ġ�� �������ش�.
            GameObject solider = Instantiate(soliderList[soliderNum], slotList[slotNum].gameObject.transform);

          //  Debug.Log(slotList[slotNum].name + "��ġ��" + soliderNum + "�� ��ȯ�մϴ�.");

            slotList.RemoveAt(slotNum);

        }
    }

}
