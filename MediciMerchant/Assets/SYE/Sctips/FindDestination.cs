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
                if (Physics.Raycast(ray, out hitInfo, 30, layer))
                {
                    // QR.QM.trackedManager.SetActive(false);
                    //QR.QM.CH.enabled = false;
                    //QRbtn.gameObject.SetActive(false);
                    naviYON.SetActive(true);
                }
            }
        }
    }

    public void naviOut()
    {
        //D.GetComponent<MeshRenderer>().enabled = false;
        //text.text = "µµÂø";
        D.SetActive(false);
        naviYON.SetActive(false);
        routeLine.SetActive(false);
        miniMap.SetActive(false);
        storeObj.SetActive(true);
        for (int i = 0; i < 5; i++)
        {
            storeObj.transform.GetChild(i).gameObject.SetActive(dpBtn.destinationIndex == i);
        }

        storeObj.transform.parent.GetChild(0).gameObject.SetActive(false);
        storeObj.transform.parent.GetChild(1).gameObject.SetActive(false);
        storeObj.transform.parent.GetChild(2).gameObject.SetActive(false);
        storeObj.transform.parent.GetChild(3).gameObject.SetActive(false);
        storeObj.transform.parent.GetChild(4).gameObject.SetActive(false);

        Cjj_CloudSpawnManager.instance.SPAWN = true;
    }

    public void naviDontGo()
    {
        naviYON.SetActive(false);
    }
}
