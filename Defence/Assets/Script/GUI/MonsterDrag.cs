using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MonsterDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image heroBossImage;

    public GameObject dragObject;
    private int dragbossNum;
    //public GameObject dropObject;

    // ============ merge ============
    // �̹����� ���� ��ġ�� �ְ�, 
    // �巡�׸� ������(Ŭ��) ��� �ش� �̹����� ���콺�� ����ٴѴ�.
    // �巡���߿��� �ƹ��͵� Ŭ������ �ʴ� �����̸�
    // �巡�װ� ������(���) ���� �� �ִ� ���� 1�� ���̴�.
    // ��Ȯ�� ��ġ�� ����� ��� �� ��ġ���ִ� object�� image�� �巡������ image�� ��������.


    // dragImage���� �̸��� �ٿ��־�, �ش� image�� ������ �ִ��� ������ �Ǵ�(gameManaget.bossCount)
    // 0���� ũ�ٸ� ������ �� �ְ�, ���ٸ� �巡�� �Ұ���

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("�巡�׸� �����մϴ�.");


        // �ɷ»̱Ⱑ ������� �ʾҴٸ� �巡�װ� �����ϴ�.
        if (GameManager.GetInstance().specialAbility.isActive == false)
        {
            GameObject eventObject = eventData.pointerCurrentRaycast.gameObject;

            switch (eventObject.gameObject.tag)
            {
                case "FirstBoss":
                    if (GameManager.GetInstance().bossCount[0] > 0)
                    {
                        //Debug.Log("�߰����� �̹����� �����մϴ�.");
                        dragObject.SetActive(true);

                        Image dragImage = dragObject.GetComponent<Image>();
                        Image eventImage = eventObject.GetComponent<Image>();

                        // drag �̹����� event �̹����� �־��ش�.
                        dragImage.sprite = eventImage.sprite;
                        dragbossNum = 1;
                    }

                    break;

                case "SecondBoss":
                    if (GameManager.GetInstance().bossCount[1] > 0)
                    {
                        //Debug.Log("�߰����� �̹����� �����մϴ�.");
                        dragObject.SetActive(true);

                        Image dragImage = dragObject.GetComponent<Image>();
                        Image eventImage = eventObject.GetComponent<Image>();

                        // drag �̹����� event �̹����� �־��ش�.
                        dragImage.sprite = eventImage.sprite;
                        dragbossNum = 2;
                    }
                    break;

                case "ThirdBoss":
                    if (GameManager.GetInstance().bossCount[2] > 0)
                    {
                        //Debug.Log("�߰����� �̹����� �����մϴ�.");
                        dragObject.SetActive(true);

                        Image dragImage = dragObject.GetComponent<Image>();
                        Image eventImage = eventObject.GetComponent<Image>();

                        // drag �̹����� event �̹����� �־��ش�.
                        dragImage.sprite = eventImage.sprite;
                        dragbossNum = 3;
                    }
                    break;

                case "FourthBoss":
                    if (GameManager.GetInstance().bossCount[3] > 0)
                    {
                        //Debug.Log("�߰����� �̹����� �����մϴ�.");
                        dragObject.SetActive(true);

                        Image dragImage = dragObject.GetComponent<Image>();
                        Image eventImage = eventObject.GetComponent<Image>();

                        // drag �̹����� event �̹����� �־��ش�.
                        dragImage.sprite = eventImage.sprite;
                        dragbossNum = 4;
                    }
                    break;

                case "FifthBoss":
                    if (GameManager.GetInstance().bossCount[4] > 0)
                    {
                        //Debug.Log("�߰����� �̹����� �����մϴ�.");
                        dragObject.SetActive(true);

                        Image dragImage = dragObject.GetComponent<Image>();
                        Image eventImage = eventObject.GetComponent<Image>();

                        // drag �̹����� event �̹����� �־��ش�.
                        dragImage.sprite = eventImage.sprite;
                        dragbossNum = 5;
                    }
                    break;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("������ �̵��մϴ�.");
        dragObject.transform.position = Input.mousePosition;
    }

    // �巡�� ��
    public void OnEndDrag(PointerEventData eventData)
    {
        dragObject.SetActive(false); // �巡�� ������Ʈ�� ����ϴ�.
        
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach(RaycastResult result in results)
        {
            if(result.gameObject.tag=="DropImage")
            {
                Debug.Log("�˸��� ��ġ�� �����Ͽ� �̹����� �����մϴ�.");

                Image dragImage = dragObject.gameObject.GetComponent<Image>();
                Image dropImage = result.gameObject.GetComponent<Image>();

                // selectBossNum�� 0���� ũ�ٸ� switch����, 0�̶�� �ش� if���� �ǳʶٰ� �ȴ�.
                // ������ ���� ��ȯ ���̱⶧����, ��ü�� ������ �����̴�.
                // ��ü�ϱ� �� ���� ������ ������ ���� �����ش�.
                if (GameManager.GetInstance().selectBossNum>0)
                {
                    switch(GameManager.GetInstance().selectBossNum)
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
                }

                // drag ���� ������ ������ ���� �����ش�.
                switch(dragbossNum)
                {
                    case 1:
                        GameManager.GetInstance().bossCount[0]--;
                        GameManager.GetInstance().bossCountText[0].text = GameManager.GetInstance().bossCount[0].ToString();
                        break;

                    case 2:
                        GameManager.GetInstance().bossCount[1]--;
                        GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossCount[1].ToString();

                        break;

                    case 3:
                        GameManager.GetInstance().bossCount[2]--;
                        GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossCount[2].ToString();

                        break;

                    case 4:
                        GameManager.GetInstance().bossCount[3]--;
                        GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossCount[3].ToString();

                        break;

                    case 5:
                        GameManager.GetInstance().bossCount[4]--;
                        GameManager.GetInstance().bossCountText[4].text = GameManager.GetInstance().bossCount[4].ToString();

                        break;
                }

                // ���� ������ �̹����� �־��ְ�, selectBossNum dragNum���� �ٲپ��ش�.
                dropImage.sprite = dragImage.sprite;
                heroBossImage.sprite = dragImage.sprite;
                GameManager.GetInstance().selectBossNum = dragbossNum;

            }
        }

    }

 

}
