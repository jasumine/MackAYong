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

    private MonsterController monsterController;
    private DevilDraw devillDraw;
    private SpecialAbility specialAbility;

    private void Start()
    {
        stage = 1;
        stageTime = stageMaxTime;

        monsterController = GetComponent<MonsterController>();
        devillDraw = GetComponent<DevilDraw>();
        specialAbility = GetComponent<SpecialAbility>();
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

            GameManager.GetInstance().heroCoin += 100;
            GameManager.GetInstance().heroCoinText.text = GameManager.GetInstance().heroCoin.ToString();
            GameManager.GetInstance().devilCoin += 100;
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();
            


            Debug.Log("다음 스테이지로 넘어갑니다.");
            // 3판마다 특별능력 뽑기 진행
            if (stage % 3 == 0)
            {
                Debug.Log("특별 능력 뽑기를 진행합니다.");
                specialAbility.SpecialAbilityController();
                
            }

            // 5판마다 보스스테이지 진행 외에는 몬스터소환
            if (stage % 5 == 0)
            {
                Debug.Log("보스 스테이지를 진행합니다.");
                devillDraw.SummonSetBoss();
            }
            else
            {
                Debug.Log("일반 스테이지를 진행합니다.");
                monsterController.CreateController();

            }
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
