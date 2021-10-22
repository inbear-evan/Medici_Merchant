using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class NavManager : MonoBehaviour
{

    public void DrawPathLine(Vector3 startingPoint, Transform endPoint, Transform orgin, LineRenderer lr)
    {
        float totalDistance = 0;
        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(startingPoint, endPoint.position, NavMesh.AllAreas, path);
        lr.positionCount = path.corners.Length;
        lr.SetPositions(path.corners);
        //for (int i = 0; i < path.corners.Length - 1; i++)
        //{
        //    totalDistance += Vector3.Distance(path.corners[i], path.corners[i + 1]);
        //}
        totalDistance = Vector3.Distance(orgin.position, endPoint.position);
        transform.GetComponent<FindPosition>().sl.maxValue = totalDistance;

        totalDistance = Vector3.Distance(startingPoint, endPoint.position);
        transform.GetComponent<FindPosition>().sl.value = transform.GetComponent<FindPosition>().sl.maxValue - totalDistance;
    }
}
