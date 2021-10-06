using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum ItemType
{
    YH_Item1,
    YH_Item2,
    YH_Item3,
    YH_Item4,
    YH_Item5,
    YH_Item6
}

[System.Serializable]
public class Item
{
    public string ItemName;
    public float ItemPrice;
    public int ItemQuantity;
    public Sprite icon;
}

[System.Serializable]
public class Store
{
    public string StoreName;
    public int StoreIndex;
    public List<Item> InStoreItems = new List<Item>();
}


public class YH_ShopManager : MonoBehaviour
{
    public static YH_ShopManager instance;
    public List<Store> stores = new List<Store>();

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {

    }
    
    public void shopClose()
    {
        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
    }
}
