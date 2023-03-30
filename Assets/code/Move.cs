using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float moveSpeed = 6;
    // float turnSpeed = 90 / 300f;
    float turnSpeed = 90f;
    public bool hasSprint = false;
    Vector3 mousePosition;
    
    void Start()
    {
        mousePosition = Input.mousePosition;
    }

    void Update()
    {
        /* rotation */
        float degree = turnSpeed * Time.deltaTime;
        if (Input.GetKey("left"))
        {
            transform.forward = Quaternion.AngleAxis(-degree, Vector3.up) * transform.forward;
        }
        if (Input.GetKey("right"))
        {
            transform.forward = Quaternion.AngleAxis(degree, Vector3.up) * transform.forward;
        }

        // float mouseDistance = Input.mousePosition.x - mousePosition.x;
        // mousePosition = Input.mousePosition;
        // transform.localRotation = Quaternion.AngleAxis(turnSpeed * mouseDistance, Vector3.up) * transform.localRotation;

        /* move */
        if (hasSprint && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) {
            moveSpeed = 12;
        }

        float distance = moveSpeed * Time.deltaTime;

        if (Input.GetKey("w"))
        {
            transform.position = transform.position + distance * transform.forward;
        }

        if (Input.GetKey("s"))
        {
            transform.position = transform.position - distance * transform.forward;
        }

        if (Input.GetKey("a"))
        {
            transform.position = transform.position + Quaternion.AngleAxis(-90, Vector3.up) * transform.forward * distance;
        }

        if (Input.GetKey("d"))
        {
            transform.position = transform.position + Quaternion.AngleAxis(90, Vector3.up) * transform.forward * distance;
        }

        moveSpeed = 6;
    }
}
