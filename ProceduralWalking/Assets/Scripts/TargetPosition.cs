using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{

    public Transform target; 
    public Transform feet;
    StepAnimation step;

    public float maxStep;

    private void Start()
    {
        step = feet.GetComponent<StepAnimation>();
    }
    void Update()
    {
        RaycastHit hit;
        
        //set target position (moves with body while feet stay grounded)
        if (Physics.Raycast(transform.position, Vector3.down,  out hit, Mathf.Infinity, 1 << 7) )
        {
            target.transform.position = hit.point;
        }

        //if the distance between the feet and the target position is too great, move the feet to the target position
        if (Vector3.Distance (feet.position - new Vector3 (0, feet.transform.localScale.y/2), target.position) > maxStep)
        {
            step.t_trans = feet.transform.position;
            step.target = target.transform.position + new Vector3(0, feet.transform.localScale.y / 2, 0) ;
            step.control = (target.transform.position + feet.transform.position) / 2 + Vector3.up * step.stepHeight;

            if (!step.moveFeet)
            {
                step.fraction = 0;
            }

            step.moveFeet = true;



        }

    }




}
