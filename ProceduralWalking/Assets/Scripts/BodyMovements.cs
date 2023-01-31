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

        //body moves up and down slightly for a breathing effect 
        fraction += Time.deltaTime;
        t_sway = Mathf.Sin(fraction);

        //apply transform calulations
        body.rotation = new Quaternion (t_sway * swayAmount, body.rotation.y, body.rotation.z, body.rotation.w);
        transform.position = new Vector3(transform.position.x, averageFeet.y + minHeightFromGround + t_sway * breathAmount, transform.position.z);


        //adjust rotation based on feet by getting the direction of the vector from "left feet" and "right feet"
        var dir = averageLeft - averageRight;
        var rot = Quaternion.LookRotation(dir, Vector3.up);
        Debug.DrawLine(averageLeft, averageRight, Color.green, 0.1f);

        //get up down rotation with only front and back legs
        var dir2 = (feets[0].position + feets[feetCount / 2].position) / 2 - (feets[feetCount / 2 - 1].position + feets[feetCount - 1].position) / 2;
        Debug.DrawLine( (feets[0].position + feets[feetCount / 2].position) / 2, (feets[feetCount / 2 - 1].position + feets[feetCount - 1].position) / 2, Color.green, 0.1f);
        var rot2 = Quaternion.LookRotation(dir2, Vector3.up);

        transform.rotation = new Quaternion(rot2.x, transform.rotation.y, rot.z, transform.rotation.w);

        //reset
        averageRight = Vector3.zero;
        averageLeft = Vector3.zero;
    }

}
