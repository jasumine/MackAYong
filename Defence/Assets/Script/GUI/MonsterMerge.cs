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
    

    // 싱글 클릭의 경우 하이라이트 표시
    // 더블 클릭의 경우 object tag에 따라서 다르게 처리한다.
    // tag가 bossImage인 경우 해당 보스의 count가 5이상 이라면, 다음 단계 보스count++;
    // tag가 dropImage인 경우 image = null; bossNum에 해당하는 보스Count++; bossNum=0;


    public void OnPointerClick(PointerEventData eventData)
    {
        // 특수능력 뽑기가 진행 중 이라면 다른 클릭이 되지 않도록 한다.
        if(GameManager.GetInstance().specialAbility.isActive == true)
        {
            // 터치가 시작될 때 능력을 클릭했는지 확인한다.

            // 터치가 끝날 때 시작된 이미지와 같다면 능력을 선택하게 된 것이다.
        }
        else
        {
            float currentTime = Time.time;
            GameObject eventObject = eventData.pointerCurrentRaycast.gameObject;

            // 현재 클릭시간 - 마지막 클릭시간 이 더블클릭(0.3)보다 적으면 더블클릭이다.
            // 같은 오브젝트인지 확인
            if (eventObject == lastClickObject && currentTime - lastTime < doubleClickedTime)
            {
                // 차이가 0.3보다 적기때문에 더블클릭이므로 여기서 더블클릭 처리를 한다.
                DoubleClick(eventObject);
            }
            else
            {
                // 차이가 0.3보다 크다면 싱글 클릭이 되므로, 여기서 싱글클릭 처리를 한다.
                SingleClick(eventObject);
            }

            // 마지막 클릭시간 업데이트
            lastTime = currentTime;
            lastClickObject = eventObject;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // 특수 능력 뽑기가 진행 중 일때 실행되도록 한다.
        if (GameManager.GetInstance().specialAbility.isActive == true)
        {
            GameObject eventObject = eventData.pointerCurrentRaycast.gameObject;

            // 터치가 시작될 때 능력을 저장한다.
            if (eventObject.tag == "AbilityImage")
            {
                clickAbility = eventObject;
                Debug.Log("능력뽑기 이벤트 클릭을 시작");
            }
        }
    }




    public void OnPointerUp(PointerEventData eventData)
    {
        // 특수 능력 뽑기가 진행 중 일때 실행되도록 한다.
        if (GameManager.GetInstance().specialAbility.isActive == true)
        {
            GameObject eventObject = eventData.pointerCurrentRaycast.gameObject;

            // 터치가 끝날 때 시작된 이미지와 같다면 능력을 선택하게 된 것이다.

            if (clickAbility == eventObject)
            {
                // TODO
                // clickAbility의 능력을 실행한다.
                Debug.Log("능력뽑기 이벤트 클릭을 끝");
                GameManager.GetInstance().specialAbility.SpecialAbilityQuit();
            }
        }
    }



    private void SingleClick(GameObject eventObject)
    {
        // 싱글 클릭 - 하이라이트 표시
        // 기존에 클릭해둔 오브젝트가 있다면 하이라이트 표시를 꺼준다.
        //if(lastClickObject != null)
        //{
        //    Image lastImage = lastClickObject.GetComponent<Image>();

        //   lastImage.color = defaultcolor;
        //    lastClickObject = null;
        //}

        // 다른 이미지는 클릭되면 안되기때문에 태그로 구분해준다.
        if(eventObject.tag == "DropImage" || eventObject.tag == "FirstBoss" || eventObject.tag == "SecondBoss"
            || eventObject.tag == "ThirdBoss" || eventObject.tag == "FourthBoss")
        {
            Image eventImage = eventObject.GetComponent<Image>();
            if(eventImage.sprite != null)
            {
                eventImage.color = highligtColor;

                // 기존에 코루틴이 실행중이면 정지한다.
                if (highlightCoroutine != null)
                {
                    StopCoroutine(highlightCoroutine);
                }
                // 시간이 지나면 하이라이트 표시를 끄는 코루틴 실행
                highlightCoroutine = StartCoroutine(HighlightDelay(eventImage));
            }
        }
    }


    private IEnumerator HighlightDelay(Image image)
    {
        // 더블클릭 시간만큼 지나면 하이라이트표시를 꺼준다.
        yield return new WaitForSeconds(doubleClickedTime);
        image.color = defaultcolor;
        lastClickObject = null;
    }


    private void DoubleClick(GameObject eventObject)
    {
        // 더블 클릭 - tag에 따라 다르게 처리.
        // 하이라이트를 꺼준다.
        Image eventImage = eventObject.GetComponent<Image>();
        eventImage.color = defaultcolor;

        // 기존에 실행해둔 코루틴을 중지한다.
        if (highlightCoroutine != null)
        {
            StopCoroutine(highlightCoroutine);
            highlightCoroutine = null; // 코루틴 중지 후 null로 설정
        }

        // 태그에 따라 다르게 처리해준다.
        switch(eventObject.tag)
        {
            // 보스 소환 해제
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

            // 보스 합성 - 5마리를 1단계 높은 1단계로 상승시켜준다. 마지막 단계는 합성 불가능
            // 1단계 5마리 = 2단계 1마리
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
