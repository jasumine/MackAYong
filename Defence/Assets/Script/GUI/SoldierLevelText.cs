using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoldierLevelText : MonoBehaviour
{
    public SoldierStat stat;
    public TextMeshProUGUI textMeshProUGUI;

    private void FixedUpdate()
    {
        stat = GetComponentInChildren<SoldierStat>();
        if(stat != null)
        {
            textMeshProUGUI.text = stat.level.ToString();
        }
        else
        {
            textMeshProUGUI.text = null;
        }

        if(stat.isDragging ==true)
        {
            textMeshProUGUI.text = null;
        }
    }

}
