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
    public Transform marker1;
    Transform destination;
    public Transform player;
    ARTrackedImageManager arTim;

    QR qm;

    public LineRenderer lr;
    public NavMeshSurface surface;

    public TMP_Text arrivedText;
    Vector3 start;

    public TMP_Dropdown dp;

    public GameObject nada;
    public TMP_Text testTxt;
    public FindDestination fd;

    private void Awake()
    {
        lr.enabled = false;
        mediciMap.SetActive(false);
        //Instantiate(nada, new Vector3(0, 11, 0), Quaternion.identity);
        //nada.SetActive(false);
        arTim = GetComponent<ARTrackedImageManager>();
        arrivedText.text = "마커 검색";
        qm = GetComponent<QR>();
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
            fd.D.SetActive(false);
            lr.enabled = false;
        }
        else
        {   
            GetComponent<NavManager>().DrawPathLine(player.position, destination, lr);
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
                    if (QR.QM.qrRecog()) 
                    {
                        arrivedText.text = "안내 중";
                        testTxt.text = markerImg.referenceImage.name;
                        mediciMap.SetActive(true);
                        mediciMap.transform.rotation = Quaternion.Euler(0, 180, 0);
                        //mediciMap.transform.position = new Vector3(1*(marker1.position.z), -1, -1 * marker1.position.x);
                        mediciMap.transform.position = new Vector3(marker1.position.x, -1, marker1.position.z);
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

    public void Destination()
    {
        destination = mediciMap.transform.GetChild(0).GetChild(dp.value - 1);
        //fd.D.GetComponent<MeshRenderer>().enabled = true;
        //Debug.Log(destination.name);
        if (destination.name == "Destination") destination = null;
    }

}
