using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKScript : MonoBehaviour
{
    public Transform body;
    public Transform Target;

    public StepAnimation stepAnim;

    public Transform EndOfBone2;
    public Transform EndOfBone1;

    public Transform[] bones;
    public int chainLength;
    public float limbLength;

    private void Start()
    {
        bones = new Transform[chainLength];

        int i = 0;

        foreach (Transform child in transform)
        {
            if (child.name.Contains("Limb"))
            {
                bones[i] = child.transform;
                i++;
            }
        }

        limbLength = Vector3.Distance(bones[0].position, bones[chainLength - 1].position);
    }


    void Update()
    {

        bones[1].position = Target.position;

        //use pythagorean theorm to calculate the height needed for the two limbs to meet at a point
        float t_base = Vector3.Distance(bones[0].position, bones[1].position) / 2;
        float t_side = Vector3.Distance(bones[0].position, EndOfBone1.position);
        float t_height = Mathf.Sqrt(Mathf.Pow(t_side, 2) - Mathf.Pow(t_base, 2));

        Vector3 vertex = (bones[0].position + bones[1].position) / 2 + Vector3.up * t_height;

        bones[1].LookAt(vertex);

        //have both bones look at the same point
        bones[0].LookAt(EndOfBone2.position);
        bones[1].LookAt(EndOfBone1.position);



    }

}
