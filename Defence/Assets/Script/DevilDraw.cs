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
            Debug.Log("��� ���͸� ��ȯ�߽��ϴ�. ��� ���� �� : " + bossOneCount);
        }
        else if(20 <= bossNum && bossNum < 40)
        {
            bossTwoCount++;
            Debug.Log("���� ���͸� ��ȯ�߽��ϴ�. ���� ���� �� : " + bossTwoCount);
        }
        else if (40 <= bossNum && bossNum < 60)
        {
            bossThreeCount++;
            Debug.Log("���� ���͸� ��ȯ�߽��ϴ�. ���� ���� �� : " + bossThreeCount);
        }
        else if (60 <= bossNum && bossNum < 80)
        {
            bossFourCount++;
            Debug.Log("��� ���͸� ��ȯ�߽��ϴ�. ��� ���� �� : "+ bossFourCount);
        }
        else if (80 <= bossNum && bossNum < 100)
        {
            bossFiveCount++;
            Debug.Log("��ȭ ���͸� ��ȯ�߽��ϴ�. ��ȭ ���� �� : "+ bossFiveCount);
        }
    }
}
