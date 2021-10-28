using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject QRIndicator;
    // 가방 활성화 

    private void Start()
    {
        int readGold = PlayerPrefs.GetInt("Gold", -1);
        //Debug.Log(readGold);
        if (readGold >= 0)
        {
            gold = readGold;
            //Debug.Log(gold);
            goldAmount.text = gold.ToString();
        }
        else goldAmount.text = gold.ToString();

        bagFrame.transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("item1").ToString();
        bagFrame.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("item2").ToString();
        bagFrame.transform.GetChild(3).GetChild(2).GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("item3").ToString();
        bagFrame.transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("item4").ToString();
        bagFrame.transform.GetChild(3).GetChild(4).GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("item5").ToString();
        bagFrame.transform.GetChild(3).GetChild(5).GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("item6").ToString();
    }
    public void OpenBag()
    {
        if (!QRIndicator.activeSelf)
        {
            goldAmount.text = gold.ToString();     // 갖고 있는 골드를 텍스트로 표현
            bagFrame.SetActive(true);
        }
    }

    // 가방 비활성화
    public void CloseBag()
    {
        bagFrame.SetActive(false);
    }
}
