using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreSync : MonoBehaviour
{
    public GameObject mainMap;
    public TMP_Dropdown dp;

    private void Update()
    {
        transform.position = mainMap.transform.position;
        transform.rotation = mainMap.transform.rotation;
        transform.localScale = mainMap.transform.localScale;
        destinaionStoreShow();
    }

    void destinaionStoreShow()
    {
        for(int i = 0; i < transform.childCount;i++)
            transform.GetChild(i).gameObject.SetActive(i == (dp.value - 1));
    }
}
