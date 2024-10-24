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
        // �ɷ¼��� ȭ���� ���� �ǰ� �ִٸ�, Ÿ�̸Ӹ� �۵��Ѵ�.
        if (isActive==true)
        {
            timeAttack -= Time.deltaTime;

            if(timeAttack < 0 )
            {
                // �����ð��� ������ �������� ���ϵ��� active(false)�� �߰��Ѵ�.
                // �ڵ����� 1���� �����ϰԵȴ�.
                isActive = false;
                abilityList[0].isActive = true;
                specialPannel.SetActive(false);
            }
        }

    }




    public void SpecialAbilityController()
    {
        Debug.Log("Ư�� �ɷ� �̱⸦ �����մϴ�.");
        SelectAbility();
        specialPannel.SetActive(true);
        isActive = true;
        timeAttack = 30f;
    }

    public void SpecialAbilityQuit()
    {
        Debug.Log("Ư�� �ɷ� �̱⸦ ������ �մϴ�.");
        timeAttack = 0;
    }
    
    void SelectAbility()
    {
        for(int i = 0; i<3;i++)
        {
            // ���õ� �ɷ��� list�� �߰����ش�.
            AbilityData abilty = SelectAbilityData();
            //Debug.Log("�ɷ�ġ 1���� ���õǾ����ϴ�.");
            abilityList.Add(abilty);
            


            // ���õǾ���  ability �̹����� ����ش�.
            ChangeAbilityImage(abilty, i);
            //Debug.Log("�ɷ¿� ���߾� �̹����� �ٲߴϴ�.");
        }
    }


    AbilityData SelectAbilityData()
    {
        float randomNum = Random.Range(0, 100);

        // A��� 3% / B��� 7% / C��� 30% / D��� 60%

        // ��ų�Ŵ����� �����ؼ� grade�� �´�  list�� �����´�.
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

        // Ȱ��ȭ ���� ���� skill�� return���ش�.
        while (true)
        {
            int index = Random.Range(0, abilityList.Count);

            if (abilityList[index].isActive == false)
                return abilityList[index];
        }
    }

    void ChangeAbilityImage(AbilityData _ability, int _num)
    {
        // A ���� / B ��� / C �Ķ� / D ȸ��
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
