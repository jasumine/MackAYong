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
}
