using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAbility : MonoBehaviour
{
    public GameObject specialPannel;

    public List<Image> abilityImage;
    public List<TextMeshProUGUI> abilityName;
    public List<TextMeshProUGUI> abilityDiscription;


    private void Update()
    {
        // �����ð��� ������ �������� ���ϵ��� active(false)�� �߰��Ѵ�.
        // �ڵ��������� �ϱ�.

        // ��ġ�� ���۵� �� �ɷ��� Ŭ���ߴ��� Ȯ���Ѵ�.
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if(hit.collider !=null)
            {

            }

        }
        

        // ��ġ�� ���� �� ���۵� �̹����� ���ٸ� �ɷ��� �����ϰ� �� ���̴�.
        if(Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

        }
    }




    public void SpecialAbilityController()
    {
        Debug.Log("Ư�� �ɷ� �̱⸦ �����մϴ�.");
        SelectAbility();
        specialPannel.SetActive(true);
    }
    
    void SelectAbility()
    {
        for(int i = 0; i<3;i++)
        {
            AbilityData abilty = SelectAbilityData();
            //Debug.Log("�ɷ�ġ 1���� ���õǾ����ϴ�.");

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

        abilityName[_num].text = _ability.Grade;
        abilityDiscription[_num].text = _ability.Discription;
    }


    // ability click event
    void ClickAbility()
    {

    }
}
