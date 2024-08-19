using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour
{
    // 몬스터 생성을 담당하는 클래스
    public List<Transform> wayPoints;

    public GameObject hpBarPrefab;

    public GameObject monsterParent;
    public float delayMonster;
    public float monsterCount;
    public int monsterCountMax; //몬스터  소환 최대 횟수

    public int monsterHpUp = -1;
    public int monsterHpAmount = 10;

    public Image heroBossImage;

    public int bossHpUp = -1;
    public int bossHpAmount = 50;

    public void CreateController()
    {
        monsterCount = 0;
        monsterHpUp++;
        StartCoroutine(CreateMonster());
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
        while (monsterCount < monsterCountMax)
        {
            //Debug.Log(monsterCount +" , " + monsterCountMax);
            GameObject monster = Instantiate(GameManager.GetInstance().monsterPrefabs[0], wayPoints[0].transform.position, Quaternion.identity);
            //Debug.Log("몬스터 생성");

            GameObject hpBar = Instantiate(hpBarPrefab, GameManager.GetInstance().hpBarParent.transform);
            //Debug.Log("Hp바 생성");

            Monster monsterScript = monster.GetComponent<Monster>();
            monsterScript.wayPoints.Add(wayPoints[0]);
            monsterScript.wayPoints.Add(wayPoints[1]);
            monsterScript.wayPoints.Add(wayPoints[2]);
            monsterScript.wayPoints.Add(wayPoints[3]);
            //Debug.Log("몬스터 웨이포인트 추가");

            GameManager.instance.monsterList.Add(monster);
            //Debug.Log("몬스터 리스트 추가");

            monster.name = "monster " + monStat.maxHp + "(" +monsterCount+")";
            monster.transform.parent = monsterParent.transform;
            //Debug.Log("몬스터 이름변경, 부모 설정");

            hpBar.name = monster.name + "hp Bar";

            //Debug.Log("Set Hp Bar"+monsterScript.mStat);
            monsterScript.SetHpBar(hpBar);
            //Debug.Log("hp바 연동");

            //Debug.Log(delayMonster);

            yield return new WaitForSeconds(delayMonster);
            //Debug.Log("몬스터 쿨타임");
            monsterCount++;
        }
    }



    // ======================중간보스 소환======================

    // 중간 보스 소환
    public void SummonSetBoss()
    {
        // TODO 선택된 몬스터가 있다면, 해당 몬스터를 소환한다.
        Debug.Log("보스 소환을 진행합니다.");
        if (GameManager.GetInstance().selectBossObject.sprite != null)
        {
            for (int i = 0; i < GameManager.GetInstance().monsterPrefabs.Count; i++)
            {
                SpriteRenderer sprite = GameManager.GetInstance().monsterPrefabs[i].GetComponent<SpriteRenderer>();

                if (sprite.sprite == GameManager.GetInstance().selectBossObject.sprite)
                {
                    SummonBoss(i);
                }
            }
        }
        // 없다면 가진 몬스터에서 소환한다.
        else
        {
            // 1단계
            if (GameManager.GetInstance().bossCount[0] != 0)
            {
                Debug.Log("첫번째 보스를 소환합니다.");
                SummonBoss(0);
                GameManager.GetInstance().bossCount[0]--;
                GameManager.GetInstance().bossCountText[0].text = GameManager.GetInstance().bossCount[0].ToString();
            }
            else
            {
                // 2단계
                if (GameManager.GetInstance().bossCount[1] != 0)
                {
                    Debug.Log("두번째 보스를 소환합니다.");
                    SummonBoss(1);
                    GameManager.GetInstance().bossCount[1]--;
                    GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossCount[1].ToString();
                }
                else
                {
                    // 3단계
                    if (GameManager.GetInstance().bossCount[2] != 0)
                    {
                        Debug.Log("세번째 보스를 소환합니다.");
                        SummonBoss(2);
                        GameManager.GetInstance().bossCount[2]--;
                        GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossCount[2].ToString();
                    }
                    else
                    {
                        // 4단계
                        if (GameManager.GetInstance().bossCount[3] != 0)
                        {
                            Debug.Log("네번째 보스를 소환합니다.");
                            SummonBoss(3);
                            GameManager.GetInstance().bossCount[3]--;
                            GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossCount[3].ToString();
                        }
                        else
                        {
                            // 5단계
                            if (GameManager.GetInstance().bossCount[4] != 0)
                            {
                                Debug.Log("5번째 보스를 소환합니다.");
                                SummonBoss(4);
                                GameManager.GetInstance().bossCount[4]--;
                                GameManager.GetInstance().bossCountText[4].text = GameManager.GetInstance().bossCount[4].ToString();
                            }
                            else
                            {
                                // 마지막 단계까지 몬스터가 없다면 기본 몬스터를 소환
                                Debug.Log("가진 재화가 없어 기본 등급 보스가 소환됩니다.");
                                SummonBoss(0);
                                // TODO 재화 소모 추가하기.
                                GameManager.GetInstance().devilCoin -= 100;
                                GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

                            }
                        }

                    }
                }
            }
        }

        // 소환이 끝나면 비워준다.
        GameManager.GetInstance().selectBossObject.sprite = null;
        GameManager.GetInstance().selectBossNum = 0;
        heroBossImage.sprite = null;
    }


    private void SummonBoss(int num)
    {
        bossHpUp++;

        // 몬스터 체력 증가
        MonsterStat monStat = GameManager.GetInstance().monsterPrefabs[num+1].GetComponent<MonsterStat>();
        monStat.maxHp += monsterHpUp * monsterHpAmount;

        Debug.Log(num+ "번째 중간 보스를 소환합니다.");

        // 보스, hp바 생성
        GameObject boss = Instantiate(GameManager.GetInstance().monsterPrefabs[num+1], wayPoints[0].transform.position, Quaternion.identity);
        GameObject hpBar = Instantiate(hpBarPrefab, GameManager.GetInstance().hpBarParent.transform);

        // list에 추가
        GameManager.instance.monsterList.Add(boss);

        // waypoint 추가
        Monster monsterScript = boss.GetComponent<Monster>();
        monsterScript.wayPoints.Add(wayPoints[0]);
        monsterScript.wayPoints.Add(wayPoints[1]);
        monsterScript.wayPoints.Add(wayPoints[2]);
        monsterScript.wayPoints.Add(wayPoints[3]);

        boss.name = "boss 0" +num+ " " + monStat.maxHp + "(" + monsterCount + ")";
        boss.transform.parent = monsterParent.transform;


        monsterScript.SetHpBar(hpBar);
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
