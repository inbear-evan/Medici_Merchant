using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class FindPosition : MonoBehaviour
{
    public GameObject mediciMap;
    public GameObject miniMap;
    public Transform[] originPt;
    public Transform destination;
    public Transform player;
    ARTrackedImageManager arTim;
    public LineRenderer lr;
    public NavMeshSurface surface;
    //public TMP_Text arrivedText;
    //public TMP_Dropdown dp;
    public GameObject nada;
    public GameObject storeObj;
    public FindDestination fd;
    public DestinationBtn dpBtn;
    public Slider sl;
    public bool slCheck = false;

    public Text originPtTxt;
    public int markerIndex = -1;
    public int firstRecogPosition = -1;
    private void Awake()
    {

        //currentPt.gameObject.SetActive(false);
        markerIndex = -1;
        firstRecogPosition = -1;
        lr.enabled = false;
        mediciMap.SetActive(false);
        miniMap.SetActive(false);
        storeObj.SetActive(false);
        sl.value = sl.maxValue = 1;
        sl.gameObject.SetActive(false);
        destination = null;
        slCheck = false;
        arTim = GetComponent<ARTrackedImageManager>();
        int num = storeObj.transform.childCount;
        for (int i = 0; i < num; i++)
        {
            storeObj.transform.GetChild(i).gameObject.SetActive(false);
        }
        //arrivedText.text = "마커 검색";
    }
    private void OnEnable()
    {
        arTim.trackedImagesChanged += OnStepChange;
    }
    private void OnDisable()
    {
        arTim.trackedImagesChanged -= OnStepChange;
    }
    private void OnStepChange(ARTrackedImagesChangedEventArgs obj)
    {
        //originPtTxt.text = transform.GetChild(0).position.ToString();
        originPtTxt.text = markerIndex.ToString();
        float DestDistance = Vector3.Distance(player.position, destination.position);
        if (DestDistance < 1f)
        //if (!slCheck)
        {
            //arrivedText.text = "도착";
            storeObj.SetActive(true);
            for (int i = 0; i < 5; i++)
            {
                storeObj.transform.GetChild(i).gameObject.SetActive(dpBtn.destinationIndex == i);
            }
            miniMap.SetActive(false);
            fd.D.SetActive(false);
            lr.enabled = false;
            slCheck = false;
            sl.gameObject.SetActive(false);
            nada.SetActive(false);
            Cjj_CloudSpawnManager.instance.SPAWN = true;

            //transform.position = transform.GetChild(0).position;
            //transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            if (markerIndex != -1)
                GetComponent<NavManager>().DrawPathLine(player.position, destination, originPt[markerIndex], lr);
        }
        // 0 naples
        // 1 rome
        // 2 Veneci
        // 3 milan
        // 4 florence
        for (int i = 0; i < obj.updated.Count; i++)
        {
            ARTrackedImage markerImg = obj.updated[i];
            if (markerImg.trackingState == TrackingState.Tracking)
            {
                if (markerImg.referenceImage.name == "Naples")
                {
                    nada.SetActive(true);
                    nada.transform.position = markerImg.transform.position;
                    nada.transform.rotation = markerImg.transform.rotation;
                    //currentPt.position = panelDestination.GetChild(1).position;
                    //currentPt.gameObject.SetActive(true);
                    markerIndex = 0;

                    //markerIndex = 3;
                    if (QR.QM.qrRecog())
                    {
                        miniMap.SetActive(true);
                        lr.gameObject.SetActive(true);
                        //arrivedText.text = "나폴리";
                        mediciMap.SetActive(true);
                        sl.gameObject.SetActive(true);
                        //mediciMap.transform.rotation = Quaternion.Euler(0, 180, 0);
                        //mediciMap.transform.position = new Vector3(1*(marker1.position.z), -1, -1 * marker1.position.x);
                        //mediciMap.transform.position = new Vector3(marker1.position.x, -1, marker1.position.z);

                        lr.enabled = true;
                        surface.RemoveData();
                        surface.BuildNavMesh();

                        fd.D.SetActive(true);
                        nada.SetActive(false);

                        mediciMap.transform.position = new Vector3(player.transform.position.x, mediciMap.transform.position.y, player.transform.position.z);
                        mediciMap.transform.position -= new Vector3(originPt[markerIndex].position.x, 0, originPt[markerIndex].position.z);
                        mediciMap.transform.rotation = Quaternion.Euler(0, 0, 0);
                        //mediciMap.GetComponent<SyncMap>().localCompass.eulerAngles = new Vector3(0, 0, 0);
                        //mediciMap.GetComponent<SyncMap>().worldCompass.eulerAngles = new Vector3(0, 0, 0);

                        //transform.GetChild(0).position = transform.position = originPt[markerIndex].transform.position;
                        //transform.GetChild(0).rotation = transform.rotation = Quaternion.identity;

                        //transform.GetChild(0).position = originPt[markerIndex].transform.position;
                    }
                }
                else if (markerImg.referenceImage.name == "Rome")
                {
                    nada.SetActive(true);
                    nada.transform.position = markerImg.transform.position;
                    nada.transform.rotation = markerImg.transform.rotation;
                    markerIndex = 1;
                    if (QR.QM.qrRecog())
                    {
                        miniMap.SetActive(true);
                        lr.gameObject.SetActive(true);
                        mediciMap.SetActive(true);
                        sl.gameObject.SetActive(true);

                        lr.enabled = true;
                        surface.RemoveData();
                        surface.BuildNavMesh();

                        fd.D.SetActive(true);
                        nada.SetActive(false);
                        mediciMap.transform.position = new Vector3(player.transform.position.x, mediciMap.transform.position.y, player.transform.position.z);
                        mediciMap.transform.position -= new Vector3(originPt[markerIndex].position.x, 0, originPt[markerIndex].position.z);
                        mediciMap.transform.rotation = Quaternion.Euler(0, 0, 0);

                        //mediciMap.transform.position = new Vector3(-originPt[markerIndex].transform.position.x, -1, -originPt[markerIndex].transform.position.z);
                        //mediciMap.transform.rotation = Quaternion.Euler(0, 0, 0);
                        //transform.GetChild(0).position = transform.position = originPt[markerIndex].transform.position;
                        //transform.GetChild(0).rotation = transform.rotation = Quaternion.identity;
                        //transform.GetChild(0).position = originPt[markerIndex].transform.position;
                    }
                }
                else if (markerImg.referenceImage.name == "Venice")
                {
                    nada.SetActive(true);
                    nada.transform.position = markerImg.transform.position;
                    nada.transform.rotation = markerImg.transform.rotation;
                    markerIndex = 2;
                    if (QR.QM.qrRecog())
                    {
                        miniMap.SetActive(true);
                        lr.gameObject.SetActive(true);
                        mediciMap.SetActive(true);
                        sl.gameObject.SetActive(true);

                        lr.enabled = true;
                        surface.RemoveData();
                        surface.BuildNavMesh();

                        fd.D.SetActive(true);
                        nada.SetActive(false);


                        mediciMap.transform.position = new Vector3(player.transform.position.x, mediciMap.transform.position.y, player.transform.position.z);
                        mediciMap.transform.position -= new Vector3(originPt[markerIndex].position.x, 0, originPt[markerIndex].position.z);
                        mediciMap.transform.rotation = Quaternion.Euler(0, 0, 0);

                        //mediciMap.transform.position = transform.position;
                        //mediciMap.transform.rotation = Quaternion.identity;

                        //transform.GetChild(0).position = transform.position = originPt[markerIndex].transform.position;
                        //transform.GetChild(0).rotation = transform.rotation = Quaternion.identity;

                        //mediciMap.transform.position = originPt[markerIndex].transform.position + new Vector3(originPt[markerIndex].transform.position.x, 0, originPt[markerIndex].transform.position.z);
                        //mediciMap.transform.rotation = Quaternion.Euler(0, 0, 0);
                        //transform.GetChild(0).position = originPt[markerIndex].transform.position;
                    }
                }
                else if (markerImg.referenceImage.name == "Milan")
                {
                    nada.SetActive(true);
                    nada.transform.position = markerImg.transform.position;
                    nada.transform.rotation = markerImg.transform.rotation;
                    markerIndex = 3;
                    if (QR.QM.qrRecog())
                    {
                        miniMap.SetActive(true);
                        lr.gameObject.SetActive(true);
                        //arrivedText.text = "나폴리"
                        mediciMap.SetActive(true);
                        sl.gameObject.SetActive(true);

                        lr.enabled = true;
                        surface.RemoveData();
                        surface.BuildNavMesh();

                        fd.D.SetActive(true);
                        nada.SetActive(false);

                        mediciMap.transform.position = new Vector3(player.transform.position.x, mediciMap.transform.position.y, player.transform.position.z);
                        mediciMap.transform.position -= new Vector3(originPt[markerIndex].position.x, 0, originPt[markerIndex].position.z);
                        mediciMap.transform.rotation = Quaternion.Euler(0, 0, 0);

                        //mediciMap.transform.position = new Vector3(-originPt[markerIndex].transform.position.x, -1, -originPt[markerIndex].transform.position.z);

                        //mediciMap.transform.position = transform.position;
                        //mediciMap.transform.rotation = Quaternion.identity;

                        //transform.GetChild(0).position = transform.position = originPt[markerIndex].transform.position;
                        //transform.GetChild(0).rotation = transform.rotation = Quaternion.identity;

                        //transform.GetChild(0).position = originPt[markerIndex].transform.position;
                    }
                }
                else if (markerImg.referenceImage.name == "Florence")
                {
                    nada.SetActive(true);
                    nada.transform.position = markerImg.transform.position;
                    nada.transform.rotation = markerImg.transform.rotation;
                    markerIndex = 4;
                    if (QR.QM.qrRecog())
                    {
                        miniMap.SetActive(true);
                        lr.gameObject.SetActive(true);
                        mediciMap.SetActive(true);
                        sl.gameObject.SetActive(true);

                        lr.enabled = true;
                        surface.RemoveData();
                        surface.BuildNavMesh();

                        fd.D.SetActive(true);
                        nada.SetActive(false);

                        mediciMap.transform.position = new Vector3(player.transform.position.x, mediciMap.transform.position.y, player.transform.position.z);
                        mediciMap.transform.position -= new Vector3(originPt[markerIndex].position.x, 0, originPt[markerIndex].position.z);
                        mediciMap.transform.rotation = Quaternion.Euler(0, 0, 0);


                        //transform.GetChild(0).position = transform.position = originPt[markerIndex].transform.position;
                        //transform.GetChild(0).rotation = transform.rotation = Quaternion.identity;

                        //mediciMap.transform.position = originPt[markerIndex].transform.position + new Vector3(originPt[markerIndex].transform.position.x,0, originPt[markerIndex].transform.position.z);
                        //mediciMap.transform.rotation = Quaternion.Euler(0, 0, 0);

                        //mediciMap.transform.position = transform.position;
                        //mediciMap.transform.rotation = Quaternion.identity;

                        //transform.GetChild(0).position = originPt[markerIndex].transform.position;

                    }
                }
            }
        }
        fd.D.transform.position = destination.transform.position;
        if(firstRecogPosition == -1)
        {
            firstRecogPosition = markerIndex;
        }
    }

    //public void Destination()
    //{
    //    destination = mediciMap.transform.GetChild(0).GetChild(dp.value - 1);
    //    fd.D.transform.position = destination.position;
    //    //fd.D.GetComponent<MeshRenderer>().enabled = true;
    //    //Debug.Log(destination.name);
    //    if (destination.name == "목적지") destination = null;
    //}

}
