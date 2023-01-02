using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKScript : MonoBehaviour
{
    public Transform body;
    public Transform Target; //targets the feet which are upright
    public Transform EndOfBone2;
    public Transform EndOfBone1;
    public int chainLength;

    public Transform[] bones;

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


    public Vector3 averageVec (Vector3 pos1, Vector3 pos2)
    {
        Vector3 avgVec = new Vector3((pos1.x + pos2.x) / 2,
                                    (pos1.y + pos1.y) / 2,
                                    (pos1.z + pos2.z) / 2);


        return avgVec;
    }

    void Update()
    {
        bones[1].position = Target.position;

        //use pythagorean theorm to calculate the height needed for the two limbs to meet at a point
        float t_base = Vector3.Distance(bones[0].position, bones[1].position) / 2;
        float t_side = Vector3.Distance(bones[0].position, EndOfBone1.position);
        float t_height = Mathf.Sqrt (Mathf.Pow(t_side, 2) - Mathf.Pow(t_base, 2));

        Vector3 vertex = averageVec(bones[0].position, bones[1].position) + new Vector3(0, t_height);

        bones[1].LookAt(vertex);

        //have both bones look at the same point
        bones[0].LookAt(EndOfBone2.position);
        bones[1].LookAt(EndOfBone1.position);

    }

}
