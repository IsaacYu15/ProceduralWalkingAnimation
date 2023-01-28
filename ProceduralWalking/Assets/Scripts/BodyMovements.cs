using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovements : MonoBehaviour
{
    public Transform body;
    public float minHeightFromGround;

    public int feetCount = 8;
    public Transform feetParent;
    public Transform[] feets;

    public float swayAmount;
    public float breathAmount;
    float fraction;
    float t_sway;

    public Vector3 averageRight;
    public Vector3 averageLeft;
    private void Start()
    {
        feets = new Transform[feetCount];

        int i = 0;

        foreach (Transform child in feetParent)
        {
            if (child.name.Contains("Target"))
            {
                feets[i] = child.transform;
                i++;
            }
        }
    }


    void Update()
    {
        //average positions of all feet
        for (int i = 0; i < feetCount; i++)
        {
            if (i < 4)
            {
                averageLeft += feets[i].position;
            }
            else
            {
                averageRight += feets[i].position;
            }
        }

        averageRight = averageRight / (feetCount / 2);
        averageLeft = averageLeft / (feetCount / 2);

        var averageFeet = (averageLeft + averageRight) / 2;

        //adjust rotation based on feet by getting the direction of the vector from "left feet" and "right feet"
        var dir = averageLeft - averageRight;
        var rot = Quaternion.LookRotation(dir, Vector3.up);

        transform.rotation = new Quaternion(transform.rotation.x + rot.x, transform.rotation.y + rot.y, transform.rotation.z + rot.z, transform.rotation.w);

        //body moves up and down slightly for a breathing effect 
        fraction += Time.deltaTime;
        t_sway = Mathf.Sin(fraction);

        //apply transform calulations
        body.rotation = new Quaternion (t_sway * swayAmount, body.rotation.y, body.rotation.z, body.rotation.w);
        transform.position = new Vector3(transform.position.x, averageFeet.y + minHeightFromGround + t_sway * breathAmount, transform.position.z);

        //reset
        averageRight = Vector3.zero;
        averageLeft = Vector3.zero;
    }

}
