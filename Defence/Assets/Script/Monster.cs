using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// 몬스터는 생성되면 도착지까지 계속 걸어간다.




public class MonsterStat
{
    public float maxHp;
    public float curHp;

    public float speed;

}


public class Monster : MonoBehaviour
{

    // 몬스터의 이동경로위치
    // 0 - 시작지점, 1- 1차 중간지점, 2- 2차 중간지점, 3 - 도착지점
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
        // 죽는 이펙트
        this.gameObject.SetActive(false);
    }

}
