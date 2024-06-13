using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // ���ʹ� �����Ǹ� ���������� ��� �ɾ��.
    // ������ �̵������ġ
    // 0 - ��������, 1- 1�� �߰�����, 2- 2�� �߰�����, 3 - ��������
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
        // �״� ����Ʈ
        Debug.Log("���Ͱ� �׾����ϴ�.");

        // collider�� �Ѽ� ������ �÷��̾ �ִٸ�, ���ظ� ������.
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

            Debug.Log("���Ͱ� ���谡 ������ ���ظ� �����ϴ�.");
        }
    }
}
