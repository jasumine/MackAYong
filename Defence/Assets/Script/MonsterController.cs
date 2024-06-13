using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // ���� ������ ����ϴ� Ŭ����

    public List<GameObject> monsterPullingObject = new List<GameObject>();

    private float delayMonster;

    public void CreateMonster()
    {
        Debug.Log("���͸� �����մϴ�.");

        for(int i = 0; i< monsterPullingObject.Count; i++)
        {
            if (monsterPullingObject[i].activeInHierarchy == false)
            {
                monsterPullingObject[i].SetActive(true);
                GameManager.instance.usingMonsterList.Add(monsterPullingObject[i]);
                return;
            }
        }

    }



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


}
