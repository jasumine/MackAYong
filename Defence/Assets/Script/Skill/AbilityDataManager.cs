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


    // type�� ���� ��ų �����, special�� id�� ����

    void InitializeAbilites()
    {
        // for���� �̿��� id 1���� �ɷ��� ȿ���� ������ �ش�.
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


                // ============���� Ư�� �ɷ�============
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
