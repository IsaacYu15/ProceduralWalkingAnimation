using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    public Transform target;
    
    public Transform feet;
    Vector3 feetTarget;

    public float moveSpeed;
    public float maxStep;

    public bool moveFeet;

    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, Vector3.down,  out hit, Mathf.Infinity, 1 << 7) )
        {
            target.transform.position = hit.point;
        }
        
        if (Vector3.Distance (feet.position, target.position) > maxStep)
        {
            //divide by two as the position of the feet is defined at the center of the cube
            feet.transform.position = target.transform.position + new Vector3(0, feet.transform.localScale.y / 2, 0) ;

        }
    }




}
