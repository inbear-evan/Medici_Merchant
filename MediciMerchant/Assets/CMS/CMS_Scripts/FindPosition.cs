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
    public Transform marker1;
    public Transform destination;
    public Transform player;
    ARTrackedImageManager arTim;
    public LineRenderer lr;
    public NavMeshSurface surface;
    public TMP_Text arrivedText;
    public TMP_Dropdown dp;
    public GameObject nada;
    public GameObject storeObj;
    public FindDestination fd;
    public Slider sl;
    public int markerIndex = -1;
    private void Awake()
    {
        lr.enabled = false;
        mediciMap.SetActive(false);
        miniMap.SetActive(false);
        storeObj.SetActive(false);
        sl.gameObject.SetActive(false);
        arTim = GetComponent<ARTrackedImageManager>();
        arrivedText.text = "마커 검색";
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
        float DestDistance = Vector3.Distance(player.position, destination.position);

        if (DestDistance <= 1f)
        {
            arrivedText.text = "도착";
            storeObj.SetActive(true);
            miniMap.SetActive(false);
            fd.D.SetActive(false);
            lr.enabled = false;
            sl.gameObject.SetActive(false);
            Cjj_CloudSpawnManager.instance.SPAWN = true;
        }
        else
        {
            GetComponent<NavManager>().DrawPathLine(player.position, destination, lr);
            if (!sl.gameObject.activeSelf)
            {
                sl.gameObject.SetActive(true);
                sl.maxValue = Vector3.Distance(player.position, destination.position);
            }
            else
            {
                sl.value = Vector3.Distance(player.position, destination.position);
            }
        }

        for (int i = 0; i < obj.updated.Count; i++)
        {
            ARTrackedImage markerImg = obj.updated[i];
            if (markerImg.trackingState == TrackingState.Tracking)
            {
                if (markerImg.referenceImage.name == "1")
                {
                    nada.SetActive(true);
                    nada.transform.position = markerImg.transform.position;
                    nada.transform.rotation = markerImg.transform.rotation;
                    markerIndex = 3;
                    if (QR.QM.qrRecog())
                    {
                        miniMap.SetActive(true);
                        lr.gameObject.SetActive(true);
                        arrivedText.text = "안내 중";
                        mediciMap.SetActive(true);

                        //mediciMap.transform.rotation = Quaternion.Euler(0, 180, 0);
                        //mediciMap.transform.position = new Vector3(1*(marker1.position.z), -1, -1 * marker1.position.x);
                        //mediciMap.transform.position = new Vector3(marker1.position.x, -1, marker1.position.z);
                        lr.enabled = true;
                        surface.RemoveData();
                        surface.BuildNavMesh();

                        fd.D.SetActive(true);
                        fd.D.transform.position = destination.transform.position;
                        nada.SetActive(false);
                    }

                }
            }
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
