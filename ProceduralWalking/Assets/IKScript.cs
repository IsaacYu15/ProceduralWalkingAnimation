using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKScript : MonoBehaviour
{
    public Transform Target;
    public Transform EndOfBone2;
    public Transform EndOfBone1;
    public int chainLength;

    public Transform[] bones;

    public float limbLength;

    private void Start()
    {
        bones = new Transform[chainLength];

        var curr = transform;

        for (var i = 0; i <= chainLength - 1; i++)
        {
            bones[i] = curr;
            
            foreach (Transform child in bones [i])
            {
                if (child.name.Contains ("Bone"))
                {
                    curr = child.transform;
                }  
            }
            
        }

        limbLength = Vector3.Distance(bones[0].position, bones[chainLength - 1].position);
    }

    void LateUpdate()
    {

        bones[1].LookAt(Target.position);

        if (Vector3.Distance(bones[0].position, Target.position) < limbLength && bones[2].position != Target.position)
        { 
            bones[2].position = Target.position;
        }

        bones[0].LookAt(EndOfBone2.position);

        if (EndOfBone1.position != EndOfBone2.position)
        {
            Vector3 offset = EndOfBone1.position - EndOfBone2.position;
            bones[2].position += offset;
        }

    }

}
