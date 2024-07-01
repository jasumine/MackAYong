using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // 몬스터 생성을 담당하는 클래스


    public List<GameObject> monsterList;
    public List<GameObject> monsterPrefabs;

    public List<Transform> wayPoints;

    public GameObject monsterParent;
    private float delayMonster;

    StageController stage;

    private void Start()
    {
        stage = GetComponent<StageController>();
    }


    private void Update()
    {
        if (stage.stgeStart == true)
        {
            stage.stgeStart = false;
            CreateMonster();
        }

    }

    private void CreateMonster()
    {
        // 매 라운드마다 20마리의 몬스터를 생성한다.
        for(int i = 0; i<20;i++)
        {
            GameObject monster = Instantiate(monsterPrefabs[0], wayPoints[0].transform.position, Quaternion.identity);

            monsterList.Add(monster);

            monster.name= monster+i.ToString();
            monster.transform.parent = monsterParent.transform;
        }
    }


    private void OnGUI()
    {
        if (GUI.Button(new Rect(120, 10, 100, 100), "hp 증가"))
        {
            IncreaseHp();
        }

        if (GUI.Button(new Rect(120, 120, 100, 100), "이동속도 증가"))
        {
            IncreaseSpeed();
        }

        if (GUI.Button(new Rect(120, 230, 100, 100), "공격속도 증가"))
        {
            IncreaseAttackSpeed();
        }

        if (GUI.Button(new Rect(120, 340, 100, 100), "골드획득 증가"))
        {
            IncreaseAttackSpeed();
        }

        if (GUI.Button(new Rect(120, 450, 100, 100), "확률 증가"))
        {
            IncreasePercent();
        }
    }

    private void IncreaseHp()
    {
        for (int i = 0; i < monsterList.Count; i++)
        {
            MonsterStat mStat = monsterList[i].GetComponent<MonsterStat>();

            mStat.maxHp++;
        }
        Debug.Log("hp를 증가합니다.");
    }

    private void IncreaseSpeed()
    {
        for (int i = 0; i < monsterList.Count; i++)
        {
            MonsterStat mStat = monsterList[i].GetComponent<MonsterStat>();

            mStat.speed++;
        }
        Debug.Log("속도를 증가합니다.");
    }


    private void IncreaseAttackSpeed()
    {
        for (int i = 0; i < monsterList.Count; i++)
        {
            MonsterStat mStat = monsterList[i].GetComponent<MonsterStat>();

            mStat.attackSpeed++;
        }
        Debug.Log("공격속도를 증가합니다.");
    }

    private void IncreaseGold()
    {
        for (int i = 0; i < monsterList.Count; i++)
        {
            MonsterStat mStat = monsterList[i].GetComponent<MonsterStat>();

            mStat.speed++;
        }
        Debug.Log("재화 획득량을 증가합니다.");
    }

    private void IncreasePercent()
    {
        for (int i = 0; i < monsterList.Count; i++)
        {
            MonsterStat mStat = monsterList[i].GetComponent<MonsterStat>();

            mStat.speed++;
        }
        Debug.Log("뽑기 획득률을 증가합니다.");
    }


    /*
    // 풀링을 이용한 몬스터 생성
    public List<GameObject> monsterPullingObject = new List<GameObject>();

    public void CreateMonster()
    {
        Debug.Log("몬스터를 생성합니다.");

        for (int i = 0; i < monsterPullingObject.Count; i++)
        {
            if (monsterPullingObject[i].activeInHierarchy == false)
            {
                monsterPullingObject[i].SetActive(true);
                GameManager.instance.usingMonsterList.Add(monsterPullingObject[i]);
                return;
            }
        }

    }


    // 몬스터 위치 랜덤 생성
    private void CreateMonsterRandom()
    {

        Debug.Log("무작위 위치에 몬스터를 생성합니다.");

        delayMonster += time.deltaTime();

        if(delayMonster > 2f)
        {
            // y의 위치를 출발지~중간지점1 까지 랜덤으로 넣고
            // x의 위치를 약간만 조정(랜덤이라는 느낌이 나기위해)
            GameObject monster = Instantiate(monsterPullingObject[0], monsterPullingObject.transform.position);

            GameManager.instance.usingMonsterList.Add(monster);
        }
    }
    */

}
