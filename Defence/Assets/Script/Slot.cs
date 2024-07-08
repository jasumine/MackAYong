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
            Debug.Log("소환 할 슬롯이 없습니다.");
        }
        else
        {
            // slot의 위치를 랜덤으로 고르고
            int slotNum = Random.Range(0, slotList.Count);

            // 용병도 랜덤으로 고른 후
            int soliderNum = Random.Range(0, soliderList.Count);

            // 용병 object를 slotList의 위치에 생성해준다.
            GameObject solider = Instantiate(soliderList[soliderNum], slotList[slotNum].gameObject.transform);

          //  Debug.Log(slotList[slotNum].name + "위치에" + soliderNum + "를 소환합니다.");

            slotList.RemoveAt(slotNum);

        }
    }

}
