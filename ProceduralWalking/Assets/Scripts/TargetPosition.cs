using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    public Transform feetParent;
    public Transform target; 
    public Transform feet;
    StepAnimation step;

    public float maxStep;
    public float maxStepUp = 1f;

    Vector3 prevStep;

    private void Start()
    {
        step = feet.GetComponent<StepAnimation>();

    }

    void Update()
    {
        RaycastHit hit;
        
        //detect the position for where the spider could put its feet
        if (Physics.Raycast(transform.position, -feetParent.transform.up,  out hit, Mathf.Infinity, 1 << 7) )
        {
            Vector3 t_hit = hit.point; t_hit.y = 0;

            if (Vector3.Distance(prevStep, t_hit) > 2f)
            {
                target.transform.position = hit.point;
                prevStep = t_hit;
                
            }
        }

        //if the distance between the feet and the target position is too great, move the feet to the target position
        if (Vector3.Distance (feet.position - feet.parent.transform.up.normalized * feet.transform.localScale.y, target.position) > maxStep)
        {
            MoveFeet();
        }

    }

    public void MoveFeet ()
    {
        step.t_trans = feet.transform.position;
        step.target = target.transform.position + feet.parent.transform.up.normalized * feet.transform.localScale.y / 2;
        step.control = (target.transform.position + feet.transform.position) / 2 + feetParent.transform.up.normalized * step.stepHeight;

        if (!step.moveFeet)
        {
            step.fraction = 0;
        }

        step.moveFeet = true;


    }




}
