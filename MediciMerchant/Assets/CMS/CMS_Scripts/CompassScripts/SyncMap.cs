using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SyncMap : MonoBehaviour
{
    /// <summary>
    /// 0 naples
    /// 1 rome
    /// 2 venice
    /// 3 milan
    /// 4 florence
    /// </summary>
    public Quaternion worldCompass;
    public Quaternion localCompass;
    public GameObject Player;
    public GameObject[] origin;

    // Start is called before the first frame update
    void Start()
    {
        //worldCompass= Quaternion.Euler(0, 180, 0);
        //transform.rotation = worldCompass;
    }

    // Update is called once per frames
    //public int mem = -1;
    void Update()
    {
        //int currentNum = Camera.main.transform.parent.GetComponent<FindPosition>().markerIndex;
        int currentNum = Player.transform.parent.GetComponent<FindPosition>().markerIndex;
        int rot_y_idx = Player.transform.parent.GetComponent<FindPosition>().firstRecogPosition;
        //int rot_y = Player.transform.parent.GetComponent<FindPosition>().firstRecogPositionsRotation[rot_y_idx];
        int rot_y = 0;
        //int currentNum = mem;
        //transform.position = Vector3.zero;
        //transform.position = new Vector3(0, 0, 0);
        if (currentNum != -1)
        {
            if (currentNum == 0)
            {
                if (rot_y_idx != -1)
                {
                    if (0 == rot_y_idx || 1 == rot_y_idx) rot_y = 0;
                    else if (2 == rot_y_idx) rot_y = 90;
                    else if (3 == rot_y_idx || 4 == rot_y_idx) rot_y = -90;
                }
                //90
                worldCompass = Quaternion.Euler(0, 180 + rot_y, 0);
                //Player.transform.position = new Vector3(origin[currentNum].transform.position.x, 0, origin[currentNum].transform.position.z);
                //localCompass = (origin[currentNum].transform.rotation);
                //transform.position = new Vector3(-origin[currentNum].transform.position.x, -1, origin[currentNum].transform.position.z);
                localCompass = Quaternion.Euler(0, 180 - rot_y, 0);
                //transform.rotation = Quaternion.Euler(0, localCompass.eulerAngles.y, 0);

                transform.rotation = localCompass;
                //Player.transform.parent.GetComponent<FindPosition>().markerIndex = 5;

            }
            else if (currentNum == 1)
            {
                if (rot_y_idx != -1)
                {
                    if (0 == rot_y_idx || 1 == rot_y_idx) rot_y = 0;
                    else if (2 == rot_y_idx) rot_y = 90;
                    else if (3 == rot_y_idx || 4 == rot_y_idx) rot_y = -90;
                }
                //90
                worldCompass = Quaternion.Euler(0, 180 + rot_y, 0);
                //Player.transform.position = new Vector3(origin[currentNum].transform.position.x, 0, origin[currentNum].transform.position.z);
                //localCompass = (origin[currentNum].transform.rotation);
                //transform.position = new Vector3(-origin[currentNum].transform.position.x, -1, -origin[currentNum].transform.position.z);
                localCompass = Quaternion.Euler(0, 180 - rot_y, 0);
                //transform.rotation = Quaternion.Euler(0, localCompass.eulerAngles.y, 0);
                transform.rotation = localCompass;
                //Player.transform.parent.GetComponent<FindPosition>().markerIndex = 5;
            }
            else if (currentNum == 2)
            {
                if (rot_y_idx != -1)
                {
                    if (0 == rot_y_idx || 1 == rot_y_idx) rot_y = -90;
                    else if (2 == rot_y_idx) rot_y = 0;
                    else if (3 == rot_y_idx || 4 == rot_y_idx) rot_y = 180;
                }
                //180 
                worldCompass = Quaternion.Euler(0, 180 + rot_y, 0);
                //Player.transform.position = new Vector3(origin[currentNum].transform.position.x, 0, origin[currentNum].transform.position.z);
                //localCompass = (origin[currentNum].transform.rotation);
                //transform.position = new Vector3(-origin[currentNum].transform.position.x, -1, -origin[currentNum].transform.position.z);
                localCompass = Quaternion.Euler(0, 0 + rot_y, 0);
                //transform.rotation = Quaternion.Euler(0, worldCompass.eulerAngles.y, 0);
                transform.rotation = worldCompass;
                //Player.transform.parent.GetComponent<FindPosition>().markerIndex = 5;
            }
            else if (currentNum == 3 || currentNum == 4)
            {
                if (rot_y_idx != -1)
                {
                    if (0 == rot_y_idx || 1 == rot_y_idx) rot_y = 90;
                    else if (2 == rot_y_idx) rot_y = 180;
                    else if (3 == rot_y_idx || 4 == rot_y_idx) rot_y = 0;
                }
                //0
                worldCompass = Quaternion.Euler(0, 0 + rot_y, 0);
                //Player.transform.position = new Vector3(origin[currentNum].transform.position.x, 0, origin[currentNum].transform.position.z);
                //localCompass = (origin[currentNum].transform.rotation);
                //transform.position = new Vector3(-origin[currentNum].transform.position.x, -1, -origin[currentNum].transform.position.z);
                localCompass = Quaternion.Euler(0, 180 + rot_y, 0);
                //transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.rotation = worldCompass;
                //Player.transform.parent.GetComponent<FindPosition>().markerIndex = 5;
            }
            //Player.transform.parent.GetComponent<FindPosition>().markerIndex = 5;
            //Player.transform.parent.GetComponent<FindPosition>().surface.RemoveData();
            //Player.transform.parent.GetComponent<FindPosition>().surface.BuildNavMesh();
        }

        //Player.transform.position = new Vector3(origin[currentNum].transform.position.x, 0, origin[currentNum].transform.position.z);


        //transform.position = new Vector3(origin[currentNum].transform.position.x, -1, origin[currentNum].transform.position.z);
        //180 - a
        //localCompass = (origin[currentNum].transform.rotation);
        //transform.rotation = Quaternion.Euler(0, worldCompass.eulerAngles.y - localCompass.eulerAngles.y, 0);
    }
}
