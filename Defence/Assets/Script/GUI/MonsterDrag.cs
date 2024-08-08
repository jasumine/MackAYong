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

    // 이미지는 원래 위치에 있고, 
    // 드래그를 시작할(클릭) 경우 해당 이미지가 마우스를 따라다닌다.
    // 드래그중에는 아무것도 클릭되지 않는 상태이며
    // 드래그가 끝날때(드롭) 놓을 수 있는 곳은 1곳 뿐이다.
    // 정확한 위치에 드롭할 경우 그 위치에있는 object의 image는 드래그중인 image가 씌워진다.


    // dragImage마다 이름을 붙여주어, 해당 image의 보스가 있는지 없는지 판단(gameManaget.bossCount)
    // 0보다 크다면 움직일 수 있고, 적다면 드래그 불가능

    public void OnBeginDrag(PointerEventData eventData)
    {
       // Debug.Log("드래그를 시작합니다.");

        GameObject eventObject = eventData.pointerCurrentRaycast.gameObject;

        switch(eventObject.gameObject.tag)
        {
            case "FirstBoss":
                if(GameManager.GetInstance().bossOneCount>0)
                {
                    //Debug.Log("중간보스 이미지를 복사합니다.");
                    dragObject.SetActive(true);

                    Image dragImage = dragObject.GetComponent<Image>();
                    Image eventImage = eventObject.GetComponent<Image>();

                    // drag 이미지에 event 이미지를 넣어준다.
                    dragImage.sprite = eventImage.sprite;
                    dragbossNum = 1;
                }

                break;

            case "SecondBoss":
                if (GameManager.GetInstance().bossTwoCount > 0)
                {
                    //Debug.Log("중간보스 이미지를 복사합니다.");
                    dragObject.SetActive(true);

                    Image dragImage = dragObject.GetComponent<Image>();
                    Image eventImage = eventObject.GetComponent<Image>();

                    // drag 이미지에 event 이미지를 넣어준다.
                    dragImage.sprite = eventImage.sprite;
                    dragbossNum = 2;
                }
                break;

            case "ThirdBoss":
                if (GameManager.GetInstance().bossThreeCount > 0)
                {
                    //Debug.Log("중간보스 이미지를 복사합니다.");
                    dragObject.SetActive(true);

                    Image dragImage = dragObject.GetComponent<Image>();
                    Image eventImage = eventObject.GetComponent<Image>();

                    // drag 이미지에 event 이미지를 넣어준다.
                    dragImage.sprite = eventImage.sprite;
                    dragbossNum = 3;
                }
                break;

            case "FourthBoss":
                if (GameManager.GetInstance().bossFourCount > 0)
                {
                    //Debug.Log("중간보스 이미지를 복사합니다.");
                    dragObject.SetActive(true);

                    Image dragImage = dragObject.GetComponent<Image>();
                    Image eventImage = eventObject.GetComponent<Image>();

                    // drag 이미지에 event 이미지를 넣어준다.
                    dragImage.sprite = eventImage.sprite;
                    dragbossNum = 4;
                }
                break;

            case "FifthBoss":
                if (GameManager.GetInstance().bossFiveCount > 0)
                {
                    //Debug.Log("중간보스 이미지를 복사합니다.");
                    dragObject.SetActive(true);

                    Image dragImage = dragObject.GetComponent<Image>();
                    Image eventImage = eventObject.GetComponent<Image>();

                    // drag 이미지에 event 이미지를 넣어준다.
                    dragImage.sprite = eventImage.sprite;
                    dragbossNum = 5;
                }
                break;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("보스를 이동합니다.");
        dragObject.transform.position = Input.mousePosition;
    }

    // 드래그 끝
    public void OnEndDrag(PointerEventData eventData)
    {
        dragObject.SetActive(false); // 드래그 오브젝트를 숨깁니다.
        
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach(RaycastResult result in results)
        {
            if(result.gameObject.tag=="DropImage")
            {
                Debug.Log("알맞은 위치에 도착하여 이미지를 복사합니다.");

                Image dragImage = dragObject.gameObject.GetComponent<Image>();
                Image dropImage = result.gameObject.GetComponent<Image>();

                // selectBossNum이 0보다 크다면 switch문을, 0이라면 해당 if문을 건너뛰게 된다.
                // 보스가 현재 소환 전이기때문에, 교체가 가능한 상태이다.
                // 교체하기 전 현재 보스의 개수를 증가 시켜준다.
                if (GameManager.GetInstance().selectBossNum>0)
                {
                    switch(GameManager.GetInstance().selectBossNum)
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
                }

                // drag 중인 보스의 개수를 감소 시켜준다.
                switch(dragbossNum)
                {
                    case 1:
                        GameManager.GetInstance().bossOneCount--;
                        GameManager.GetInstance().bossCountText[0].text = GameManager.GetInstance().bossOneCount.ToString();
                        break;

                    case 2:
                        GameManager.GetInstance().bossTwoCount--;
                        GameManager.GetInstance().bossCountText[1].text = GameManager.GetInstance().bossTwoCount.ToString();

                        break;

                    case 3:
                        GameManager.GetInstance().bossThreeCount--;
                        GameManager.GetInstance().bossCountText[2].text = GameManager.GetInstance().bossThreeCount.ToString();

                        break;

                    case 4:
                        GameManager.GetInstance().bossFourCount--;
                        GameManager.GetInstance().bossCountText[3].text = GameManager.GetInstance().bossFourCount.ToString();

                        break;

                    case 5:
                        GameManager.GetInstance().bossFiveCount--;
                        GameManager.GetInstance().bossCountText[4].text = GameManager.GetInstance().bossFiveCount.ToString();

                        break;
                }

                // 현재 보스의 이미지를 넣어주고, selectBossNum dragNum으로 바꾸어준다.
                dropImage.sprite = dragImage.sprite;
                heroBossImage.sprite = dragImage.sprite;
                GameManager.GetInstance().selectBossNum = dragbossNum;

            }
        }

    }

 

}
