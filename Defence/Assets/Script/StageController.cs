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
            


            Debug.Log("���� ���������� �Ѿ�ϴ�.");
            // 3�Ǹ��� Ư���ɷ� �̱� ����
            if (stage % 3 == 0)
            {
                Debug.Log("Ư�� �ɷ� �̱⸦ �����մϴ�.");
                specialAbility.SpecialAbilityController();
                
            }

            // 5�Ǹ��� ������������ ���� �ܿ��� ���ͼ�ȯ
            if (stage % 5 == 0)
            {
                Debug.Log("���� ���������� �����մϴ�.");
                devillDraw.SummonSetBoss();
            }
            else
            {
                Debug.Log("�Ϲ� ���������� �����մϴ�.");
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
                Debug.Log("���� �μ������ϴ�.");
            }
        }

        if(gate.Count <=0)
        {
            // TODO : ���� ���� ó���ϱ�

            Debug.Log("��� ���� �μ��� ������ �����ϴ�.");
            
        }
    }

}
