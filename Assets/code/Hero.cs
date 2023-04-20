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

    // for jump
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded; // so you cant double jump
    Rigidbody rb;



    void Start()
    {
        // ToDo: add game BGM. Not sure if we should add it here.
        startTime = Time.time;
        screen.text = "Press AWSD to move around\nPress left mouse key and move mouse to turn around\nPress right mouse key to sprint (if you take sprint item)";
        screen.fontSize = 50;
        StartCoroutine(TurnOffInstructions());

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        
    }

    /// for jump
    void OnCollisionStay(){
        isGrounded = true;
    }

    void Update()
    {
        // life check
        if (isDead) {
            screen.text = "Game Over"; // can give more lifes
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
        /* rotation */
        transform.localRotation = Quaternion.AngleAxis(turnSpeed * Input.GetAxis("Mouse X"), Vector3.up) * transform.localRotation;
        Camera.main.transform.localRotation = Quaternion.AngleAxis(turnSpeed * Input.GetAxis("Mouse Y"), Vector3.left) * Camera.main.transform.localRotation;
        }

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

        // jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        moveSpeed = 6;
    }

    // not sure if we should put it inside Hero
    IEnumerator TurnOffInstructions()
    {
        while (Time.time - startTime <= 4) {
            yield return null;
        } 
        screen.text = "";
        screen.fontSize = 200;
    }
}
