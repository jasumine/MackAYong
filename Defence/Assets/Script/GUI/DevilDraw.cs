//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class DevilDraw : MonoBehaviour
//{

//    // �߰� ���� ��ȯ
//    public void SummonSetBoss()
//    {
//        // TODO ���õ� ���Ͱ� �ִٸ�, �ش� ���͸� ��ȯ�Ѵ�.
//        Debug.Log("���� ��ȯ�� �����մϴ�.");
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
//        // ���ٸ� ���� ���Ϳ��� ��ȯ�Ѵ�.
//        else
//        {
//            // 1�ܰ�
//            if (GameManager.GetInstance().bossCount[0] != 0)
//            {
//                Debug.Log("ù��° ������ ��ȯ�մϴ�.");
//                SummonBoss(0);
//                GameManager.GetInstance().bossCount[0]--;
//                GameManager.GetInstance().bossCountText[0].text = GameManager.GetInstance().bossCount[0].ToString();
//            }
//            else
//            {
//                // 2�ܰ�
//                if (GameManager.GetInstance().bossCount[1] != 0)
//                {
//                    Debug.Log("�ι�° ������ ��ȯ�մϴ�.");
//                    SummonBoss(1);
//                    GameManager.GetInstance().bossCount[1]--;
//                    GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossCount[1].ToString();
//                }
//                else
//                {
//                    // 3�ܰ�
//                    if (GameManager.GetInstance().bossCount[2] != 0)
//                    {
//                        Debug.Log("����° ������ ��ȯ�մϴ�.");
//                        SummonBoss(2);
//                        GameManager.GetInstance().bossCount[2]--;
//                        GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossCount[2].ToString();
//                    }
//                    else
//                    {
//                        // 4�ܰ�
//                        if (GameManager.GetInstance().bossCount[3] != 0)
//                        {
//                            Debug.Log("�׹�° ������ ��ȯ�մϴ�.");
//                            SummonBoss(3);
//                            GameManager.GetInstance().bossCount[3]--;
//                            GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossCount[3].ToString();
//                        }
//                        else
//                        {
//                            // 5�ܰ�
//                            if (GameManager.GetInstance().bossCount[4] != 0)
//                            {
//                                Debug.Log("5��° ������ ��ȯ�մϴ�.");
//                                SummonBoss(4);
//                                GameManager.GetInstance().bossCount[4]--;
//                                GameManager.GetInstance().bossCountText[4].text = GameManager.GetInstance().bossCount[4].ToString();
//                            }
//                            else
//                            {
//                                // ������ �ܰ���� ���Ͱ� ���ٸ� �⺻ ���͸� ��ȯ
//                                Debug.Log("���� ��ȭ�� ���� �⺻ ��� ������ ��ȯ�˴ϴ�.");
//                                SummonBoss(0);
//                                // TODO ��ȭ �Ҹ� �߰��ϱ�.
//                                GameManager.GetInstance().devilCoin -= 100;
//                                GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

//                            }
//                        }

//                    }
//                }
//            }
//        }

//        // ��ȯ�� ������ ����ش�.
//        GameManager.GetInstance().selectBossObject.sprite = null;
//        GameManager.GetInstance().selectBossNum = 0;
//        heroBossImage.sprite = null;
//    }


//    private void SummonBoss(int num)
//    {
//        monsterHpUp++;

//        Debug.Log(num + "��° �߰� ������ ��ȯ�մϴ�.");
//        GameObject boss = Instantiate(GameManager.GetInstance().monsterPrefabs[num+1], )
//        GameManager.GetInstance().monsterPrefabs[num].SetActive(true);
//        GameManager.instance.monsterList.Add(GameManager.GetInstance().monsterPrefabs[num]);

//        Monster monsterScript = GameManager.GetInstance().monsterPrefabs[num].GetComponent<Monster>();
//        MonsterStat monsterStat = GameManager.GetInstance().monsterPrefabs[num].GetComponent<MonsterStat>();

//        monsterStat.maxHp += monsterHpUp * monsterHpAmount; // ��ȯ �� ������ monsterHp�� ���������ش�.
//        monsterStat.curHp = monsterStat.maxHp;
        

//        GameManager.GetInstance().monsterPrefabs[num].transform.position = monsterScript.wayPoints[0].position;
//        monsterScript.targetPoint = monsterScript.wayPoints[1];

//        monsterScript.monsterState = MonsterState.move;



//        // ---------------------------------------------

//        MonsterStat monStat = GameManager.GetInstance().monsterPrefabs[0].GetComponent<MonsterStat>();
//        monStat.maxHp += monsterHpUp * monsterHpAmount;



//        // Debug.Log(monsterCount +" , " + monsterCountMax);
//        GameObject monster = Instantiate(GameManager.GetInstance().monsterPrefabs[0], wayPoints[0].transform.position, Quaternion.identity);
//        // Debug.Log("���� ����");

//        GameObject hpBar = Instantiate(hpBarPrefab, GameManager.GetInstance().hpBarParent.transform);
//        //Debug.Log("Hp�� ����");

//        Monster monsterScript = monster.GetComponent<Monster>();
//        monsterScript.wayPoints.Add(wayPoints[0]);
//        monsterScript.wayPoints.Add(wayPoints[1]);
//        monsterScript.wayPoints.Add(wayPoints[2]);
//        monsterScript.wayPoints.Add(wayPoints[3]);
//        //Debug.Log("���� ��������Ʈ �߰�");

//        GameManager.instance.monsterList.Add(monster);
//        //Debug.Log("���� ����Ʈ �߰�");

//        monster.name = "monster " + monStat.maxHp + "(" + monsterCount + ")";
//        monster.transform.parent = monsterParent.transform;
//        //Debug.Log("���� �̸�����, �θ� ����");

//        hpBar.name = monster.name + "hp Bar";

//        //Debug.Log("Set Hp Bar"+monsterScript.mStat);
//        monsterScript.SetHpBar(hpBar);
//        //Debug.Log("hp�� ����");

//        //Debug.Log(delayMonster);

//        yield return new WaitForSeconds(delayMonster);
//        //Debug.Log("���� ��Ÿ��");
//        monsterCount++;
//    }


//    /*
//     private void OnGUI()
//    {
//        if(GUI.Button(new Rect(10,120, 100,100), "�Ϲ� 100%"))
//        {
//            BossFirstDraw();
//        }
//        if (GUI.Button(new Rect(10, 230, 100, 100), "��� 60%"))
//        {
//            BossSecondDraw();
//        }
//        if (GUI.Button(new Rect(10, 340, 100, 100), "���� 20%"))
//        {
//            BossThirdDraw();
//        }
//        if (GUI.Button(new Rect(10, 450, 100, 100), "���� 5%"))
//        {
//            BossForthDraw();
//        }
//        if (GUI.Button(new Rect(10, 560, 100, 100), "��ȭ 1%"))
//        {
//            BossFifhDraw();
//        }
//    }
//    */
//}
