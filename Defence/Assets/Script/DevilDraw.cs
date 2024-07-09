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

    // �߰� ���� ��ȯ
    public void SummonSetBoss()
    {
        // TODO ���õ� ���Ͱ� �ִٸ�, �ش� ���͸� ��ȯ�Ѵ�.

        // ���ٸ� ���� ���Ϳ��� ��ȯ�Ѵ�.
        // 1�ܰ�
        if(bossOneCount !=0)
        {
            SummonBoss(0);
            bossOneCount--;
        }
        else
        {
            // 2�ܰ�
            if(bossTwoCount !=0)
            {
                SummonBoss(1);
                bossTwoCount--;
            }
            else
            {
                // 3�ܰ�
                if(bossThreeCount !=0)
                {
                    SummonBoss(2);
                    bossThreeCount--;
                }
                else
                {
                    // 4�ܰ�
                    if(bossFourCount!=0)
                    {
                        SummonBoss(3);
                        bossFourCount--;
                    }
                    else
                    {
                        // 5�ܰ�
                        if(bossFiveCount != 0)
                        {
                            SummonBoss(4);
                            bossFiveCount--;
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
            BossFivethDraw();
        }
    }


    private void BossFirstDraw()
    {
        bossOneCount++;
        Debug.Log("�Ϲ� ���͸� ��ȯ�߽��ϴ�. �Ϲ� ���� �� : " + bossOneCount);
    }

    private void BossSecondDraw()
    {
        int bossNum = Random.RandomRange(0, 100);

        if( 0<= bossNum && bossNum<60)
        {
            bossTwoCount++;
            Debug.Log("��� ���͸� ��ȯ�߽��ϴ�. ��� ���� �� : " + bossTwoCount);
        }
        else
        {
            Debug.Log("��� ���� �̱⿡ �����߽��ϴ�.");
        }
    }

    private void BossThirdDraw()
    {
        int bossNum = Random.RandomRange(0, 100);

        if (0 <= bossNum && bossNum < 20)
        {
            bossThreeCount++;
            Debug.Log("���� ���͸� ��ȯ�߽��ϴ�. ���� ���� �� : " + bossThreeCount);
        }
        else
        {
            Debug.Log("���� ���� �̱⿡ �����߽��ϴ�.");
        }
    }

    private void BossForthDraw()
    {
        int bossNum = Random.RandomRange(0, 100);

        if (0 <= bossNum && bossNum < 5)
        {
            bossFourCount++;
            Debug.Log("���� ���͸� ��ȯ�߽��ϴ�. ���� ���� �� : " + bossFourCount);
        }
        else
        {
            Debug.Log("���� ���� �̱⿡ �����߽��ϴ�.");
        }
    }

    private void BossFivethDraw()
    {
        int bossNum = Random.RandomRange(0, 100);

        if (0 <= bossNum && bossNum < 1)
        {
            bossFiveCount++;
            Debug.Log("��ȭ ���͸� ��ȯ�߽��ϴ�. ��ȭ ���� �� : " + bossFiveCount);
        }
        else
        {
            Debug.Log("��ȭ ���� �̱⿡ �����߽��ϴ�.");
        }
    }
}
