using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YH_StoreInteraction : MonoBehaviour
{
    public List<GameObject> StoreUI = new List<GameObject>();
    public GameObject itemUI;

    /// <summary> 
    /// None     -1
    /// naples    0
    /// rome      1
    /// Venice    2
    /// Milan     3
    /// Florence  4
    /// </summary>
    public int storeIndex = -1;
    void Update()
    {
        bool storeOpen = false;
        for (int i = 0; i < 5; i++)
        {
            if (StoreUI[i].gameObject.activeSelf)
            {
                storeOpen = true;
                break;
            }
        }
        //if (Input.GetButtonDown("Fire1"))

        if (Input.touchCount != 0 && !storeOpen)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hitInfo;


                if (Physics.Raycast(ray, out hitInfo, 100))
                {
                    //storeIndex = -1;
                    if (hitInfo.collider != null)
                    {
                        if (hitInfo.collider.gameObject.name == "Store_Naples")
                        {
                            itemUI.gameObject.SetActive(true);
                            StoreUI[0].gameObject.SetActive(true);
                            StoreUI[1].gameObject.SetActive(false);
                            StoreUI[2].gameObject.SetActive(false);
                            StoreUI[3].gameObject.SetActive(false);
                            StoreUI[4].gameObject.SetActive(false);
                            storeIndex = 0;
                            int rnd = Random.Range(0, 20);
                            int rnd1 = Random.Range(0, 20);
                            int rnd2 = Random.Range(0, 20);
                            YH_ShopManager.instance.stores[storeIndex].InStoreItems[0].ItemQuantity = rnd;
                            YH_ShopManager.instance.stores[storeIndex].InStoreItems[1].ItemQuantity = rnd1;
                            YH_ShopManager.instance.stores[storeIndex].InStoreItems[2].ItemQuantity = rnd2;
                        }
                        else if (hitInfo.collider.gameObject.name == "Store_Rome")
                        {
                            itemUI.gameObject.SetActive(true);
                            StoreUI[0].gameObject.SetActive(false);
                            StoreUI[1].gameObject.SetActive(true);
                            StoreUI[2].gameObject.SetActive(false);
                            StoreUI[3].gameObject.SetActive(false);
                            StoreUI[4].gameObject.SetActive(false);
                            storeIndex = 1;
                            int rnd = Random.Range(0, 20);
                            int rnd1 = Random.Range(0, 20);
                            int rnd2 = Random.Range(0, 20);
                            YH_ShopManager.instance.stores[storeIndex].InStoreItems[0].ItemQuantity = rnd;
                            YH_ShopManager.instance.stores[storeIndex].InStoreItems[1].ItemQuantity = rnd1;
                            YH_ShopManager.instance.stores[storeIndex].InStoreItems[2].ItemQuantity = rnd2;
                        }
                        else if (hitInfo.collider.gameObject.name == "Store_Venice")
                        {
                            itemUI.gameObject.SetActive(true);
                            StoreUI[0].gameObject.SetActive(false);
                            StoreUI[1].gameObject.SetActive(false);
                            StoreUI[2].gameObject.SetActive(true);
                            StoreUI[3].gameObject.SetActive(false);
                            StoreUI[4].gameObject.SetActive(false);
                            storeIndex = 2;
                            int rnd = Random.Range(0, 20);
                            int rnd1 = Random.Range(0, 20);
                            int rnd2 = Random.Range(0, 20);
                            YH_ShopManager.instance.stores[storeIndex].InStoreItems[0].ItemQuantity = rnd;
                            YH_ShopManager.instance.stores[storeIndex].InStoreItems[1].ItemQuantity = rnd1;
                            YH_ShopManager.instance.stores[storeIndex].InStoreItems[2].ItemQuantity = rnd2;
                        }
                        else if (hitInfo.collider.gameObject.name == "Store_Milan")
                        {
                            itemUI.gameObject.SetActive(true);
                            StoreUI[0].gameObject.SetActive(false);
                            StoreUI[1].gameObject.SetActive(false);
                            StoreUI[2].gameObject.SetActive(false);
                            StoreUI[3].gameObject.SetActive(true);
                            StoreUI[4].gameObject.SetActive(false);
                            storeIndex = 3;
                            int rnd = Random.Range(0, 20);
                            int rnd1 = Random.Range(0, 20);
                            int rnd2 = Random.Range(0, 20);
                            YH_ShopManager.instance.stores[storeIndex].InStoreItems[0].ItemQuantity = rnd;
                            YH_ShopManager.instance.stores[storeIndex].InStoreItems[1].ItemQuantity = rnd1;
                            YH_ShopManager.instance.stores[storeIndex].InStoreItems[2].ItemQuantity = rnd2;
                        }
                        else if (hitInfo.collider.gameObject.name == "Store_Florence")
                        {
                            itemUI.gameObject.SetActive(true);
                            StoreUI[0].gameObject.SetActive(false);
                            StoreUI[1].gameObject.SetActive(false);
                            StoreUI[2].gameObject.SetActive(false);
                            StoreUI[3].gameObject.SetActive(false);
                            StoreUI[4].gameObject.SetActive(true);
                            storeIndex = 4;
                            int rnd = Random.Range(0, 20);
                            int rnd1 = Random.Range(0, 20);
                            int rnd2 = Random.Range(0, 20);
                            YH_ShopManager.instance.stores[storeIndex].InStoreItems[0].ItemQuantity = rnd;
                            YH_ShopManager.instance.stores[storeIndex].InStoreItems[1].ItemQuantity = rnd1;
                            YH_ShopManager.instance.stores[storeIndex].InStoreItems[2].ItemQuantity = rnd2;
                        }

                    }
                }
            }
        }
    }
}
