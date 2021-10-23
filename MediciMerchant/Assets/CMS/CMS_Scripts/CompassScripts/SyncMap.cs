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
    Quaternion worldCompass;
    public Quaternion localCompass;
    public GameObject Player;
    public GameObject[] origin;


    // Start is called before the first frame update
    void Start()
    {
        //worldCompass= Quaternion.Euler(0, 180, 0);
        //transform.rotation = worldCompass;
    }

    // Update is called once per frame
    //public int mem = -1;
    void Update()
    {

        int currentNum = Camera.main.transform.parent.GetComponent<FindPosition>().markerIndex;
        //int currentNum = mem;
        if (currentNum != -1)
        {
            if(currentNum == 0)
            {
                //90
                worldCompass = Quaternion.Euler(0, 180, 0);
                transform.position = new Vector3(-origin[currentNum].transform.position.x, -1, origin[currentNum].transform.position.z);
                //localCompass = (origin[currentNum].transform.rotation);
                localCompass = Quaternion.Euler(0, 90, 0);
                transform.rotation = Quaternion.Euler(0, worldCompass.eulerAngles.y - localCompass.eulerAngles.y, 0);
            }
            else if(currentNum == 1)
            {
                //90
                worldCompass = Quaternion.Euler(0, 180, 0);
                transform.position = new Vector3(-origin[currentNum].transform.position.x, -1, -origin[currentNum].transform.position.z);
                //localCompass = (origin[currentNum].transform.rotation);
                localCompass = Quaternion.Euler(0, 90, 0);
                transform.rotation = Quaternion.Euler(0, worldCompass.eulerAngles.y - localCompass.eulerAngles.y, 0);
            }
            else if (currentNum == 2)
            {
                //180 
                worldCompass = Quaternion.Euler(0, 180, 0);
                transform.position = new Vector3(-origin[currentNum].transform.position.x, -1, -origin[currentNum].transform.position.z);
                //localCompass = (origin[currentNum].transform.rotation);
                localCompass = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.Euler(0, worldCompass.eulerAngles.y - localCompass.eulerAngles.y, 0);
            }
            else if (currentNum == 3 || currentNum == 4)
            {
                //0
                worldCompass = Quaternion.Euler(0, 0, 0);
                transform.position = new Vector3(-origin[currentNum].transform.position.x, -1, -origin[currentNum].transform.position.z);
                //localCompass = (origin[currentNum].transform.rotation);
                localCompass = Quaternion.Euler(0, -180, 0);
                transform.rotation = Quaternion.Euler(0, worldCompass.eulerAngles.y, 0);
            }

            //transform.position = new Vector3(origin[currentNum].transform.position.x, -1, origin[currentNum].transform.position.z);
            //180 - a
            //localCompass = (origin[currentNum].transform.rotation);
            //transform.rotation = Quaternion.Euler(0, worldCompass.eulerAngles.y - localCompass.eulerAngles.y, 0);
        }
    }
}
