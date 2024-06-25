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
        if(GUI.Button(new Rect(10,120, 100,100), "Draw"))
        {
            BossDraw();

        }
    }


    private void BossDraw()
    {
        int bossNum = Random.RandomRange(0, 100);


        if( 0<= bossNum && bossNum<20)
        {
            bossOneCount++;
            Debug.Log("희귀 몬스터를 소환했습니다. 희귀 몬스터 수 : " + bossOneCount);
        }
        else if(20 <= bossNum && bossNum < 40)
        {
            bossTwoCount++;
            Debug.Log("영웅 몬스터를 소환했습니다. 영웅 몬스터 수 : " + bossTwoCount);
        }
        else if (40 <= bossNum && bossNum < 60)
        {
            bossThreeCount++;
            Debug.Log("전설 몬스터를 소환했습니다. 전설 몬스터 수 : " + bossThreeCount);
        }
        else if (60 <= bossNum && bossNum < 80)
        {
            bossFourCount++;
            Debug.Log("고대 몬스터를 소환했습니다. 고대 몬스터 수 : "+ bossFourCount);
        }
        else if (80 <= bossNum && bossNum < 100)
        {
            bossFiveCount++;
            Debug.Log("신화 몬스터를 소환했습니다. 신화 몬스터 수 : "+ bossFiveCount);
        }
    }
}
