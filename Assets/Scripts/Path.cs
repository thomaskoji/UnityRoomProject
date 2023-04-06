using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject[] points;

    void OnDrawGizmosSelected()
    {
        for(var index = 0; index<points.Length - 1; index++)
        {
            var from = points[index].transform.position;
            var to = points[index + 1].transform.position;
            Gizmos.DrawLine(from, to);
        }
    }
}
