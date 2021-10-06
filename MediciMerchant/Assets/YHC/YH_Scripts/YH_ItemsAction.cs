using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class YH_ItemsAction : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    public Image img;

    [Header("Location")]
    public bool inBag;
    public bool inStore;

    float releaseTime;
    bool dragging;

    // 터치 시작 
    public void OnPointerDown(PointerEventData eventData)
    {
        img = GetComponent<Image>();
        YH_Manager.instance.invenManager.selectedItem = transform;

        // 아이템이 가방에 있을 경우에만 터치 시 코루틴 시작.
        if (inBag)
            StartCoroutine("ReleaseTime");
    }

    // 터치 종료
    public void OnPointerUp(PointerEventData eventData)
    {
        if (inBag)
        {
            StopCoroutine("ReleaseTime");
            transform.localScale = new Vector3(1, 1, 1);

            if(releaseTime >= 0.1f)
            {
                transform.SetParent(YH_Manager.instance.invenManager.curParent);
                transform.localPosition = Vector3.zero;
                img.raycastTarget = true;
                return;
            }

            if (releaseTime < 0.1f)
            {
                // 클릭 이벤트 
            }
        }
    }

    // 드래그 감지
    public void OnDrag(PointerEventData eventData)
    {
        if (inBag && dragging)
            transform.position = eventData.position;    // 드래그할 때 아이템이 커서를 따라다니게
    }

    IEnumerator ReleaseTime()
    {
        releaseTime = 0;
        dragging = false;

        while (true)
        {
            // releaseTime이 0.1초 이상이면 드래그를 시작하는 것으로 간주할 것.  
            releaseTime += Time.deltaTime;

            if(releaseTime >= 0.1f)
            {
                // 아이템 크기 크게 바꿈.
                transform.localScale = new Vector3(1.3f, 1.3f, 1);

                if (!dragging)
                {
                    dragging = true;
                    YH_Manager.instance.invenManager.curParent = transform.parent;
                    transform.SetParent(YH_Manager.instance.invenManager.parentOnDrag);

                    // 아이템 이미지 raycast 끄기.
                    img.raycastTarget = false;
                }
            }
            yield return null;
        }
    }
}
