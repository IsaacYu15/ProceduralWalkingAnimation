using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotOnToSurface : MonoBehaviour
{
    public Transform feetParent;
    public float minRotActive = 1;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, 1 << 7) && hit.distance < minRotActive) 
        {
            feetParent.rotation = Quaternion.FromToRotation(transform.up, hit.normal);
        }
    }
}
