using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovements : MonoBehaviour
{
    public Transform body;
    public float swaySpeed;
    public float swayAmount;

    public float minHeightFromGround;

    float count;

    void Update()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, 1 << 7))
        {

            if (hit.distance != minHeightFromGround)
            {
                transform.position += new Vector3(0, minHeightFromGround - hit.distance, 0);
            }
        }
    }

}
