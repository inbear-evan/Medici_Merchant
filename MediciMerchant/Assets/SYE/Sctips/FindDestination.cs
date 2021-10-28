using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class FindDestination : MonoBehaviour
{
    public GameObject D;
    //ARRaycastManager arManager;
    public GameObject naviYON;
    //   public GameObject m;
    //GameObject CurrentTouch;
    //Touch touch;
    public Button QRbtn;
    //public TMP_Text text;
    public GameObject routeLine;
    public GameObject storeObj;
    public GameObject miniMap;
    public DestinationBtn dpBtn;

    // Start is called before the first frame update
    void Start()
    {
        //   arManager = GetComponent<ARRaycastManager>();
        naviYON.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.touchCount>0)
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    Physics.Raycast(ray, out hit);

        //    if (hit.collider.CompareTag("DESTINATION"))
        //    {
        //        qm.trackedManager.SetActive(false);
        //        qm.CH.enabled = false;
        //        QRbtn.gameObject.SetActive(false);
        //        //CurrentTouch = hit.transform.gameObject;
        //        // EventActivate();
        //    }
        //}
        if (Input.touchCount != 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                int layer = 1 << LayerMask.NameToLayer("DESTINATION");
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo, 10, layer))
                {
                    // QR.QM.trackedManager.SetActive(false);
                    //QR.QM.CH.enabled = false;
                    //QRbtn.gameObject.SetActive(false);
                    naviYON.SetActive(true);
                }
            }
        }
    }

    bool findExitChk = false;
    public void PathFindExit()
    {
        if (D.activeSelf)
        {
            naviYON.SetActive(true);
            findExitChk = true;
        }
    }

    public void naviOut()
    {
        //D.GetComponent<MeshRenderer>().enabled = false;
        //text.text = "����";
        if (D.activeSelf)  D.SetActive(false);
        if (naviYON.activeSelf) naviYON.SetActive(false);
        if (routeLine.activeSelf) routeLine.SetActive(false);
        if (miniMap.activeSelf) miniMap.SetActive(false);
        if(!storeObj.activeSelf) storeObj.SetActive(true);

       

        storeObj.transform.parent.GetChild(0).gameObject.SetActive(false);
        storeObj.transform.parent.GetChild(1).gameObject.SetActive(false);
        storeObj.transform.parent.GetChild(2).gameObject.SetActive(false);
        storeObj.transform.parent.GetChild(3).gameObject.SetActive(false);
        storeObj.transform.parent.GetChild(4).gameObject.SetActive(false);

        Cjj_CloudSpawnManager.instance.SPAWN = true;
        if (findExitChk)
        {
            naviYON.transform.parent.GetChild(6).gameObject.SetActive(false);
            findExitChk = false;
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                storeObj.transform.GetChild(i).gameObject.SetActive(dpBtn.destinationIndex == i);
            }
        }
    }

    public void naviDontGo()
    {
        naviYON.SetActive(false);
    }
}
