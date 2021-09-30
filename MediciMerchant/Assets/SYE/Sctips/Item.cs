using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject item;

    // Start is called before the first frame update


    public void ItemOpen()
    {
        item.SetActive(item.activeSelf != true);
        
        //if (item.active)
        //{
        //    item.SetActive(false);
        //}
        //else
        //{
        //    item.SetActive(true);
        //}
    }
}
