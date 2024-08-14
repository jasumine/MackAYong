using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // 몬스터 생성을 담당하는 클래스
    public List<Transform> wayPoints;

    public GameObject monsterParent;
    public float delayMonster;
    public float monsterCount;
    public int monsterCountMax; //몬스터  소환 최대 횟수

    public int monsterHpUp = -1;
    public int monsterHpAmount = 10;

    public void CreateController()
    {
        monsterCount = 0;
        monsterHpUp++;
        StartCoroutine("CreateMonster");
    }


   /* private void CreateMonster()
    { 

        //매 라운드마다 20마리의 몬스터를 생성한다.
        for (int i = 0; i < 20; i++)
        {
            GameObject monster = Instantiate(monsterPrefabs[0], wayPoints[0].transform.position, Quaternion.identity);

            Monster monsterScript = monster.GetComponent<Monster>();
            monsterScript.wayPoints.Add(wayPoints[0]);
            monsterScript.wayPoints.Add(wayPoints[1]);
            monsterScript.wayPoints.Add(wayPoints[2]);
            monsterScript.wayPoints.Add(wayPoints[3]);

            monsterList.Add(monster);

            monster.name = monster + i.ToString();
            monster.transform.parent = monsterParent.transform;

        }
    }
   */
    IEnumerator CreateMonster()
    {
        // CreateMonster를 할 때마다, hp가 증가한다.
        MonsterStat monStat= GameManager.GetInstance().monsterPrefabs[0].GetComponent<MonsterStat>();
        monStat.maxHp += monsterHpUp * monsterHpAmount;

        // 몬스터 소환 횟수 조절
        while (monsterCount != monsterCountMax)
        {
            GameObject monster = Instantiate(GameManager.GetInstance().monsterPrefabs[0], wayPoints[0].transform.position, Quaternion.identity);

            Monster monsterScript = monster.GetComponent<Monster>();
            monsterScript.wayPoints.Add(wayPoints[0]);
            monsterScript.wayPoints.Add(wayPoints[1]);
            monsterScript.wayPoints.Add(wayPoints[2]);
            monsterScript.wayPoints.Add(wayPoints[3]);

            GameManager.instance.monsterList.Add(monster);

            monster.name = monster + monsterCount.ToString();
            monster.transform.parent = monsterParent.transform;

            yield return new WaitForSeconds(delayMonster);
           monsterCount++;
        }
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
