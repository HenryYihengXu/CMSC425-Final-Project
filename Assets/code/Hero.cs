using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hero : MonoBehaviour
{
    float moveSpeed = 6f;
    float turnSpeed = 3f;

    public Dictionary<string, int> items = new Dictionary<string, int>();
    public bool isCovered = false;
    public bool isDead = false;

    public TextMeshProUGUI screen;

    float startTime;

    void Start()
    {
        // ToDo: add game BGM. Not sure if we should add it here.
        startTime = Time.time;
        screen.text = "Press AWSD to move around\nUse mouse to turn around\nPress right mouse key to sprint (if you take sprint item)";
        screen.fontSize = 50;
        StartCoroutine(TurnOffInstructions());
        
    }

    void Update()
    {
        // life check
        if (isDead) {
            screen.text = "Game Over"; // can give more lifes
        }

        /* rotation */
        transform.localRotation = Quaternion.AngleAxis(turnSpeed * Input.GetAxis("Mouse X"), Vector3.up) * transform.localRotation;

        /* move */
        if (items.ContainsKey("Sprint") && Input.GetKey(KeyCode.Mouse1)) {
            moveSpeed = 12;
        }

        float distance = moveSpeed * Time.deltaTime;

        // ToDo: add running sound effect when a w s d is pressed.
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

    // not sure if we should put it inside Hero
    IEnumerator TurnOffInstructions()
    {
        while (Time.time - startTime <= 4) {
            print(1);
            yield return null;
        } 
        print(2);
        screen.text = "";
        screen.fontSize = 200;
    }
}
