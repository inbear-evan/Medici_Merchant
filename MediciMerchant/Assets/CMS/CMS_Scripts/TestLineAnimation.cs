using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLineAnimation : MonoBehaviour
{
    public Material material;
    public Vector2 offsetSpeed = new Vector2(0,-1);
    LineRenderer lr;

    //Vector3[] pt = new Vector3[3];
    private void Start()
    {
        //lr = GetComponent<LineRenderer>();
        //material.mainTextureOffset = new Vector2(0, 0);
        //material.mainTextureScale *= 2f;
    }
    void Update()
    {

        //lr.SetPosition(0, new Vector3(0, 0, 0));
        //lr.SetPosition(1, new Vector3(0, 0, 5));
        //lr.SetPositions(pt);
        if(material.mainTextureOffset.x >= -1)
            material.mainTextureOffset += offsetSpeed * Time.deltaTime;
        else 
            material.mainTextureOffset = new Vector2(0, 0);
    }
}
