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
        if(GUI.Button(new Rect(10,120, 100,100), "�Ϲ� 100%"))
        {
            BossFirstDraw();
        }
        if (GUI.Button(new Rect(10, 230, 100, 100), "��� 60%"))
        {
            BossSecondDraw();
        }
        if (GUI.Button(new Rect(10, 340, 100, 100), "���� 20%"))
        {
            BossThirdDraw();
        }
        if (GUI.Button(new Rect(10, 450, 100, 100), "���� 5%"))
        {
            BossForthDraw();
        }
        if (GUI.Button(new Rect(10, 560, 100, 100), "��ȭ 1%"))
        {
            BossFivethDraw();
        }
    }


    private void BossFirstDraw()
    {
        bossOneCount++;
        Debug.Log("�Ϲ� ���͸� ��ȯ�߽��ϴ�. �Ϲ� ���� �� : " + bossOneCount);
    }

    private void BossSecondDraw()
    {
        int bossNum = Random.RandomRange(0, 100);

        if( 0<= bossNum && bossNum<60)
        {
            bossTwoCount++;
            Debug.Log("��� ���͸� ��ȯ�߽��ϴ�. ��� ���� �� : " + bossTwoCount);
        }
        else
        {
            Debug.Log("��� ���� �̱⿡ �����߽��ϴ�.");
        }
    }

    private void BossThirdDraw()
    {
        int bossNum = Random.RandomRange(0, 100);

        if (0 <= bossNum && bossNum < 20)
        {
            bossThreeCount++;
            Debug.Log("���� ���͸� ��ȯ�߽��ϴ�. ���� ���� �� : " + bossThreeCount);
        }
        else
        {
            Debug.Log("���� ���� �̱⿡ �����߽��ϴ�.");
        }
    }

    private void BossForthDraw()
    {
        int bossNum = Random.RandomRange(0, 100);

        if (0 <= bossNum && bossNum < 5)
        {
            bossFourCount++;
            Debug.Log("���� ���͸� ��ȯ�߽��ϴ�. ���� ���� �� : " + bossFourCount);
        }
        else
        {
            Debug.Log("���� ���� �̱⿡ �����߽��ϴ�.");
        }
    }

    private void BossFivethDraw()
    {
        int bossNum = Random.RandomRange(0, 100);

        if (0 <= bossNum && bossNum < 1)
        {
            bossFiveCount++;
            Debug.Log("��ȭ ���͸� ��ȯ�߽��ϴ�. ��ȭ ���� �� : " + bossFiveCount);
        }
        else
        {
            Debug.Log("��ȭ ���� �̱⿡ �����߽��ϴ�.");
        }
    }
}
