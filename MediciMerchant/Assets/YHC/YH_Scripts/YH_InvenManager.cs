using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YH_InvenManager : MonoBehaviour
{
    public static YH_InvenManager instance;
    private void Awake()
    {
        instance = this;
    }
    [Header("Frame")]
    public GameObject bagFrame;
    public GameObject storeFrame;

    [Header("Bag")]
    public int gold;
    public TextMeshProUGUI goldAmount;

    [Header("Drag&Drop")]
    public Transform selectedItem;
    public Transform curParent;     // 아이템이 있던 슬롯 게임오브젝트
    public Transform parentOnDrag;

    // 가방 활성화 
    public void OpenBag()
    {
        goldAmount.text = gold.ToString();     // 갖고 있는 골드를 텍스트로 표현
        bagFrame.SetActive(true);
    }

    // 가방 비활성화
    public void CloseBag()
    {
        bagFrame.SetActive(false);
    }
}
