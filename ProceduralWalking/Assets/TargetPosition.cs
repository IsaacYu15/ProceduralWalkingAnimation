using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    public float maxStep;
    public Transform target;
    public Transform feet;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down,  out hit, Mathf.Infinity, 1 << 7) )
        {
            target.transform.position = hit.point;
        }

        if (Vector3.Distance (feet.position, target.position) > maxStep)
        {
            feet.transform.position = target.transform.position + new Vector3(0, feet.transform.localScale.y / 2, 0) ;
        }
    }

}
