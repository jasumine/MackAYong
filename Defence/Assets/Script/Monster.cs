using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// ���ʹ� �����Ǹ� ���������� ��� �ɾ��.




public class MonsterStat
{
    public float maxHp;
    public float curHp;

    public float speed;

}


public class Monster : MonoBehaviour
{

    // ������ �̵������ġ
    // 0 - ��������, 1- 1�� �߰�����, 2- 2�� �߰�����, 3 - ��������
    public List<Transform> wayPoints;
    public Transform targetPoint;

    private MonsterStat mStat;

    private void Start()
    {
        mStat = GetComponent<MonsterStat>();
        targetPoint = wayPoints[0];
    }


    private void Update()
    {
        if (mStat.curHp <=0)
        {
            MonsterDie();
        }

        GoPoint();
        ChangePoint();
    }



    private void ChangePoint()
    {
        if (targetPoint == wayPoints[0])
        {
            targetPoint = wayPoints[1];
        }
        else if (targetPoint == wayPoints[1])
        {
            targetPoint = wayPoints[2];
        }
        else if (targetPoint == wayPoints[2])
        {
            targetPoint = wayPoints[3];
        }
    }

    private void GoPoint()
    {
        this.gameObject.transform .position = targetPoint.position * Time.deltaTime * mStat.speed;

    }


    private void MonsterDie()
    {
        // �״� ����Ʈ
        this.gameObject.SetActive(false);
    }

}
