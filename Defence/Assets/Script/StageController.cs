using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public List<GameObject> gate;

    public int stage;
    public float stageTime;
    public float stageMaxTime;

    public TextMeshProUGUI stageText;
    public TextMeshProUGUI stageTimeText;
    public TextMeshProUGUI stageInfoText;

    private MonsterController monsterController;
    private SpecialAbility specialAbility;

    private void Start()
    {
        stage = 0;
        stageText.text = "Stage : " + stage.ToString();
        stageTime = stageMaxTime;
        stageTimeText.text = stageTime.ToString("F2");
        stageInfoText.text = "Game Start";

        monsterController = GetComponent<MonsterController>();
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
        stageTimeText.text = stageTime.ToString("F2");

        if (stageTime <0)
        {
            stage++;
            stageText.text = "Stage : " + stage.ToString();
            stageTime = stageMaxTime;
            stageTimeText.text = stageTime.ToString("F2");

            GameManager.GetInstance().heroCoin += 100;
            GameManager.GetInstance().heroCoinText.text = GameManager.GetInstance().heroCoin.ToString();
            GameManager.GetInstance().devilCoin += 100;
            GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();
            


            Debug.Log("���� ���������� �Ѿ�ϴ�.");
            // 3�Ǹ��� Ư���ɷ� �̱� ����
            if (stage % 3 == 0)
            {
                Debug.Log("Ư�� �ɷ� �̱⸦ �����մϴ�.");
                stageInfoText.text = "SpecialAbility Stage";
                specialAbility.SpecialAbilityController();
            }

            // 5�Ǹ��� ������������ ���� �ܿ��� ���ͼ�ȯ
            if (stage % 5 == 0)
            {
                Debug.Log("���� ���������� �����մϴ�.");
                stageInfoText.text = "Boss Stage";
                monsterController.SummonSetBoss();
            }
            else
            {
                Debug.Log("�Ϲ� ���������� �����մϴ�.");
                stageInfoText.text = "Basic Stage";
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

                switch(gate.Count)
                {
                    // 2�� ���� ��� - ���� 1�� �ν���
                    case 2:
                        GameManager.GetInstance().devilCoin += 500;
                        break;
                    // 1�� ���� ��� - ���� 2�� �ν���
                    case 1:
                        GameManager.GetInstance().devilCoin += 1000;
                        break;
                    case 0:
                        GameManager.GetInstance().devilCoin += 1500;
                        break;
                }
                GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();
            }
        }

        if(gate.Count <=0)
        {
            // TODO : ���� ���� ó���ϱ�

            Debug.Log("��� ���� �μ��� ������ �����ϴ�.");
            
        }
    }

}
