using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilDraw : MonoBehaviour
{

    public int bossOneCount;
    public int bossTwoCount;
    public int bossThreeCount;
    public int bossFourCount;
    public int bossFiveCount;

    private void OnGUI()
    {
        if(GUI.Button(new Rect(10,120, 100,100), "일반 100%"))
        {
            BossFirstDraw();
        }
        if (GUI.Button(new Rect(10, 230, 100, 100), "희귀 60%"))
        {
            BossSecondDraw();
        }
        if (GUI.Button(new Rect(10, 340, 100, 100), "영웅 20%"))
        {
            BossThirdDraw();
        }
        if (GUI.Button(new Rect(10, 450, 100, 100), "전설 5%"))
        {
            BossForthDraw();
        }
        if (GUI.Button(new Rect(10, 560, 100, 100), "신화 1%"))
        {
            BossFivethDraw();
        }
    }


    private void BossFirstDraw()
    {
        bossOneCount++;
        Debug.Log("일반 몬스터를 소환했습니다. 일반 몬스터 수 : " + bossOneCount);
    }

    private void BossSecondDraw()
    {
        int bossNum = Random.RandomRange(0, 100);

        if( 0<= bossNum && bossNum<60)
        {
            bossTwoCount++;
            Debug.Log("희귀 몬스터를 소환했습니다. 희귀 몬스터 수 : " + bossTwoCount);
        }
        else
        {
            Debug.Log("희귀 몬스터 뽑기에 실패했습니다.");
        }
    }

    private void BossThirdDraw()
    {
        int bossNum = Random.RandomRange(0, 100);

        if (0 <= bossNum && bossNum < 20)
        {
            bossThreeCount++;
            Debug.Log("영웅 몬스터를 소환했습니다. 영웅 몬스터 수 : " + bossThreeCount);
        }
        else
        {
            Debug.Log("영웅 몬스터 뽑기에 실패했습니다.");
        }
    }

    private void BossForthDraw()
    {
        int bossNum = Random.RandomRange(0, 100);

        if (0 <= bossNum && bossNum < 5)
        {
            bossFourCount++;
            Debug.Log("전설 몬스터를 소환했습니다. 전설 몬스터 수 : " + bossFourCount);
        }
        else
        {
            Debug.Log("전설 몬스터 뽑기에 실패했습니다.");
        }
    }

    private void BossFivethDraw()
    {
        int bossNum = Random.RandomRange(0, 100);

        if (0 <= bossNum && bossNum < 1)
        {
            bossFiveCount++;
            Debug.Log("신화 몬스터를 소환했습니다. 신화 몬스터 수 : " + bossFiveCount);
        }
        else
        {
            Debug.Log("신화 몬스터 뽑기에 실패했습니다.");
        }
    }
}
