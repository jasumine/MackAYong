using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevilDraw : MonoBehaviour
{

    public List<GameObject> bossMonsterPrefab;
    public Image selectBossObject;


    // �߰� ���� ��ȯ
    public void SummonSetBoss()
    {
        // TODO ���õ� ���Ͱ� �ִٸ�, �ش� ���͸� ��ȯ�Ѵ�.
        Debug.Log("���� ��ȯ�� �����մϴ�.");
        if(selectBossObject.sprite !=null)
        {
            for(int i =0; i<bossMonsterPrefab.Count; i++)
            {
                SpriteRenderer sprite = bossMonsterPrefab[i].GetComponent<SpriteRenderer>();

                if (sprite.sprite == selectBossObject.sprite)
                {
                    SummonBoss(i);
                }
            }
        }
        // ���ٸ� ���� ���Ϳ��� ��ȯ�Ѵ�.
        else
        {
            // 1�ܰ�
            if (GameManager.GetInstance().bossOneCount != 0)
            {
                Debug.Log("ù��° ������ ��ȯ�մϴ�.");
                SummonBoss(0);
                GameManager.GetInstance().bossOneCount--;
            }
            else
            {
                // 2�ܰ�
                if (GameManager.GetInstance().bossTwoCount != 0)
                {
                    Debug.Log("�ι�° ������ ��ȯ�մϴ�.");
                    SummonBoss(1);
                    GameManager.GetInstance().bossTwoCount--;
                }
                else
                {
                    // 3�ܰ�
                    if (GameManager.GetInstance().bossThreeCount != 0)
                    {
                        Debug.Log("����° ������ ��ȯ�մϴ�.");
                        SummonBoss(2);
                        GameManager.GetInstance().bossThreeCount--;
                    }
                    else
                    {
                        // 4�ܰ�
                        if (GameManager.GetInstance().bossFourCount != 0)
                        {
                            Debug.Log("�׹�° ������ ��ȯ�մϴ�.");
                            SummonBoss(3);
                            GameManager.GetInstance().bossFourCount--;
                        }
                        else
                        {
                            // 5�ܰ�
                            if (GameManager.GetInstance().bossFiveCount != 0)
                            {
                                Debug.Log("5��° ������ ��ȯ�մϴ�.");
                                SummonBoss(4);
                                GameManager.GetInstance().bossFiveCount--;
                            }
                            else
                            {
                                // ������ �ܰ���� ���Ͱ� ���ٸ� �⺻ ���͸� ��ȯ
                                Debug.Log("���� ��ȭ�� ���� �⺻ ��� ������ ��ȯ�˴ϴ�.");
                                SummonBoss(0);
                                // TODO ��ȭ �Ҹ� �߰��ϱ�.

                            }
                        }

                    }
                }
            }
        }

        // ��ȯ�� ������ ����ش�.
        selectBossObject.sprite = null;
    }


    private void SummonBoss(int num)
    {
        Debug.Log(num + "��° �߰� ������ ��ȯ�մϴ�.");
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
        if(GUI.Button(new Rect(10,120, 100,100), "�Ϲ� 100%"))
        {
            BossFirstDraw();
        }
        if (GUI.Button(new Rect(10, 230, 100, 100), "��� 60%"))
        {
            BossSecondDraw();
        }
        if (GUI.Button(new Rect(10, 340, 100, 100), "���� 20%"))
        {
            BossThirdDraw();
        }
        if (GUI.Button(new Rect(10, 450, 100, 100), "���� 5%"))
        {
            BossForthDraw();
        }
        if (GUI.Button(new Rect(10, 560, 100, 100), "��ȭ 1%"))
        {
            BossFifhDraw();
        }
    }
    */
}
