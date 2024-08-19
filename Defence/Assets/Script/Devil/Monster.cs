using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum MonsterState
{ 
    move,
    attack

}


public class Monster : MonoBehaviour
{
    public MonsterState monsterState;

    // 몬스터는 생성되면 도착지까지 계속 걸어간다.
    // 몬스터의 이동경로위치
    // 0 - 시작지점, 1- 1차 중간지점, 2- 2차 중간지점, 3 - 도착지점
    public List<Transform> wayPoints;
    public Transform targetPoint;

    public Slider hpBar;
    public TextMeshProUGUI hpBarText;

    public MonsterStat mStat;

    private Gate gateScript;
    private bool attackStart;

    private void Start()
    {
        //Debug.Log("몬스터 생성");
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

        UpdateBar();
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


    public void SetHpBar(GameObject hpBarObj)
    {
        //Debug.Log(hpBarObj.name);

        hpBar = hpBarObj.GetComponent<Slider>();
        //Debug.Log("hpBar 추가");

        
        //hpBar.maxValue = mStat.maxHp;
        //Debug.Log("maxhp 입력");
        //hpBar.value = mStat.curHp;
        //Debug.Log("curHp 입력");
        
    }

    private void UpdateBar()
    {
        if (hpBar != null&& mStat !=null)
        {
            hpBar.maxValue = mStat.maxHp;
            hpBar.value = mStat.curHp;

            Vector3 hpBarPosition = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 0.5f);
            hpBar.transform.position = hpBarPosition;

            if(hpBarText==null)
            {
                hpBarText = hpBar.GetComponentInChildren<TextMeshProUGUI>();
            }
            hpBarText.text = $"{mStat.curHp} / {mStat.maxHp}";
        }
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
            GameManager.GetInstance().devilCoin += GameManager.GetInstance().monsterCoin;

        }
        else if(targetPoint==wayPoints[2])
        {
            GameManager.GetInstance().devilCoin += GameManager.GetInstance().monsterCoin + 2;
        }
        else if(targetPoint==wayPoints[3])
        {
            GameManager.GetInstance().devilCoin += GameManager.GetInstance().monsterCoin + 3;
        }

        GameManager.GetInstance().devilCoinText.text = GameManager.GetInstance().devilCoin.ToString();


        if (mStat.monsterType == MonsterType.special)
        {
            this.hpBar.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
        else
        {
            Destroy(hpBar.gameObject);
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
