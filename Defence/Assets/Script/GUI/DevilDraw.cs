using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevilDraw : MonoBehaviour
{

    public List<GameObject> bossMonsterPrefab;


    // 중간 보스 소환
    public void SummonSetBoss()
    {
        // TODO 선택된 몬스터가 있다면, 해당 몬스터를 소환한다.
        Debug.Log("보스 소환을 진행합니다.");
        if(GameManager.GetInstance().selectBossObject.sprite !=null)
        {
            for(int i =0; i<bossMonsterPrefab.Count; i++)
            {
                SpriteRenderer sprite = bossMonsterPrefab[i].GetComponent<SpriteRenderer>();

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
            if (GameManager.GetInstance().bossOneCount != 0)
            {
                Debug.Log("첫번째 보스를 소환합니다.");
                SummonBoss(0);
                GameManager.GetInstance().bossOneCount--;
                GameManager.GetInstance().bossCountText[0].text = GameManager.GetInstance().bossOneCount.ToString();
            }
            else
            {
                // 2단계
                if (GameManager.GetInstance().bossTwoCount != 0)
                {
                    Debug.Log("두번째 보스를 소환합니다.");
                    SummonBoss(1);
                    GameManager.GetInstance().bossTwoCount--;
                    GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossTwoCount.ToString();
                }
                else
                {
                    // 3단계
                    if (GameManager.GetInstance().bossThreeCount != 0)
                    {
                        Debug.Log("세번째 보스를 소환합니다.");
                        SummonBoss(2);
                        GameManager.GetInstance().bossThreeCount--;
                        GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossThreeCount.ToString();
                    }
                    else
                    {
                        // 4단계
                        if (GameManager.GetInstance().bossFourCount != 0)
                        {
                            Debug.Log("네번째 보스를 소환합니다.");
                            SummonBoss(3);
                            GameManager.GetInstance().bossFourCount--;
                            GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossFourCount.ToString();
                        }
                        else
                        {
                            // 5단계
                            if (GameManager.GetInstance().bossFiveCount != 0)
                            {
                                Debug.Log("5번째 보스를 소환합니다.");
                                SummonBoss(4);
                                GameManager.GetInstance().bossFiveCount--;
                                GameManager.GetInstance().bossCountText[4].text = GameManager.GetInstance().bossFiveCount.ToString();
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
    }


    private void SummonBoss(int num)
    {
        Debug.Log(num + "번째 중간 보스를 소환합니다.");
        bossMonsterPrefab[num].SetActive(true);
        GameManager.instance.monsterList.Add(bossMonsterPrefab[num]);

        Monster monsterScript = bossMonsterPrefab[num].GetComponent<Monster>();
        MonsterStat monsterStat = bossMonsterPrefab[num].GetComponent<MonsterStat>();

        monsterStat.curHp = monsterStat.maxHp;

        bossMonsterPrefab[num].transform.position = monsterScript.wayPoints[0].position;
        monsterScript.targetPoint = monsterScript.wayPoints[1];

        monsterScript.monsterState = MonsterState.move;
    }


    /*
     private void OnGUI()
    {
        if(GUI.Button(new Rect(10,120, 100,100), "일반 100%"))
        {
            BossFirstDraw();
        }
        if (GUI.Button(new Rect(10, 230, 100, 100), "희귀 60%"))
        {
            BossSecondDraw();
        }
        if (GUI.Button(new Rect(10, 340, 100, 100), "영웅 20%"))
        {
            BossThirdDraw();
        }
        if (GUI.Button(new Rect(10, 450, 100, 100), "전설 5%"))
        {
            BossForthDraw();
        }
        if (GUI.Button(new Rect(10, 560, 100, 100), "신화 1%"))
        {
            BossFifhDraw();
        }
    }
    */
}
