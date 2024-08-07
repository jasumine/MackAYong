using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MonsterType
{
    basic,
    special,
    boss
}



public enum MonsterState
{ 
    move,
    attack

}



public class Monster : MonoBehaviour
{
    public MonsterState monsterState;
    public MonsterType monsterType;

    // 몬스터는 생성되면 도착지까지 계속 걸어간다.
    // 몬스터의 이동경로위치
    // 0 - 시작지점, 1- 1차 중간지점, 2- 2차 중간지점, 3 - 도착지점
    public List<Transform> wayPoints;
    public Transform targetPoint;

    private MonsterStat mStat;

    private Gate gateScript;
    private bool attackStart;

    private void Start()
    {
        mStat = GetComponent<MonsterStat>();
        targetPoint = wayPoints[1];
        this.transform.position = wayPoints[0].position;
        monsterState = MonsterState.move;
    }


    private void Update()
    {
        if (mStat.curHp <= 0)
        {
            MonsterDie();
        }

        if(monsterState == MonsterState.move)
        {
            GoPoint();
            ChangePoint();
        }
        if(monsterState == MonsterState.attack && attackStart== false)
        {
            attackStart = true;
            StartCoroutine("AttackGate");
        }
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
            
        }
    }

    private void GoPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, mStat.speed * Time.deltaTime);
    }

    IEnumerator AttackGate()
    {
        while(attackStart)
        {
            gateScript.curHp--;

            //Debug.Log(gateScript.gameObject.name + "에 피해를 입혔습니다. gate Hp : " + gateScript.curHp);

            yield return new WaitForSeconds(mStat.attackSpeed);
            if (gateScript.curHp <= 0)
            {
                attackStart = false;
                gateScript = null;
                monsterState = MonsterState.move;
            }
        }
    }

    private void MonsterDie()
    {
        // 죽은 후 처리
        Debug.Log("몬스터가 죽었습니다.");

        GameManager.GetInstance().heroCoin+=3;
        GameManager.GetInstance().heroCoinText.text = GameManager.GetInstance().heroCoin.ToString();

        if(targetPoint== wayPoints[1])
        {
            GameManager.GetInstance().devilCoin++;

        }
        else if(targetPoint==wayPoints[2])
        {
            GameManager.GetInstance().devilCoin += 2;
        }
        else if(targetPoint==wayPoints[3])
        {
            GameManager.GetInstance().devilCoin += 3;
        }

        GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();


        if (monsterType == MonsterType.special || monsterType == MonsterType.boss)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            Destroy(this.gameObject);

        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 문에 피해입히기
        if (collision.gameObject.tag == "Gate")
        {
            monsterState = MonsterState.attack;
            gateScript = collision.GetComponent<Gate>();
            attackStart = false;
        }
    }

}
