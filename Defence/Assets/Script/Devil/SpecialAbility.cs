using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbility : MonoBehaviour
{
    public GameObject specialPannel;

    public void SpecialAbilityController()
    {
        Debug.Log("Ư�� �ɷ� �̱⸦ �����մϴ�.");
        specialPannel.SetActive(true);
    }
}
