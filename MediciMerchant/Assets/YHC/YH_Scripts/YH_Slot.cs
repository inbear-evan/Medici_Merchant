using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �� ������ ���� ����(UI)�� ������, ����, ���� ǥ��

public class YH_Slot : MonoBehaviour
{
    // public int storeIndex;
    public Image itemImg;
    public Text itemPrice;
    public Text itemQnt;

    int storesIndex;
    int itemsIndex;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            //print(YH_ShopManager.instance.stores[i].StoreName);
            //print(transform.name);
            if (YH_ShopManager.instance.stores[i].StoreName == transform.parent.name)
            {
                storesIndex = i;
                break;
            }
        }
        if (transform.name == "SlotBtn") itemsIndex = 0;
        else if (transform.name == "SlotBtn (1)") itemsIndex = 1;
        else if (transform.name == "SlotBtn (2)") itemsIndex = 2;
    }

    public void InitSlot()
    {
        // ������, ����, ���� ������ YH_ShopManager���� �ҷ��ͼ� ǥ���ϰ� ����. 
        //Debug.Log(YH_ShopManager.instance.stores[0].InStoreItems[0].icon.name);
        itemImg.sprite = YH_ShopManager.instance.stores[storesIndex].InStoreItems[itemsIndex].icon;
        itemPrice.text = YH_ShopManager.instance.stores[storesIndex].InStoreItems[itemsIndex].ItemPrice.ToString();
        itemQnt.text = YH_ShopManager.instance.stores[storesIndex].InStoreItems[itemsIndex].ItemQuantity.ToString();
    }

    void QuantityRandom()
    {
        int rnd = Random.Range(0, 20);
        YH_ShopManager.instance.stores[storesIndex].InStoreItems[itemsIndex].ItemQuantity = rnd;
    }

    private void LateUpdate()
    {
        if (transform.parent.parent.gameObject.activeSelf)
        {
            InitSlot();
        }
    }

}
