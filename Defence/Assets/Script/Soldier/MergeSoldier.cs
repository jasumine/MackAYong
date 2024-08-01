using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSoldier : MonoBehaviour
{
    private Vector3 offset;
    public bool isDragging = false;
    public GameObject selectedObject;
    private Vector3 selectedTransform;
    private SoldierStat selectedObjectStat;

    private bool isCanMerge;

    void Update()
    {
        // 마우스를 누른 순간~ 드래그 중이라면 
        if(Input.GetMouseButtonDown(0))
        {
            // 마우스 위치를 월드 좌표로 변환
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            // Raycast를 사용해 클릭한 위치의 오브젝트를 감지하고, 해당 오브젝트를 선택한다.
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
            {
                // object가 용병인 경우에만 선택된다.
                if(hit.collider.gameObject.tag =="Soldier")
                {
                    selectedObject = hit.collider.gameObject;
                    selectedTransform = selectedObject.transform.position;

                    selectedObjectStat = selectedObject.GetComponent<SoldierStat>();
                    isDragging = true;
                    selectedObjectStat.isDragging = true; // 드래그중
                    selectedObjectStat.isMerge = false; // 합성 불가능
                }
            }

        }

        // 마우스를 떼면 드래그 중이 아니게 되고, 합성이 가능하다. 
        if(Input.GetMouseButtonUp(0))
        {
            // 합성가능한 상태일때 drop을 하는 경우, 합쳐진다.
            if(selectedObjectStat.isMerge == true)
            {
                selectedObject = null;
                selectedObjectStat.canMerge = true;
            }

            // 합쳐지지 않았다면, 오브젝트가 제자리로 돌아간다.
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
            // 마우스를 object가 따라다닌다.
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            selectedObject.transform.position = mousePosition;

           
        }
    }

}
