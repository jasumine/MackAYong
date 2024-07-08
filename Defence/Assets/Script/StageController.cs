using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public List<GameObject> gate;

    public int stage;
    public float stageTime;
    public float stageMaxTime;

    public bool stgeStart;

    private void Start()
    {
        stage = 1;
        stageTime = stageMaxTime;
        stgeStart = true;
    }


    private void Update()
    {
        CheckGateHp();
        StageCoolDown();
    }

    private void StageCoolDown()
    {
        stageTime -= Time.deltaTime;
        if(stageTime <0)
        {
            stage++;
            stageTime = stageMaxTime;
            stgeStart = true;
            Debug.Log("다음 스테이지로 넘어갑니다.");
        }
    }



    public void CheckGateHp()
    {
        if (gate[0] != null)
        {
            Gate gateComponent = gate[0].GetComponent<Gate>();

            if(gateComponent.GetHp()  <=0)
            {
                
                gate[0].SetActive(false);
                gate.RemoveAt(0);
                Debug.Log("문이 부셔졌습니다.");
            }
        }

        if(gate.Count <=0)
        {
            // TODO : 게임 종료 처리하기

            Debug.Log("모든 문이 부셔져 게임이 끝납니다.");
            
        }
    }

}
