using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    float moveSpeed = 6f;
    float turnSpeed = 3f;
    public Dictionary<string, int> items = new Dictionary<string, int>();
    Vector3 mousePosition;
    
    void Start()
    {
        mousePosition = Input.mousePosition;
    }

    void Update()
    {
        /* rotation */
        transform.localRotation = Quaternion.AngleAxis(turnSpeed * Input.GetAxis("Mouse X"), Vector3.up) * transform.localRotation;

        /* move */
        if (items.ContainsKey("Sprint") && Input.GetKey(KeyCode.Mouse1)) {
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
