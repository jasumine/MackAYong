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

    // ���ʹ� �����Ǹ� ���������� ��� �ɾ��.
    // ������ �̵������ġ
    // 0 - ��������, 1- 1�� �߰�����, 2- 2�� �߰�����, 3 - ��������
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

            //Debug.Log(gateScript.gameObject.name + "�� ���ظ� �������ϴ�. gate Hp : " + gateScript.curHp);

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
        // ���� �� ó��
        Debug.Log("���Ͱ� �׾����ϴ�.");

        GameManager.GetInstance().heroCoin++;
        GameManager.GetInstance().heroCoinText.text = GameManager.GetInstance().heroCoin.ToString();

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
        // ���� ����������
        if (collision.gameObject.tag == "Gate")
        {
            monsterState = MonsterState.attack;
            gateScript = collision.GetComponent<Gate>();
            attackStart = false;
        }
    }

}