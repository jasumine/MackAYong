using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MonsterMerge : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public Image heroBossImage;

    public Color highligtColor = Color.blue;
    public Color defaultcolor = Color.white;


    private float doubleClickedTime = 0.3f;
    private float lastTime = -1f;

    private Coroutine highlightCoroutine;
    private GameObject lastClickObject;

    private GameObject clickAbility;
    

    // �̱� Ŭ���� ��� ���̶���Ʈ ǥ��
    // ���� Ŭ���� ��� object tag�� ���� �ٸ��� ó���Ѵ�.
    // tag�� bossImage�� ��� �ش� ������ count�� 5�̻� �̶��, ���� �ܰ� ����count++;
    // tag�� dropImage�� ��� image = null; bossNum�� �ش��ϴ� ����Count++; bossNum=0;


    public void OnPointerClick(PointerEventData eventData)
    {
        // Ư���ɷ� �̱Ⱑ ���� �� �̶�� �ٸ� Ŭ���� ���� �ʵ��� �Ѵ�.
        if(GameManager.GetInstance().specialAbility.isActive == true)
        {
            // ��ġ�� ���۵� �� �ɷ��� Ŭ���ߴ��� Ȯ���Ѵ�.

            // ��ġ�� ���� �� ���۵� �̹����� ���ٸ� �ɷ��� �����ϰ� �� ���̴�.
        }
        else
        {
            float currentTime = Time.time;
            GameObject eventObject = eventData.pointerCurrentRaycast.gameObject;

            // ���� Ŭ���ð� - ������ Ŭ���ð� �� ����Ŭ��(0.3)���� ������ ����Ŭ���̴�.
            // ���� ������Ʈ���� Ȯ��
            if (eventObject == lastClickObject && currentTime - lastTime < doubleClickedTime)
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
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Ư�� �ɷ� �̱Ⱑ ���� �� �϶� ����ǵ��� �Ѵ�.
        if (GameManager.GetInstance().specialAbility.isActive == true)
        {
            GameObject eventObject = eventData.pointerCurrentRaycast.gameObject;

            // ��ġ�� ���۵� �� �ɷ��� �����Ѵ�.
            if (eventObject.tag == "AbilityImage")
            {
                clickAbility = eventObject;
                Debug.Log("�ɷ»̱� �̺�Ʈ Ŭ���� ����");
            }
        }
    }




    public void OnPointerUp(PointerEventData eventData)
    {
        // Ư�� �ɷ� �̱Ⱑ ���� �� �϶� ����ǵ��� �Ѵ�.
        if (GameManager.GetInstance().specialAbility.isActive == true)
        {
            GameObject eventObject = eventData.pointerCurrentRaycast.gameObject;

            // ��ġ�� ���� �� ���۵� �̹����� ���ٸ� �ɷ��� �����ϰ� �� ���̴�.

            if (clickAbility == eventObject)
            {
                // TODO
                // clickAbility�� �ɷ��� �����Ѵ�.
                Debug.Log("�ɷ»̱� �̺�Ʈ Ŭ���� ��");
                GameManager.GetInstance().specialAbility.SpecialAbilityQuit();
            }
        }
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
                            GameManager.GetInstance().bossCount[0]++;
                            GameManager.GetInstance().bossCountText[0].text = GameManager.GetInstance().bossCount[0].ToString();
                            break;

                        case 2:
                            GameManager.GetInstance().bossCount[1]++;
                            GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossCount[1].ToString();
                            break;

                        case 3:
                            GameManager.GetInstance().bossCount[2]++;
                            GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossCount[2].ToString();

                            break;

                        case 4:
                            GameManager.GetInstance().bossCount[3]++;
                            GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossCount[3].ToString();

                            break;

                        case 5:
                            GameManager.GetInstance().bossCount[4]++;
                            GameManager.GetInstance().bossCountText[4].text = GameManager.GetInstance().bossCount[4].ToString();

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
                if(GameManager.GetInstance().bossCount[0] >= 5)
                {
                    GameManager.GetInstance().bossCount[0] -= 5;
                    GameManager.GetInstance().bossCountText[0].text = GameManager.GetInstance().bossCount[0].ToString();
                    GameManager.GetInstance().bossCount[1]++;
                    GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossCount[1].ToString();
                }
                break;
            case "SecondBoss":
                if (GameManager.GetInstance().bossCount[1] >= 5)
                {
                    GameManager.GetInstance().bossCount[1] -= 5;
                    GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossCount[1].ToString();
                    GameManager.GetInstance().bossCount[2]++;
                    GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossCount[2].ToString();
                }
                break;
            case "ThirdBoss":
                if (GameManager.GetInstance().bossCount[2] >= 5)
                {
                    GameManager.GetInstance().bossCount[2] -= 5;
                    GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossCount[2].ToString();
                    GameManager.GetInstance().bossCount[3]++;
                    GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossCount[3].ToString();
                }
                break;
            case "FourthBoss":
                if (GameManager.GetInstance().bossCount[3] >= 5)
                {
                    GameManager.GetInstance().bossCount[3] -= 5;
                    GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossCount[3].ToString();
                    GameManager.GetInstance().bossCount[4]++;
                    GameManager.GetInstance().bossCountText[4].text = GameManager.GetInstance().bossCount[4].ToString();
                }
                break;
        }

    }

}
