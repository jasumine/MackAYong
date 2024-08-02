using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MonsterDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public GameObject dragObject;
    public GameObject dropObject;

    // 이미지는 원래 위치에 있고, 
    // 드래그를 시작할(클릭) 경우 해당 이미지가 마우스를 따라다닌다.
    // 드래그중에는 아무것도 클릭되지 않는 상태이며
    // 드래그가 끝날때(드롭) 놓을 수 있는 곳은 1곳 뿐이다.
    // 정확한 위치에 드롭할 경우 그 위치에있는 object의 image는 드래그중인 image가 씌워진다.


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("드래그를 시작힙니다.");

        GameObject eventObject = eventData.pointerCurrentRaycast.gameObject;

        if(eventObject.gameObject.tag=="BossImage")
        {
            Debug.Log("중간보스 이미지를 복사합니다.");
            dragObject.SetActive(true);

            Image dragImage = dragObject.GetComponent<Image>();
            Image eventImage = eventObject.GetComponent<Image>();

            // drag 이미지에 event 이미지를 넣어준다.
            dragImage.sprite = eventImage.sprite;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("보스를 이동합니다.");
        dragObject.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("보스 이동이 끝납니다.");

        GameObject evenObject = eventData.pointerCurrentRaycast.gameObject;

        if(evenObject == dropObject)
        {
            Debug.Log("이미지가 같습니다.");
        }



        dragObject.SetActive(false);

    }


}
