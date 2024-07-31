using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSoldier : MonoBehaviour
{
    private Vector3 offset;
    public bool isDragging = false;
    private GameObject selectedObject;
    private Vector3 selectedTransform;
    private SoldierStat selectedObjectStat;

    private bool isCanMerge;

    void Update()
    {
        // ���콺�� ���� ����~ �巡�� ���̶�� 
        if(Input.GetMouseButtonDown(0))
        {
            // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            // Raycast�� ����� Ŭ���� ��ġ�� ������Ʈ�� �����ϰ�, �ش� ������Ʈ�� �����Ѵ�.
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                selectedObject = hit.collider.gameObject;
                selectedTransform = selectedObject.transform.position;

                selectedObjectStat = selectedObject.GetComponent<SoldierStat>();
                isDragging = true;
                selectedObjectStat.isDragging = true;
            }

        }

        // ���콺�� ���� �巡�� ���� �ƴϰ� �ǰ�, 
        if(Input.GetMouseButtonUp(0))
        {
            //������Ʈ�� ���ڸ��� ���ư���.
            if (isDragging && selectedObject != null)
            {
                selectedObject.transform.position = selectedTransform;
            }

            isDragging = false;
            selectedObjectStat.isDragging = false;
            selectedObject = null;
        }

        if (isDragging && selectedObject != null)
        {
            // ���콺�� object�� ����ٴѴ�.
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            selectedObject.transform.position = mousePosition;

           
        }
    }

}
