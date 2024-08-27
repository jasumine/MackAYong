using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    // csv파일을 읽어서 AbilityData를 반환하는 함수
    // static으로 선언할 경우 AbilityData를 1번만 호출하는 단일작업이여서 인스턴스화 하지 않아 메모리 사용이 줄어든다.
    public static List<AbilityData> LoadCSV(string filename)
    {

        List<AbilityData> abilityDataList = new List<AbilityData>();
        string filePath = Path.Combine(Application.streamingAssetsPath, filename);
        
        if(File.Exists(filePath))
        {

            string[] lines = File.ReadAllLines(filePath);

            // 첫 줄은 헤더이기 때문에 2번째 줄 부터 읽는다.
            for(int i= 1;i<lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');

                //스킬을 구분한 다음
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

            Debug.Log("CSV 파일이 성공적으로 로드 되었습니다. " + abilityDataList.Count);

        }
        else
        {
            Debug.LogError("CSV 파일을 찾을 수 없습니다.");
        }

        return abilityDataList;
    }

}
