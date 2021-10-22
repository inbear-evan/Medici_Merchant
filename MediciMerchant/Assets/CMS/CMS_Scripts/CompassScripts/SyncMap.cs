using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncMap : MonoBehaviour
{
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
    void Update()
    {
        int currentNum = Camera.main.transform.parent.GetComponent<FindPosition>().markerIndex;
        if (currentNum != -1)
        {
            worldCompass = Quaternion.Euler(0, 180, 0);
            transform.position = new Vector3(origin[currentNum].transform.position.x, -1, origin[currentNum].transform.position.z);
            //180 - a
            localCompass = (origin[currentNum].transform.rotation);
            transform.rotation = Quaternion.Euler(0, worldCompass.eulerAngles.y - localCompass.eulerAngles.y, 0);
        }
    }
}
