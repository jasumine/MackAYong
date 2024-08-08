using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBullet : MonoBehaviour
{
    private GameObject target;
    public float bulletSpeed;
    public float damage;

    public float lifeTime;

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;

        // 1�ʰ� �����Ŀ��� ��������� �Ѵ�.
        if (lifeTime > 2)
        {
            Destroy(this.gameObject);
        }

        transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, bulletSpeed);

    
    }

    public void SetTarget(GameObject targetObject)
    {
        target = targetObject;
    }


    public void SetDamage(float damageNum)
    {
        // TODO : ���������� �ֱ�

        damage = damageNum;
    }



    //private void OverlapCollision()
    //{
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 1);
    //   for (int i = 0; i < colliders.Length; i++)
    //    {
    //        if (colliders[i].gameObject == target)
    //        {
    //            MonsterStat monsterStat = colliders[i].GetComponent<MonsterStat>();
    //            monsterStat.SetHp(damage);

    //            Debug.Log(this.gameObject.name + " hp : " + monsterStat.curHp);

    //            Destroy(this.gameObject);
    //        }
    //    }
    //}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        // ���Ϳ��� ���ظ� ������
        if (collision.gameObject.tag == "Monster")
        {
            if(collision.gameObject==target.gameObject)
            {
                MonsterStat monsterStat = collision.GetComponent<MonsterStat>();
                monsterStat.SetHp(damage);

               // Debug.Log(collision.gameObject.name + " hp : " + monsterStat.curHp);

                Destroy(this.gameObject);
            }
        }
        
    }
}
