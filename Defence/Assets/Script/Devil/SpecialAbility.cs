using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAbility : MonoBehaviour
{
    public GameObject specialPannel;

    public bool isActive;
    public float timeAttack;

    public List<Image> abilityImage;
    public List<TextMeshProUGUI> abilityName;
    public List<TextMeshProUGUI> abilityDiscription;

    public List<AbilityData> abilityList = new List<AbilityData>();

    private void Update()
    {
        // 능력선택 화면이 실행 되고 있다면, 타이머를 작동한다.
        if (isActive==true)
        {
            timeAttack -= Time.deltaTime;

            if(timeAttack < 0 )
            {
                // 일정시간이 지나면 선택하지 못하도록 active(false)를 추가한다.
                // 자동으로 1번을 선택하게된다.
                isActive = false;
                abilityList[0].isActive = true;
                specialPannel.SetActive(false);
            }
        }

    }




    public void SpecialAbilityController()
    {
        Debug.Log("특수 능력 뽑기를 진행합니다.");
        SelectAbility();
        specialPannel.SetActive(true);
        isActive = true;
        timeAttack = 30f;
    }

    public void SpecialAbilityQuit()
    {
        Debug.Log("특수 능력 뽑기를 마무리 합니다.");
        timeAttack = 0;
    }
    
    void SelectAbility()
    {
        for(int i = 0; i<3;i++)
        {
            // 선택된 능력을 list에 추가해준다.
            AbilityData abilty = SelectAbilityData();
            //Debug.Log("능력치 1개가 선택되었습니다.");
            abilityList.Add(abilty);
            


            // 선택되어진  ability 이미지를 띄워준다.
            ChangeAbilityImage(abilty, i);
            //Debug.Log("능력에 맞추어 이미지를 바꿉니다.");
        }
    }


    AbilityData SelectAbilityData()
    {
        float randomNum = Random.Range(0, 100);

        // A등급 3% / B등급 7% / C등급 30% / D등급 60%

        // 스킬매니저에 접근해서 grade에 맞는  list를 가져온다.
        List<AbilityData> abilityList = new List<AbilityData>();

        if (randomNum < 60)
        {
            abilityList = GameManager.GetInstance().abilityDataManager.gradeD;
        }
        else if (randomNum <90)
        {
            abilityList = GameManager.GetInstance().abilityDataManager.gradeC;
        }
        else if(randomNum < 97)
        {
            abilityList = GameManager.GetInstance().abilityDataManager.gradeB;
        }
        else
        {
            abilityList = GameManager.GetInstance().abilityDataManager.gradeA;
        }

        // 활성화 되지 않은 skill을 return해준다.
        while (true)
        {
            int index = Random.Range(0, abilityList.Count);

            if (abilityList[index].isActive == false)
                return abilityList[index];
        }
    }

    void ChangeAbilityImage(AbilityData _ability, int _num)
    {
        // A 빨강 / B 노랑 / C 파랑 / D 회색
        switch(_ability.Grade)
        {
            case "A":
                abilityImage[_num].color = Color.red;
                break;
            case "B":
                abilityImage[_num].color = Color.yellow;
                break;
            case "C":
                abilityImage[_num].color = Color.blue;
                break;
            case "D":
                abilityImage[_num].color = Color.gray;
                break;
        }

        abilityName[_num].text = _ability.name;
        abilityDiscription[_num].text = _ability.Discription;
    }

}
