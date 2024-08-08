using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MonsterMerge : MonoBehaviour, IPointerClickHandler
{
    public Image heroBossImage;

    public Color highligtColor = Color.blue;
    public Color defaultcolor = Color.white;


    private float doubleClickedTime = 0.3f;
    private float lastTime = -1f;

    private Coroutine highlightCoroutine;
    private GameObject lastClickObject;
    

    // �̱� Ŭ���� ��� ���̶���Ʈ ǥ��
    // ���� Ŭ���� ��� object tag�� ���� �ٸ��� ó���Ѵ�.
    // tag�� bossImage�� ��� �ش� ������ count�� 5�̻� �̶��, ���� �ܰ� ����count++;
    // tag�� dropImage�� ��� image = null; bossNum�� �ش��ϴ� ����Count++; bossNum=0;


    public void OnPointerClick(PointerEventData eventData)
    {
        float currentTime = Time.time;
        GameObject eventObject = eventData.pointerCurrentRaycast.gameObject;

        // ���� Ŭ���ð� - ������ Ŭ���ð� �� ����Ŭ��(0.3)���� ������ ����Ŭ���̴�.
        // ���� ������Ʈ���� Ȯ��
        if (eventObject == lastClickObject && currentTime - lastTime < doubleClickedTime )
        {
            // ���̰� 0.3���� ���⶧���� ����Ŭ���̹Ƿ� ���⼭ ����Ŭ�� ó���� �Ѵ�.
            DoubleClick(eventObject);
        }
        else
        {
            // ���̰� 0.3���� ũ�ٸ� �̱� Ŭ���� �ǹǷ�, ���⼭ �̱�Ŭ�� ó���� �Ѵ�.
            SingleClick(eventObject);
        }

        // ������ Ŭ���ð� ������Ʈ
        lastTime = currentTime;
        lastClickObject = eventObject;
    }

    private void SingleClick(GameObject eventObject)
    {
        // �̱� Ŭ�� - ���̶���Ʈ ǥ��
        // ������ Ŭ���ص� ������Ʈ�� �ִٸ� ���̶���Ʈ ǥ�ø� ���ش�.
        //if(lastClickObject != null)
        //{
        //    Image lastImage = lastClickObject.GetComponent<Image>();

        //   lastImage.color = defaultcolor;
        //    lastClickObject = null;
        //}

        // �ٸ� �̹����� Ŭ���Ǹ� �ȵǱ⶧���� �±׷� �������ش�.
        if(eventObject.tag == "DropImage" || eventObject.tag == "FirstBoss" || eventObject.tag == "SecondBoss"
            || eventObject.tag == "ThirdBoss" || eventObject.tag == "FourthBoss")
        {
            Image eventImage = eventObject.GetComponent<Image>();
            if(eventImage.sprite != null)
            {
                eventImage.color = highligtColor;

                // ������ �ڷ�ƾ�� �������̸� �����Ѵ�.
                if (highlightCoroutine != null)
                {
                    StopCoroutine(highlightCoroutine);
                }
                // �ð��� ������ ���̶���Ʈ ǥ�ø� ���� �ڷ�ƾ ����
                highlightCoroutine = StartCoroutine(HighlightDelay(eventImage));
            }
        }
    }


    private IEnumerator HighlightDelay(Image image)
    {
        // ����Ŭ�� �ð���ŭ ������ ���̶���Ʈǥ�ø� ���ش�.
        yield return new WaitForSeconds(doubleClickedTime);
        image.color = defaultcolor;
        lastClickObject = null;
    }


    private void DoubleClick(GameObject eventObject)
    {
        // ���� Ŭ�� - tag�� ���� �ٸ��� ó��.
        // ���̶���Ʈ�� ���ش�.
        Image eventImage = eventObject.GetComponent<Image>();
        eventImage.color = defaultcolor;

        // ������ �����ص� �ڷ�ƾ�� �����Ѵ�.
        if (highlightCoroutine != null)
        {
            StopCoroutine(highlightCoroutine);
            highlightCoroutine = null; // �ڷ�ƾ ���� �� null�� ����
        }

        // �±׿� ���� �ٸ��� ó�����ش�.
        switch(eventObject.tag)
        {
            // ���� ��ȯ ����
            case "DropImage":
                if (GameManager.GetInstance().selectBossNum > 0)
                {
                    switch (GameManager.GetInstance().selectBossNum)
                    {
                        case 1:
                            GameManager.GetInstance().bossOneCount++;
                            GameManager.GetInstance().bossCountText[0].text = GameManager.GetInstance().bossOneCount.ToString();
                            break;

                        case 2:
                            GameManager.GetInstance().bossTwoCount++;
                            GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossTwoCount.ToString();
                            break;

                        case 3:
                            GameManager.GetInstance().bossThreeCount++;
                            GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossThreeCount.ToString();

                            break;

                        case 4:
                            GameManager.GetInstance().bossFourCount++;
                            GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossFourCount.ToString();

                            break;

                        case 5:
                            GameManager.GetInstance().bossFiveCount++;
                            GameManager.GetInstance().bossCountText[4].text = GameManager.GetInstance().bossFiveCount.ToString();

                            break;

                    }
                    GameManager.GetInstance().selectBossObject.sprite = null;
                    heroBossImage.sprite = null;
                    GameManager.GetInstance().selectBossNum = 0;
                }
                break;

            // ���� �ռ� - 5������ 1�ܰ� ���� 1�ܰ�� ��½����ش�. ������ �ܰ�� �ռ� �Ұ���
            // 1�ܰ� 5���� = 2�ܰ� 1����
            case "FirstBoss":
                if(GameManager.GetInstance().bossOneCount >=5)
                {
                    GameManager.GetInstance().bossOneCount -= 5;
                    GameManager.GetInstance().bossCountText[0].text = GameManager.GetInstance().bossOneCount.ToString();
                    GameManager.GetInstance().bossTwoCount++;
                    GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossTwoCount.ToString();
                }
                break;
            case "SecondBoss":
                if (GameManager.GetInstance().bossTwoCount >= 5)
                {
                    GameManager.GetInstance().bossTwoCount -= 5;
                    GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossTwoCount.ToString();
                    GameManager.GetInstance().bossThreeCount++;
                    GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossThreeCount.ToString();
                }
                break;
            case "ThirdBoss":
                if (GameManager.GetInstance().bossThreeCount >= 5)
                {
                    GameManager.GetInstance().bossThreeCount -= 5;
                    GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossThreeCount.ToString();
                    GameManager.GetInstance().bossFourCount++;
                    GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossFourCount.ToString();
                }
                break;
            case "FourthBoss":
                if (GameManager.GetInstance().bossFourCount >= 5)
                {
                    GameManager.GetInstance().bossFourCount -= 5;
                    GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossFourCount.ToString();
                    GameManager.GetInstance().bossFiveCount++;
                    GameManager.GetInstance().bossCountText[4].text = GameManager.GetInstance().bossFiveCount.ToString();
                }
                break;
        }

    }

}
