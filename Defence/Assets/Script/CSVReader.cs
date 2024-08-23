using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SkillData
{
    public int ID;
    public string Type;
    public string Grade;
    public string Discription;
    public int value;
    public bool isActive = false;
}



public class CSVReader : MonoBehaviour
{
    public List<SkillData> skillDataList = new List<SkillData>();

    private void Start()
    {
        LoadCSV("SpecialAbilityList.csv");
    }

    void LoadCSV(string filename)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, filename);
        
        if(File.Exists(filePath))
        {

            string[] lines = File.ReadAllLines(filePath);

            // 첫 줄은 헤더이기 때문에 2번째 줄 부터 읽는다.
            for(int i= 1;i<lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');

                //스킬을 구분한 다음
                SkillData skill = new SkillData();
                skill.ID = int.Parse(fields[0]);
                skill.Type = fields[1];
                skill.Grade = fields[2];
                skill.Discription = fields[3];
                skill.value = int.Parse(fields[4]);

                skillDataList.Add(skill);
            }

            Debug.Log("CSV 파일이 성공적으로 로드 되었습니다." + skillDataList.Count +", " + skillDataList[skillDataList.Count].ID);

        }
        else
        {
            Debug.LogError("CSV 파일을 찾을 수 없습니다.");
        }

    }



}
