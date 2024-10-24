using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject hpBarParent;

    public GameObject heroUI;
    public GameObject heroCamera;
    public GameObject devilUI;
    public GameObject devilCamera;

    public int heroCoin;
    public int devilCoin;
    public TextMeshProUGUI heroCoinText;
    public TextMeshProUGUI devilCoinText;

    public int monsterCoin;

    public Image selectBossObject;
    public int selectBossNum = 0;

    public List<int> bossCount;
    public List<TextMeshProUGUI> bossCountText;

    public List<GameObject> monsterList;
    public List<GameObject> monsterPrefabs;

    public List<GameObject> slotList;
    public List<GameObject> soliderPrefabList;

    public List<GameObject> firstSoliderList;
    public List<GameObject> secondSoliderList;
    public List<GameObject> thirdSoliderList;
    public List<GameObject> forthSoliderList;
    public List<GameObject> fifthSoliderList;


    public AbilityDataManager abilityDataManager;
    public SpecialAbility specialAbility;

    private GameManager() { }


    public static GameManager GetInstance() { return instance; }

    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

        abilityDataManager = GetComponent<AbilityDataManager>();
        specialAbility = GetComponent<SpecialAbility>();

        heroCoin = 100;
        heroCoinText.text = heroCoin.ToString();
        devilCoin = 500;
        devilCoinText.text = devilCoin.ToString();

        MonsterStat monsterStat = monsterPrefabs[0].GetComponent<MonsterStat>();
        monsterStat.maxHp = 10;

        for(int i = 0; i<5; i++)
        {
            bossCount.Add(0);
        }
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


    public void HeroActiveTure()
    {
        // ���� ui�� ī�޶� ����,
        devilUI.SetActive(false);
        devilCamera.SetActive(false);

        // ���谡 ui�� ī�޶� Ų��.
        heroUI.SetActive(true);
        heroCamera.SetActive(true);
    }

    public void DevilActiveTrue()
    {
        // ���谡 ui�� ī�޶� ����,
        heroUI.SetActive(false);
        heroCamera.SetActive(false);

        // ���� ui�� ī�޶� Ų��.
        devilUI.SetActive(true);
        devilCamera.SetActive(true);
    }
}
