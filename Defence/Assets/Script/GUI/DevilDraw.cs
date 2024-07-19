using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilDraw : MonoBehaviour
{

    public List<GameObject> bossMonsterPrefab;

    public int bossOneCount;
    public int bossTwoCount;
    public int bossThreeCount;
    public int bossFourCount;
    public int bossFiveCount;

    // 중간 보스 소환
    public void SummonSetBoss()
    {
        // TODO 선택된 몬스터가 있다면, 해당 몬스터를 소환한다.

        // 없다면 가진 몬스터에서 소환한다.
        // 1단계
        if(bossOneCount !=0)
        {
            SummonBoss(0);
            bossOneCount--;
        }
        else
        {
            // 2단계
            if(bossTwoCount !=0)
            {
                SummonBoss(1);
                bossTwoCount--;
            }
            else
            {
                // 3단계
                if(bossThreeCount !=0)
                {
                    SummonBoss(2);
                    bossThreeCount--;
                }
                else
                {
                    // 4단계
                    if(bossFourCount!=0)
                    {
                        SummonBoss(3);
                        bossFourCount--;
                    }
                    else
                    {
                        // 5단계
                        if(bossFiveCount != 0)
                        {
                            SummonBoss(4);
                            bossFiveCount--;
                        }
                        else
                        {
                            // 마지막 단계까지 몬스터가 없다면 기본 몬스터를 소환
                            Debug.Log("가진 재화가 없어 기본 등급 보스가 소환됩니다.");
                            SummonBoss(0);
                            // TODO 재화 소모 추가하기.
                           
                        }
                    }
                    
                }
            }
        }

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
