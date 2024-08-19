using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MonsterController : MonoBehaviour
{
    // ���� ������ ����ϴ� Ŭ����
    public List<Transform> wayPoints;

    public GameObject hpBarPrefab;

    public GameObject monsterParent;
    public float delayMonster;
    public float monsterCount;
    public int monsterCountMax; //����  ��ȯ �ִ� Ƚ��

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

        //�� ���帶�� 20������ ���͸� �����Ѵ�.
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
        // CreateMonster�� �� ������, hp�� �����Ѵ�.
        MonsterStat monStat= GameManager.GetInstance().monsterPrefabs[0].GetComponent<MonsterStat>();
        monStat.maxHp += monsterHpUp * monsterHpAmount;

        // ���� ��ȯ Ƚ�� ����
        while (monsterCount < monsterCountMax)
        {
            //Debug.Log(monsterCount +" , " + monsterCountMax);
            GameObject monster = Instantiate(GameManager.GetInstance().monsterPrefabs[0], wayPoints[0].transform.position, Quaternion.identity);
            //Debug.Log("���� ����");

            GameObject hpBar = Instantiate(hpBarPrefab, GameManager.GetInstance().hpBarParent.transform);
            //Debug.Log("Hp�� ����");

            Monster monsterScript = monster.GetComponent<Monster>();
            monsterScript.wayPoints.Add(wayPoints[0]);
            monsterScript.wayPoints.Add(wayPoints[1]);
            monsterScript.wayPoints.Add(wayPoints[2]);
            monsterScript.wayPoints.Add(wayPoints[3]);
            //Debug.Log("���� ��������Ʈ �߰�");

            GameManager.instance.monsterList.Add(monster);
            //Debug.Log("���� ����Ʈ �߰�");

            monster.name = "monster " + monStat.maxHp + "(" +monsterCount+")";
            monster.transform.parent = monsterParent.transform;
            //Debug.Log("���� �̸�����, �θ� ����");

            hpBar.name = monster.name + "hp Bar";

            //Debug.Log("Set Hp Bar"+monsterScript.mStat);
            monsterScript.SetHpBar(hpBar);
            //Debug.Log("hp�� ����");

            //Debug.Log(delayMonster);

            yield return new WaitForSeconds(delayMonster);
            //Debug.Log("���� ��Ÿ��");
            monsterCount++;
        }
    }



    // ======================�߰����� ��ȯ======================

    // �߰� ���� ��ȯ
    public void SummonSetBoss()
    {
        // TODO ���õ� ���Ͱ� �ִٸ�, �ش� ���͸� ��ȯ�Ѵ�.
        Debug.Log("���� ��ȯ�� �����մϴ�.");
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
        // ���ٸ� ���� ���Ϳ��� ��ȯ�Ѵ�.
        else
        {
            // 1�ܰ�
            if (GameManager.GetInstance().bossCount[0] != 0)
            {
                Debug.Log("ù��° ������ ��ȯ�մϴ�.");
                SummonBoss(0);
                GameManager.GetInstance().bossCount[0]--;
                GameManager.GetInstance().bossCountText[0].text = GameManager.GetInstance().bossCount[0].ToString();
            }
            else
            {
                // 2�ܰ�
                if (GameManager.GetInstance().bossCount[1] != 0)
                {
                    Debug.Log("�ι�° ������ ��ȯ�մϴ�.");
                    SummonBoss(1);
                    GameManager.GetInstance().bossCount[1]--;
                    GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossCount[1].ToString();
                }
                else
                {
                    // 3�ܰ�
                    if (GameManager.GetInstance().bossCount[2] != 0)
                    {
                        Debug.Log("����° ������ ��ȯ�մϴ�.");
                        SummonBoss(2);
                        GameManager.GetInstance().bossCount[2]--;
                        GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossCount[2].ToString();
                    }
                    else
                    {
                        // 4�ܰ�
                        if (GameManager.GetInstance().bossCount[3] != 0)
                        {
                            Debug.Log("�׹�° ������ ��ȯ�մϴ�.");
                            SummonBoss(3);
                            GameManager.GetInstance().bossCount[3]--;
                            GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossCount[3].ToString();
                        }
                        else
                        {
                            // 5�ܰ�
                            if (GameManager.GetInstance().bossCount[4] != 0)
                            {
                                Debug.Log("5��° ������ ��ȯ�մϴ�.");
                                SummonBoss(4);
                                GameManager.GetInstance().bossCount[4]--;
                                GameManager.GetInstance().bossCountText[4].text = GameManager.GetInstance().bossCount[4].ToString();
                            }
                            else
                            {
                                // ������ �ܰ���� ���Ͱ� ���ٸ� �⺻ ���͸� ��ȯ
                                Debug.Log("���� ��ȭ�� ���� �⺻ ��� ������ ��ȯ�˴ϴ�.");
                                SummonBoss(0);
                                // TODO ��ȭ �Ҹ� �߰��ϱ�.
                                GameManager.GetInstance().devilCoin -= 100;
                                GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();

                            }
                        }

                    }
                }
            }
        }

        // ��ȯ�� ������ ����ش�.
        GameManager.GetInstance().selectBossObject.sprite = null;
        GameManager.GetInstance().selectBossNum = 0;
        heroBossImage.sprite = null;
    }


    private void SummonBoss(int num)
    {
        bossHpUp++;

        // ���� ü�� ����
        MonsterStat monStat = GameManager.GetInstance().monsterPrefabs[num+1].GetComponent<MonsterStat>();
        monStat.maxHp += monsterHpUp * monsterHpAmount;

        Debug.Log(num+ "��° �߰� ������ ��ȯ�մϴ�.");

        // ����, hp�� ����
        GameObject boss = Instantiate(GameManager.GetInstance().monsterPrefabs[num+1], wayPoints[0].transform.position, Quaternion.identity);
        GameObject hpBar = Instantiate(hpBarPrefab, GameManager.GetInstance().hpBarParent.transform);

        // list�� �߰�
        GameManager.instance.monsterList.Add(boss);

        // waypoint �߰�
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
    // Ǯ���� �̿��� ���� ����
    public List<GameObject> monsterPullingObject = new List<GameObject>();

    public void CreateMonster()
    {
        Debug.Log("���͸� �����մϴ�.");

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


    // ���� ��ġ ���� ����
    private void CreateMonsterRandom()
    {

        Debug.Log("������ ��ġ�� ���͸� �����մϴ�.");

        delayMonster += time.deltaTime();

        if(delayMonster > 2f)
        {
            // y�� ��ġ�� �����~�߰�����1 ���� �������� �ְ�
            // x�� ��ġ�� �ణ�� ����(�����̶�� ������ ��������)
            GameObject monster = Instantiate(monsterPullingObject[0], monsterPullingObject.transform.position);

            GameManager.instance.usingMonsterList.Add(monster);
        }
    }
    */

}
