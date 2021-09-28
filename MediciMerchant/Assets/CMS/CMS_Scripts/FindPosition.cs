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

    public LineRenderer lr;
    public NavMeshSurface surface;

    public TMP_Text arrivedText;
    Vector3 start;

    public TMP_Dropdown dp;
    private void Awake()
    {
        lr.enabled = false;
        mediciMap.SetActive(false);
        arTim = GetComponent<ARTrackedImageManager>();
        arrivedText.text = "Test";
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
            arrivedText.text = "Arrived";
            lr.enabled = false;
        }
        else
        {
            arrivedText.text = "Go";
            GetComponent<NavManager>().DrawPathLine(player.position, destination, lr);
        }

        for (int i = 0; i < obj.updated.Count; i++)
        {
            ARTrackedImage markerImg = obj.updated[i];
            if (markerImg.trackingState == TrackingState.Tracking)
            {
                if (markerImg.referenceImage.name == "1")
                {
                    mediciMap.SetActive(true);
                    mediciMap.transform.rotation = Quaternion.Euler(0, 180, 0);
                    //mediciMap.transform.position = new Vector3(1*(marker1.position.z), -1, -1 * marker1.position.x);
                    mediciMap.transform.position = new Vector3(marker1.position.x, -1, marker1.position.z);

                    lr.enabled = true;
                    surface.RemoveData();
                    surface.BuildNavMesh();
                }
            }
        }
    }

    public void Destination()
    {
        destination = mediciMap.transform.GetChild(0).GetChild(dp.value-1);
        Debug.Log(destination.name);
        if (destination.name == "Destination") destination = null;
    }
   
}
