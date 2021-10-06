using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class YH_ItemsDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        YH_InvenManager inven = YH_Manager.instance.invenManager;

        // 드랍한 곳에 이미 오브젝트가 있는 경
        if(transform.childCount != 0)
        {
            Transform item = transform.GetChild(0);
            item.SetParent(inven.curParent);
            item.localPosition = Vector3.zero;
        }
        inven.selectedItem.SetParent(transform);
        inven.selectedItem.localPosition = Vector3.zero;
    }
}
