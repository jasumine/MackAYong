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
        // ��ų���� ��޺��� �������ش�.

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
        Debug.Log("��ų �з��� �Ϸ�Ǿ����ϴ�.");
    }
}
