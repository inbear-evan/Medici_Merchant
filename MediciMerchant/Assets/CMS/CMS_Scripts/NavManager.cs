using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class NavManager : MonoBehaviour
{
  
    public void DrawPathLine(Vector3 startingPoint, Transform endPoint, LineRenderer lr)
    {
        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(startingPoint, endPoint.position, NavMesh.AllAreas, path);
        lr.positionCount = path.corners.Length;
        lr.SetPositions(path.corners);
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {

       
    }
}
