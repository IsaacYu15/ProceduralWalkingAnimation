using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpider : MonoBehaviour
{
    public float moveSpeed;
    public Transform body;

    // Update is called once per frame
    void Update()
    {
        float horz = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        transform.position += ((-horz * body.transform.forward) + (-ver * body.transform.right)).normalized * moveSpeed * Time.deltaTime;
    }
}
