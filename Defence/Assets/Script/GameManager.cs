using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MonsterController monsterController;
    public float monsterLifeTime;


    public List<GameObject> usingMonsterList;


    public static GameManager instance;

    private GameManager() { }


    public static GameManager GetInstance() { return instance; }

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        monsterController = GetComponent<MonsterController>();
        StartCoroutine("CreateMonster");
    }

    private void Update()
    {
        unActiveMonster();
    }

    IEnumerator CreateMonster()
    {
        while (true)
        {
            //monsterController.CreateMonster();

            yield return new WaitForSeconds(monsterLifeTime);
        }
    }

    private void unActiveMonster()
    {
        for(int i = 0; i<usingMonsterList.Count; i++)
        {
            if (usingMonsterList[i].activeInHierarchy == false)
            {
                usingMonsterList.RemoveAt(i);
            }
        }

    }
}
