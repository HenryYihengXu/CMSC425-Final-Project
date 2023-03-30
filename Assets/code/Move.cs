using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float moveSpeed = 6;
    float turnSpeed = 90 / 300f;
    public bool hasSprint = false;
    Vector3 mousePosition;
    
    void Start()
    {
        mousePosition = Input.mousePosition;
    }

    void Update()
    {
        float mouseDistance = Input.mousePosition.x - mousePosition.x;
        mousePosition = Input.mousePosition;

        transform.localRotation = Quaternion.AngleAxis(turnSpeed * mouseDistance, Vector3.up) * transform.localRotation;

        if (hasSprint && Input.GetKey(KeyCode.LeftShift)) {
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
