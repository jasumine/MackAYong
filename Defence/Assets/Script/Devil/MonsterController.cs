using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // ���� ������ ����ϴ� Ŭ����
    public List<Transform> wayPoints;

    public GameObject monsterParent;
    public float delayMonster;
    public float monsterCount;
    public int monsterCountMax; //����  ��ȯ �ִ� Ƚ��

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
