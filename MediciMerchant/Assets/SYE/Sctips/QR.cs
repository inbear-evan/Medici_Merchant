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
    public TMP_Text txt;
    //public GameObject dpBtnManager;


    private void Start()
    {
        //nada.GetComponent<MeshRenderer>().enabled = false;
        //trackedManager.GetComponent<ARTrackedImageManager>().trackedImagePrefab.GetComponent<MeshRenderer>().enabled = false;
        CH.gameObject.SetActive(true);
        statusSlider.gameObject.SetActive(false);
        trackedManager.GetComponent<ARTrackedImageManager>().enabled = true;
        cam = trackedManager.transform.GetChild(0).gameObject;
        //txt.text = "��Ŀ �˻�";
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
                //txt.text = "���� ��ġ";
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

        if (trackedManager.GetComponent<ARTrackedImageManager>().enabled)
        {
            CH.gameObject.SetActive(true);
            Cjj_CloudSpawnManager.instance.SPAWN = false;
            itemBag.SetActive(false);
            for(int i = 0; i < store.Length;i++)
                store[i].SetActive(false);
            //trackedManager.GetComponent<ARTrackedImageManager>().enabled = true;
            //trackedManager.GetComponent<ARTrackedImageManager>().trackedImagePrefab.GetComponent<BoxCollider>().enabled = true;
            txt.text = "���� ��ġ";
            GetComponent<FindDestination>().storeObj.SetActive(false);
            //dpBtnManager.GetComponent<DestinationBtn>().destinationIndex = -1;
        }
    }

}
