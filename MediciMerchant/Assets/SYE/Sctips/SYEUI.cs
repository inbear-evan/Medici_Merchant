using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SYEUI : MonoBehaviour
{
    public static SYEUI UM;
    public bool isNaviOn = true;
    public Toggle minimapStatus;
    public GameObject panel;
    public GameObject minimap;
    public GameObject itemWindow;
    private void Awake()
    {
        UM= this;
    }
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void NaviOn()
    {
         isNaviOn = true;
    }
    public void Mnmap()
    {
        bool status = minimapStatus.isOn;
        minimap.SetActive(status);
        //minimap.SetActive(minimapStatus.isOn);

        //if (status) Debug.Log("Mnmap On");
        //else Debug.Log("Mnmap Off");
    }

    public void MenuOpen()
    {
        panel.SetActive(panel.activeSelf != true);
        Time.timeScale = 0;
    }

    public void MenuClose()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReStart()
    {
        
    }
    public void ItemOpen()
    {
        itemWindow.SetActive(itemWindow.activeSelf != true);

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
