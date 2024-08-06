using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbility : MonoBehaviour
{
    public GameObject specialPannel;

    public void SpecialAbilityController()
    {
        Debug.Log("특수 능력 뽑기를 진행합니다.");
        specialPannel.SetActive(true);
    }
}
