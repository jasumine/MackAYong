using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int heroCoin;
    public int devilCoin;
    public TextMeshProUGUI heroCoinText;
    public TextMeshProUGUI devilCoinText;

    public int bossOneCount;
    public int bossTwoCount;
    public int bossThreeCount;
    public int bossFourCount;
    public int bossFiveCount;

    public List<GameObject> monsterList;
    public static GameManager instance;

    public List<GameObject> slotList;
    public List<GameObject> soliderPrefabList;

    public List<GameObject> firstSoliderList;
    public List<GameObject> secondSoliderList;
    public List<GameObject> thirdSoliderList;
    public List<GameObject> forthSoliderList;
    public List<GameObject> fifthSoliderList;


    private GameManager() { }


    public static GameManager GetInstance() { return instance; }

    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        heroCoin = 100;
        heroCoinText.text = heroCoin.ToString();
        devilCoin = 100;
        devilCoinText.text = devilCoin.ToString();
    }


    public void InputSoldierList(int num, GameObject gameObject)
    {
        switch (num)
        {
            case 0:
                firstSoliderList.Add(gameObject);
                break;
            case 1:
                secondSoliderList.Add(gameObject);
                break;
            case 2:
                thirdSoliderList.Add(gameObject);
                break;
            case 3:
                forthSoliderList.Add(gameObject);
                break;
            case 4:
                fifthSoliderList.Add(gameObject);
                break;
        }
    }

}
