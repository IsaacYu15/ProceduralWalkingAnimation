using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepAnimation : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public float stepHeight = 0.05f;

    public Vector3 target;
    public Vector3 control;
    public Vector3 t_trans;

    float fraction;

    private void Update()
    {
        if (Vector3.Distance (target, transform.position) > 0.1f)
        {
            if (fraction < 1)
            {
                //Bezier Curve calculations
                fraction += Time.deltaTime * moveSpeed;
                Vector3 m1 = Vector3.Lerp(t_trans, control, fraction);
                Vector3 m2 = Vector3.Lerp(control, target, fraction);
                transform.position = Vector3.Lerp(m1, m2, fraction);
            }

        } else
        {
            fraction = 0;
        }

    }
}
