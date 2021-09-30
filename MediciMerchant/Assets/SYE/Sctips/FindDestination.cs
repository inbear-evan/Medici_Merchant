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
    ARRaycastManager arManager;
    public GameObject naviYON;
    //   public GameObject m;
    GameObject CurrentTouch;
    Touch touch;
    public Button QRbtn;
    public TMP_Text text;
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

    //void DetectCenter()
    //{
    //    List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();
    //    Vector2 screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

    //    if (arManager.Raycast(screenSize, hitInfos, TrackableType.Planes))
    //    {

    //    }


    //}

    public void naviOut()
    {
        //D.GetComponent<MeshRenderer>().enabled = false;
        text.text = "����";
        D.SetActive(false);
        naviYON.SetActive(false);
    }

    public void naviDontGo()
    {
        naviYON.SetActive(false);
    }
}