//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class DevilDraw : MonoBehaviour
//{

//    // 중간 보스 소환
//    public void SummonSetBoss()
//    {
//        // TODO 선택된 몬스터가 있다면, 해당 몬스터를 소환한다.
//        Debug.Log("보스 소환을 진행합니다.");
//        if(GameManager.GetInstance().selectBossObject.sprite !=null)
//        {
//            for(int i =0; i< GameManager.GetInstance().monsterPrefabs.Count; i++)
//            {
//                SpriteRenderer sprite = GameManager.GetInstance().monsterPrefabs[i].GetComponent<SpriteRenderer>();

//                if (sprite.sprite == GameManager.GetInstance().selectBossObject.sprite)
//                {
//                    SummonBoss(i);
//                }
//            }
//        }
//        // 없다면 가진 몬스터에서 소환한다.
//        else
//        {
//            // 1단계
//            if (GameManager.GetInstance().bossCount[0] != 0)
//            {
//                Debug.Log("첫번째 보스를 소환합니다.");
//                SummonBoss(0);
//                GameManager.GetInstance().bossCount[0]--;
//                GameManager.GetInstance().bossCountText[0].text = GameManager.GetInstance().bossCount[0].ToString();
//            }
//            else
//            {
//                // 2단계
//                if (GameManager.GetInstance().bossCount[1] != 0)
//                {
//                    Debug.Log("두번째 보스를 소환합니다.");
//                    SummonBoss(1);
//                    GameManager.GetInstance().bossCount[1]--;
//                    GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossCount[1].ToString();
//                }
//                else
//                {
//                    // 3단계
//                    if (GameManager.GetInstance().bossCount[2] != 0)
//                    {
//                        Debug.Log("세번째 보스를 소환합니다.");
//                        SummonBoss(2);
//                        GameManager.GetInstance().bossCount[2]--;
//                        GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossCount[2].ToString();
//                    }
//                    else
//                    {
//                        // 4단계
//                        if (GameManager.GetInstance().bossCount[3] != 0)
//                        {
//                            Debug.Log("네번째 보스를 소환합니다.");
//                            SummonBoss(3);
//                            GameManager.GetInstance().bossCount[3]--;
//                            GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossCount[3].ToString();
//                        }
//                        else
//                        {
//                            // 5단계
//                            if (GameManager.GetInstance().bossCount[4] != 0)
//                            {
//                                Debug.Log("5번째 보스를 소환합니다.");
//                                SummonBoss(4);
//                                GameManager.GetInstance().bossCount[4]--;
//                                GameManager.GetInstance().bossCountText[4].text = GameManager.GetInstance().bossCount[4].ToString();
//                            }
//                            else
//                            {
//                                // 마지막 단계까지 몬스터가 없다면 기본 몬스터를 소환
//                                Debug.Log("가진 재화가 없어 기본 등급 보스가 소환됩니다.");
//                                SummonBoss(0);
//                                // TODO 재화 소모 추가하기.
//                                GameManager.GetInstance().devilCoin -= 100;
//                                GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

//                            }
//                        }

//                    }
//                }
//            }
//        }

//        // 소환이 끝나면 비워준다.
//        GameManager.GetInstance().selectBossObject.sprite = null;
//        GameManager.GetInstance().selectBossNum = 0;
//        heroBossImage.sprite = null;
//    }


//    private void SummonBoss(int num)
//    {
//        monsterHpUp++;

//        Debug.Log(num + "번째 중간 보스를 소환합니다.");
//        GameObject boss = Instantiate(GameManager.GetInstance().monsterPrefabs[num+1], )
//        GameManager.GetInstance().monsterPrefabs[num].SetActive(true);
//        GameManager.instance.monsterList.Add(GameManager.GetInstance().monsterPrefabs[num]);

//        Monster monsterScript = GameManager.GetInstance().monsterPrefabs[num].GetComponent<Monster>();
//        MonsterStat monsterStat = GameManager.GetInstance().monsterPrefabs[num].GetComponent<MonsterStat>();

//        monsterStat.maxHp += monsterHpUp * monsterHpAmount; // 소환 될 때마다 monsterHp를 증가시켜준다.
//        monsterStat.curHp = monsterStat.maxHp;
        

//        GameManager.GetInstance().monsterPrefabs[num].transform.position = monsterScript.wayPoints[0].position;
//        monsterScript.targetPoint = monsterScript.wayPoints[1];

//        monsterScript.monsterState = MonsterState.move;



//        // ---------------------------------------------

//        MonsterStat monStat = GameManager.GetInstance().monsterPrefabs[0].GetComponent<MonsterStat>();
//        monStat.maxHp += monsterHpUp * monsterHpAmount;



//        // Debug.Log(monsterCount +" , " + monsterCountMax);
//        GameObject monster = Instantiate(GameManager.GetInstance().monsterPrefabs[0], wayPoints[0].transform.position, Quaternion.identity);
//        // Debug.Log("몬스터 생성");

//        GameObject hpBar = Instantiate(hpBarPrefab, GameManager.GetInstance().hpBarParent.transform);
//        //Debug.Log("Hp바 생성");

//        Monster monsterScript = monster.GetComponent<Monster>();
//        monsterScript.wayPoints.Add(wayPoints[0]);
//        monsterScript.wayPoints.Add(wayPoints[1]);
//        monsterScript.wayPoints.Add(wayPoints[2]);
//        monsterScript.wayPoints.Add(wayPoints[3]);
//        //Debug.Log("몬스터 웨이포인트 추가");

//        GameManager.instance.monsterList.Add(monster);
//        //Debug.Log("몬스터 리스트 추가");

//        monster.name = "monster " + monStat.maxHp + "(" + monsterCount + ")";
//        monster.transform.parent = monsterParent.transform;
//        //Debug.Log("몬스터 이름변경, 부모 설정");

//        hpBar.name = monster.name + "hp Bar";

//        //Debug.Log("Set Hp Bar"+monsterScript.mStat);
//        monsterScript.SetHpBar(hpBar);
//        //Debug.Log("hp바 연동");

//        //Debug.Log(delayMonster);

//        yield return new WaitForSeconds(delayMonster);
//        //Debug.Log("몬스터 쿨타임");
//        monsterCount++;
//    }


//    /*
//     private void OnGUI()
//    {
//        if(GUI.Button(new Rect(10,120, 100,100), "일반 100%"))
//        {
//            BossFirstDraw();
//        }
//        if (GUI.Button(new Rect(10, 230, 100, 100), "희귀 60%"))
//        {
//            BossSecondDraw();
//        }
//        if (GUI.Button(new Rect(10, 340, 100, 100), "영웅 20%"))
//        {
//            BossThirdDraw();
//        }
//        if (GUI.Button(new Rect(10, 450, 100, 100), "전설 5%"))
//        {
//            BossForthDraw();
//        }
//        if (GUI.Button(new Rect(10, 560, 100, 100), "신화 1%"))
//        {
//            BossFifhDraw();
//        }
//    }
//    */
//}
