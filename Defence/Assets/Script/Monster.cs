using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // 몬스터는 생성되면 도착지까지 계속 걸어간다.
    // 몬스터의 이동경로위치
    // 0 - 시작지점, 1- 1차 중간지점, 2- 2차 중간지점, 3 - 도착지점
    public List<Transform> wayPoints;
    public Transform targetPoint;

    private MonsterStat mStat;
    private Collider mCollider;

    private void Start()
    {
        mStat = GetComponent<MonsterStat>();
        mCollider = GetComponent<Collider>();
        targetPoint = wayPoints[1];
        this.transform.position = wayPoints[0].position;
    }


    private void Update()
    {
        if (mStat.curHp <= 0)
        {
            MonsterDie();
        }

        GoPoint();
        ChangePoint();
    }



    private void ChangePoint()
    {
        if (this.transform.position == wayPoints[1].position)
        {
            targetPoint = wayPoints[2];
        }
        else if (this.transform.position == wayPoints[2].position)
        {
            targetPoint = wayPoints[3];
        }
        else if (this.transform.position == wayPoints[3].position)
        {
            MonsterDie();
        }
    }

    private void GoPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, mStat.speed * Time.deltaTime);
    }



    private void MonsterDie()
    {
        // 죽는 이펙트
        Debug.Log("몬스터가 죽었습니다.");

        // collider를 켜서 주위에 플레이어가 있다면, 피해를 입힌다.
        mCollider.enabled = true;

        this.gameObject.SetActive(false);
        this.transform.position = wayPoints[0].position;
        targetPoint = wayPoints[1];
        mCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Adventurer"))
        {
            Adventurer adventurer = other.GetComponent<Adventurer>();

            adventurer.SetHealth();

            Debug.Log("몬스터가 모험가 진영에 피해를 입힙니다.");
        }
    }
}
