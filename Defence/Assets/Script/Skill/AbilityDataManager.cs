using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDataManager : MonoBehaviour
{
    public List<AbilityData> abilityDataList = new List<AbilityData>();

    public List<AbilityData> gradeA = new List<AbilityData>();
    public List<AbilityData> gradeB = new List<AbilityData>();
    public List<AbilityData> gradeC = new List<AbilityData>();
    public List<AbilityData> gradeD = new List<AbilityData>();


    private void Start()
    {
        abilityDataList = CSVReader.LoadCSV("SpecialAbilityList.csv");
        //Debug.Log("skillDataManager Start");
        CategorizeSkill();
    }

    void CategorizeSkill()
    {
        // 스킬들을 등급별로 구분해준다.

        for (int i = 0; i < abilityDataList.Count; i++)
        {
            switch (abilityDataList[i].Grade)
            {
                case "A":
                    gradeA.Add(abilityDataList[i]);
                    break;

                case "B":
                    gradeB.Add(abilityDataList[i]);
                    break;

                case "C":
                    gradeC.Add(abilityDataList[i]);
                    break;

                case "D":
                    gradeD.Add(abilityDataList[i]);
                    break;
            }
        }
        Debug.Log("스킬 분류가 완료되었습니다.");
    }


    // type에 따라서 스킬 만들기, special은 id로 구분

    void InitializeAbilites()
    {
        // for문을 이용해 id 1개씩 능력의 효과를 설정해 준다.
        foreach(var ability in abilityDataList)
        {
            switch(ability.Type)
            {
                case "Attack":
                    ability.ExecuteAbility = TypeAttackEffect;
                    break;
                case "Buff":
                    break;
                case "DeBuff":
                    break;
                case "Gold":
                    break;
                case "Draw":
                    break;
                case "Special":

                    break;


                // ============마왕 특수 능력============
                case "Witch":
                    switch(ability.ID)
                    {
                        case 1:
                            break;
                    }
                    break;
                case "Knight":
                    break;
                case "Necromancer":
                    break;
                case "Dragon":
                    break;
            }
        }
    }


    private void TypeAttackEffect(AbilityEffect a)
    {

    }

    private void TypeBuffEffect()
    {

    }

    private void TypeDebuffEffect()
    {

    }

    private void TypeGoldEffect()
    {

    }

    private void TypeDrawEffect()
    {

    }




}
