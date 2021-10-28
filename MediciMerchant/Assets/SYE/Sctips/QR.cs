using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class QR : MonoBehaviour
{
    public static QR QM;
    private void Awake()
    {
        QM = this;
    }
    //public GameObject nada;
    public Image CH;
    public GameObject trackedManager;
    public GameObject itemBag;
    public GameObject[] store;
    public Slider statusSlider;

    GameObject cam;

    //public GameObject dpBtnManager;


    private void Start()
    {
        //nada.GetComponent<MeshRenderer>().enabled = false;
        //trackedManager.GetComponent<ARTrackedImageManager>().trackedImagePrefab.GetComponent<MeshRenderer>().enabled = false;
        CH.gameObject.SetActive(true);
        statusSlider.gameObject.SetActive(false);
        GetComponent<FindDestination>().storeObj.SetActive(false);
        trackedManager.GetComponent<ARTrackedImageManager>().enabled = true;
        cam = trackedManager.transform.GetChild(0).gameObject;
        //txt.text = "마커 검색";
    }

    public bool qrRecog()
    //private void Update()
    {
        bool qrRecogChk = false;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        int layer = 1 << LayerMask.NameToLayer("NADA");
       
        if (Physics.Raycast(ray, out hitInfo, 2, layer))
        {
            //if (hitInfo.transform.CompareTag("NADA"))
            {
                qrRecogChk = true;
                CH.gameObject.SetActive(false);
                statusSlider.gameObject.SetActive(true);
                //trackedManager.GetComponent<ARTrackedImageManager>().enabled = false;
                //trackedManager.GetComponent<ARTrackedImageManager>().trackedImagePrefab.GetComponent<BoxCollider>().enabled = false;
                //txt.text = "현재 위치";
            }
        }
        //txt.text = "Recog ....";
        return qrRecogChk;
    }

    public void qrOn()
    {
        Time.timeScale = 1;
        SYEUI.UM.panel.SetActive(false);
        //um.panel.SetActive(false);
        //trackedManager.GetComponent<ARTrackedImageManager>().enabled = true;
        //if (trackedManager.GetComponent<ARTrackedImageManager>().enabled)
        {



            trackedManager.GetComponent<FindPosition>().markerIndex = -1;
            //trackedManager.GetComponent<FindPosition>().mediciMap.transform.position = Vector3.zero;
            //trackedManager.GetComponent<FindPosition>().mediciMap.transform.rotation = Quaternion.Euler(0, 0, 0);

            CH.gameObject.SetActive(true);
            Cjj_CloudSpawnManager.instance.SPAWN = false;
            itemBag.SetActive(false);
            for(int i = 0; i < store.Length;i++)
                store[i].SetActive(false);
            //trackedManager.GetComponent<ARTrackedImageManager>().enabled = true;
            //trackedManager.GetComponent<ARTrackedImageManager>().trackedImagePrefab.GetComponent<BoxCollider>().enabled = true;
            //txt.text = "현재 위치";
            
            GetComponent<FindDestination>().storeObj.SetActive(false);
            //dpBtnManager.GetComponent<DestinationBtn>().destinationIndex = -1;
            int num = GetComponent<FindDestination>().storeObj.transform.childCount;
            for(int i = 0; i < num; i++)
            {
                GetComponent<FindDestination>().storeObj.transform.GetChild(i).gameObject.SetActive(false);
            }

            GetComponent<FindDestination>().storeObj.transform.parent.GetChild(0).gameObject.SetActive(true);
            GetComponent<FindDestination>().storeObj.transform.parent.GetChild(1).gameObject.SetActive(true);
            GetComponent<FindDestination>().storeObj.transform.parent.GetChild(2).gameObject.SetActive(true);
            GetComponent<FindDestination>().storeObj.transform.parent.GetChild(3).gameObject.SetActive(true);
            GetComponent<FindDestination>().storeObj.transform.parent.GetChild(4).gameObject.SetActive(true);


        }
    }

}
