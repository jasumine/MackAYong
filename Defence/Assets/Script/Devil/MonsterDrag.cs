using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MonsterDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public GameObject dragObject;
    public GameObject dropObject;

    // �̹����� ���� ��ġ�� �ְ�, 
    // �巡�׸� ������(Ŭ��) ��� �ش� �̹����� ���콺�� ����ٴѴ�.
    // �巡���߿��� �ƹ��͵� Ŭ������ �ʴ� �����̸�
    // �巡�װ� ������(���) ���� �� �ִ� ���� 1�� ���̴�.
    // ��Ȯ�� ��ġ�� ����� ��� �� ��ġ���ִ� object�� image�� �巡������ image�� ��������.


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("�巡�׸� �������ϴ�.");

        GameObject eventObject = eventData.pointerCurrentRaycast.gameObject;

        if(eventObject.gameObject.tag=="BossImage")
        {
            Debug.Log("�߰����� �̹����� �����մϴ�.");
            dragObject.SetActive(true);

            Image dragImage = dragObject.GetComponent<Image>();
            Image eventImage = eventObject.GetComponent<Image>();

            // drag �̹����� event �̹����� �־��ش�.
            dragImage.sprite = eventImage.sprite;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("������ �̵��մϴ�.");
        dragObject.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("���� �̵��� �����ϴ�.");

        GameObject evenObject = eventData.pointerCurrentRaycast.gameObject;

        if(evenObject == dropObject)
        {
            Debug.Log("�̹����� �����ϴ�.");
        }



        dragObject.SetActive(false);

    }


}
