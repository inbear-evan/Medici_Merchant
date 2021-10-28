using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class YH_TradeManager : MonoBehaviour
{
    // 상점일때
    // 가방일때

    /// <summary> 
    /// 0  1  2  3  4  5
    /// A  B  X  Y  L  R
    /// 35,36,37,38,39,40
    /// naples    0
    /// rome      1
    /// Venice    2
    /// Milan     3
    /// Florence  4
    /// </summary>

    public GameObject bagItem;
    public GameObject storeUI;
    int storesIndex;
    int itemsIndex;
    int itemNum;

    private void Update()
    {
        YH_InvenManager.instance.goldAmount.text = YH_InvenManager.instance.gold.ToString();
        SaveManager.instance.gold = YH_InvenManager.instance.gold;
        SaveManager.instance.item[itemNum] = (int.Parse(bagItem.transform.GetChild(itemNum).GetChild(0).GetComponent<Text>().text));
    }
    public void tradeStoreNBag()
    {
        //Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        //Debug.Log(EventSystem.current.currentSelectedGameObject.transform.parent.name);

        for (int i = 0; i < 5; i++)
        {
            //print(YH_ShopManager.instance.stores[i].StoreName);
            //print(transform.name);
            if (YH_ShopManager.instance.stores[i].StoreName == EventSystem.current.currentSelectedGameObject.transform.parent.name)
            {
                storesIndex = i;
                break;
            }
        }
        if (EventSystem.current.currentSelectedGameObject.name == "SlotBtn") itemsIndex = 0;
        else if (EventSystem.current.currentSelectedGameObject.name == "SlotBtn (1)") itemsIndex = 1;
        else if (EventSystem.current.currentSelectedGameObject.name == "SlotBtn (2)") itemsIndex = 2;

        if (EventSystem.current.currentSelectedGameObject.CompareTag("STORESLOT"))
        {
            switch (YH_ShopManager.instance.stores[storesIndex].InStoreItems[itemsIndex].icon.name)
            {
                case "Fish":
                    itemNum = 0;
                    break;
                case "Cloth":
                    itemNum = 1;
                    break;
                case "Fruit":
                    itemNum = 2;
                    break;
                case "Sword":
                    itemNum = 3;
                    break;
                case "Sheild":
                    itemNum = 4;
                    break;
                case "Rice":
                    itemNum = 5;
                    break;
            }

            if (YH_ShopManager.instance.stores[storesIndex].InStoreItems[itemsIndex].ItemQuantity > 0 && ((YH_InvenManager.instance.gold - (int)YH_ShopManager.instance.stores[storesIndex].InStoreItems[itemsIndex].ItemPrice) > 0))
            {
                YH_ShopManager.instance.stores[storesIndex].InStoreItems[itemsIndex].ItemQuantity--;

                bagItem.transform.GetChild(itemNum).GetChild(0).GetComponent<Text>().text =
                    (int.Parse(bagItem.transform.GetChild(itemNum).GetChild(0).GetComponent<Text>().text) + 1).ToString();
                //gold.gameObject.transform.parent.parent.GetChild(3).GetChild(itemNum).GetChild(0).GetComponent<Text>().text = (int.Parse(gold.gameObject.transform.parent.parent.GetChild(3).GetChild(itemNum).GetChild(0).GetComponent<Text>().text) + 1).ToString();

                YH_InvenManager.instance.gold -= (int)YH_ShopManager.instance.stores[storesIndex].InStoreItems[itemsIndex].ItemPrice;
                //YH_InvenManager.instance.goldAmount.text = YH_InvenManager.instance.gold.ToString();
            }
        }
        else if (EventSystem.current.currentSelectedGameObject.CompareTag("BAGSLOT"))
        {
            switch (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name)
            {
                case "Fish":
                    itemNum = 0;
                    break;
                case "Cloth":
                    itemNum = 1;
                    break;
                case "Fruit":
                    itemNum = 2;
                    break;
                case "Sword":
                    itemNum = 3;
                    break;
                case "Sheild":
                    itemNum = 4;
                    break;
                case "Rice":
                    itemNum = 5;
                    break;
            }

            // 열린가게 체크
            int storeidx = transform.parent.GetComponent<YH_StoreInteraction>().storeIndex;
            // 가게의 내용물 체크
            if (storeidx != -1)
            {
                int itemIndex = -1;
                for (int i = 0; i < 3; i++)
                {
                    if (storeUI.transform.GetChild(storeidx).GetChild(1).GetChild(i).GetChild(0).GetComponent<Image>().sprite.name == EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite.name)
                    {
                        itemIndex = i;
                        break;
                    }
                }
                //print(storeUI.transform.GetChild(storeidx).GetChild(2).GetChild(i).GetChild(0).GetComponent<Image>().sprite.name);

                // 가게의 내용물과 가방의 내용물 확인
                if (int.Parse(bagItem.transform.GetChild(itemNum).GetChild(0).GetComponent<Text>().text) > 0)
                {
                    bagItem.transform.GetChild(itemNum).GetChild(0).GetComponent<Text>().text =
                        (int.Parse(bagItem.transform.GetChild(itemNum).GetChild(0).GetComponent<Text>().text) - 1).ToString();
                    //갯수 저장
                    

                    if (itemIndex != -1)
                    {
                        YH_InvenManager.instance.gold += (int)(YH_ShopManager.instance.stores[storesIndex].InStoreItems[itemsIndex].ItemPrice / 2);
                        //YH_InvenManager.instance.goldAmount.text = YH_InvenManager.instance.gold.ToString();
                    }
                    else
                    {
                        YH_InvenManager.instance.gold += (int)(YH_ShopManager.instance.stores[storesIndex].InStoreItems[itemsIndex].ItemPrice * 2);
                        //YH_InvenManager.instance.goldAmount.text = YH_InvenManager.instance.gold.ToString();
                    }
                }

            }
        }
    }
}