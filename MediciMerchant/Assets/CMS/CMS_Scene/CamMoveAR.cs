using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamMoveAR : MonoBehaviour
{
    public Text text;
    public GameObject cam;
    public GameObject map;
    public GameObject[] origin;

    // Start is called before the first frame update

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        text.text = cam.transform.position.ToString();

    }

    public void nextMove()
    {
        //cam.transform.position = new Vector3(0, 0, 0);
        map.transform.position = new Vector3(cam.transform.position.x, 0, cam.transform.position.z);
        map.transform.position += new Vector3(origin[0].transform.localPosition.x,0,origin[0].transform.localPosition.z);
        map.transform.rotation = Quaternion.Euler(0, -90, 0);
        //origin[0].transform.position = map.transform.position;
    }
    public void nextMove2()
    {
        //cam.transform.position = new Vector3(0, 0, 0);
        map.transform.position = new Vector3(cam.transform.position.x, 0, cam.transform.position.z);
        map.transform.position += new Vector3(origin[1].transform.position.x, 0, origin[1].transform.position.z);
        map.transform.rotation = Quaternion.Euler(0, -51.776f, 0);
        //origin[0].transform.position = map.transform.position;
    }
}
