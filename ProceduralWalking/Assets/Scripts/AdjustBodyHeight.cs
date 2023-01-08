using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustBodyHeight : MonoBehaviour
{
    public float minHeightFromGround;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, 1 << 7))
        {
            //transform.rotation = new Quaternion(hit.normal.x, hit.normal.y, hit.normal.z, transform.rotation.w);

            if (hit.distance != minHeightFromGround)
            {
                transform.position += new Vector3(0, (minHeightFromGround - hit.distance), 0);
            }
        }
    }
}
