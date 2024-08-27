using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    // csv������ �о AbilityData�� ��ȯ�ϴ� �Լ�
    // static���� ������ ��� AbilityData�� 1���� ȣ���ϴ� �����۾��̿��� �ν��Ͻ�ȭ ���� �ʾ� �޸� ����� �پ���.
    public static List<AbilityData> LoadCSV(string filename)
    {

        List<AbilityData> abilityDataList = new List<AbilityData>();
        string filePath = Path.Combine(Application.streamingAssetsPath, filename);
        
        if(File.Exists(filePath))
        {

            string[] lines = File.ReadAllLines(filePath);

            // ù ���� ����̱� ������ 2��° �� ���� �д´�.
            for(int i= 1;i<lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');

                //��ų�� ������ ����
                AbilityData ability = new AbilityData();
                ability.ID = int.Parse(fields[0]);
                //Debug.Log(i + "ID");
                ability.Type = fields[1];
                //Debug.Log(i + "Tyoe");
                ability.Grade = fields[2];
                //Debug.Log(i + "Grad");
                ability.Discription = fields[3];
                //Debug.Log(i + "Discription");
                ability.value = int.Parse(fields[4]);
                //Debug.Log(i + "value");

                abilityDataList.Add(ability);
                //Debug.Log("Add skill");
            }

            Debug.Log("CSV ������ ���������� �ε� �Ǿ����ϴ�. " + abilityDataList.Count);

        }
        else
        {
            Debug.LogError("CSV ������ ã�� �� �����ϴ�.");
        }

        return abilityDataList;
    }

}
