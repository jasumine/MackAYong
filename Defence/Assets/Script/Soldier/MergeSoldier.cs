using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSoldier : MonoBehaviour
{
    private Vector3 offset;
   public bool isDragging = false;


    SoldierStat m_stat;

    private void Start()
    {
        m_stat = GetComponent<SoldierStat>();
    }

    void Update()
    {
        // 마우스를 누른 순간~ 드래그 중이라면 움직일 수 있다.
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            if (IsTouchingObject(mousePosition))
            {
                offset = transform.position - mousePosition;
                isDragging = true;
            }
        }

        // 마우스를 떼면 드래그 중이 아니게 된다.
        if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }



    private bool IsTouchingObject(Vector3 mousePosition)
    {
        // 마우스 위치를 월드 좌표로 변환
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0;

        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
        return hit.collider != null && hit.collider.gameObject == gameObject;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == this.gameObject.tag)
        {
            SoldierStat otherStat = collision.GetComponent<SoldierStat>();

            if(otherStat.level == this.m_stat.level)
            {
                MergeObject();

            }
        }
    }


    private void MergeObject()
    {
        Debug.Log("용병을 합칩니다.");
    }

}
