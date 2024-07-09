using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // ���� ������ ����ϴ� Ŭ����
    public List<GameObject> monsterPrefabs;

    public List<Transform> wayPoints;

    public GameObject monsterParent;
    public float delayMonster;
    public float monsterCount;


    public void CreateController()
    {
        monsterCount = 0;
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
        while(monsterCount !=20)
        {
            GameObject monster = Instantiate(monsterPrefabs[0], wayPoints[0].transform.position, Quaternion.identity);

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


    private void OnGUI()
    {
        if (GUI.Button(new Rect(120, 10, 100, 100), "hp ����"))
        {
            IncreaseHp();
        }

        if (GUI.Button(new Rect(120, 120, 100, 100), "�̵��ӵ� ����"))
        {
            IncreaseSpeed();
        }

        if (GUI.Button(new Rect(120, 230, 100, 100), "���ݼӵ� ����"))
        {
            IncreaseAttackSpeed();
        }

        if (GUI.Button(new Rect(120, 340, 100, 100), "���ȹ�� ����"))
        {
            IncreaseAttackSpeed();
        }

        if (GUI.Button(new Rect(120, 450, 100, 100), "Ȯ�� ����"))
        {
            IncreasePercent();
        }
    }

    private void IncreaseHp()
    {
        for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
        {
            MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

            mStat.maxHp++;
        }
        Debug.Log("hp�� �����մϴ�.");
    }

    private void IncreaseSpeed()
    {
        for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
        {
            MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

            mStat.speed++;
        }
        Debug.Log("�ӵ��� �����մϴ�.");
    }


    private void IncreaseAttackSpeed()
    {
        for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
        {
            MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

            mStat.attackSpeed++;
        }
        Debug.Log("���ݼӵ��� �����մϴ�.");
    }

    private void IncreaseGold()
    {
        for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
        {
            MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

            mStat.speed++;
        }
        Debug.Log("��ȭ ȹ�淮�� �����մϴ�.");
    }

    private void IncreasePercent()
    {
        for (int i = 0; i < GameManager.instance.monsterList.Count; i++)
        {
            MonsterStat mStat = GameManager.instance.monsterList[i].GetComponent<MonsterStat>();

            mStat.speed++;
        }
        Debug.Log("�̱� ȹ����� �����մϴ�.");
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
