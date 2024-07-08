using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> monsterList;
    public static GameManager instance;

    private GameManager() { }


    public static GameManager GetInstance() { return instance; }

    public void Awake()
    {
        instance = this;
    }

}
