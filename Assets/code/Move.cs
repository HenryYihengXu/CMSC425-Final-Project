using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    float moveSpeed = 6;
    float turnSpeed = 90;

    
    void Start()
    {
        transform.forward = Camera.main.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = moveSpeed * Time.deltaTime;
        float degree = turnSpeed * Time.deltaTime;
        if (Input.GetKey("a"))
        {
            transform.forward = Quaternion.AngleAxis(-degree, Vector3.up) * transform.forward;
            Debug.Log("a pressed");
        }

        if (Input.GetKey("d"))
        {
            transform.forward = Quaternion.AngleAxis(degree, Vector3.up) * transform.forward;
            Debug.Log("a pressed");
        }

        if (Input.GetKey("up"))
        {
            transform.position = transform.position + distance * transform.forward;
        }

        if (Input.GetKey("down"))
        {
            transform.position = transform.position - distance * transform.forward;
        }
    }
}
