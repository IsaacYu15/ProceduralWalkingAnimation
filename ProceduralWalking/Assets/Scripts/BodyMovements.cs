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
    Vector3 averageFeet;

    public float swayAmount;
    float fraction;
    float t_sway;
    bool swayUp;

    private void Start()
    {
        feets = new Transform[feetCount];

        int i = 0;

        foreach (Transform child in feetParent)
        {
            if (child.name.Contains("Feet"))
            {
                feets[i] = child.transform;
                i++;
            }
        }
    }


    void Update()
    {
        //adjust height of spider body based on height of feet;
        for (int i = 0; i < feetCount; i ++)
        {
            averageFeet += feets[i].position;
        }

        averageFeet = averageFeet / feetCount;

        transform.position = new Vector3(transform.position.x, averageFeet.y + minHeightFromGround, transform.position.z);

        //body sway
        fraction += Time.deltaTime * 0.5f;

        if (swayUp)
        {
            t_sway = Mathf.Lerp(-Mathf.PI / 2, Mathf.PI / 2, fraction);

            if (fraction > 1)
            {
                swayUp = false;
                fraction = 0;
            }
        }
        else
        {
            t_sway = Mathf.Lerp(Mathf.PI / 2, -Mathf.PI / 2, fraction);

            if (fraction > 1)
            {
                swayUp = true;
                fraction = 0;
            }
        }

        body.rotation = new Quaternion (t_sway * swayAmount, body.rotation.y, body.rotation.z, body.rotation.w);


    }

}
