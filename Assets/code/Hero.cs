using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hero : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float turnSpeed = 3f;

    public Dictionary<string, int> items = new Dictionary<string, int>();
    public bool isCovered = false;
    public bool isDead = false;

    public TextMeshProUGUI screen;

    float startTime;

    // for jump
    public Vector3 jump;
    public float jumpForce = 2.5f;
    public bool isGrounded; // so you cant double jump
    Rigidbody rb;

    //sound effect
    public AudioSource[] sounds;
    public AudioSource runningSrc;
    public AudioSource jumpSrc;
    public AudioSource landingSrc;

    bool isSoundPlaying = false;

    void Start()
    {
        // ToDo: add game BGM. Not sure if we should add it here.
        startTime = Time.time;
        screen.text = "Press AWSD to move around\nPress left mouse key and move mouse to turn around\nPress right mouse key to sprint (if you take sprint item)";
        screen.fontSize = 50;
        StartCoroutine(TurnOffInstructions());

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        // sound effects
        sounds = GetComponents<AudioSource>();

        runningSrc = sounds[0]; // from https://freesound.org/people/Disagree/sounds/433725/
        jumpSrc = sounds[1]; // from https://pixabay.com/sound-effects/fast-simple-chop-5-6270/
        landingSrc = sounds[2]; // from https://pixabay.com/sound-effects/human-impact-on-ground-6982/
        
    }

    void Update()
    {
        // life check
        if (isDead)
        {
            // I believe this should go to user interface system once its done
            screen.text = "Game Over"; // can give more lifes
        }

        /* rotation */
        if (Input.GetKey(KeyCode.Mouse0))
        {
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
            if (!isSoundPlaying && isGrounded) {
                runningSrc.Play();
                isSoundPlaying = true;
            }
        }

        if (Input.GetKey("s"))
        {
            transform.position = transform.position - distance * transform.forward;
            if (!isSoundPlaying && isGrounded) {
                runningSrc.Play();
                isSoundPlaying = true;
            }

        }

        if (Input.GetKey("a"))
        {
            transform.position = transform.position + Quaternion.AngleAxis(-90, Vector3.up) * transform.forward * distance;
            if (!isSoundPlaying && isGrounded) {
                runningSrc.Play();
                isSoundPlaying = true;
            }

        }

        if (Input.GetKey("d"))
        {
            transform.position = transform.position + Quaternion.AngleAxis(90, Vector3.up) * transform.forward * distance;
            if (!isSoundPlaying && isGrounded) {
                runningSrc.Play();
                isSoundPlaying = true;
            }

        }

        //doesnt play sound if no keys are down
        // prob a better way to do this??
        if(!Input.GetKey("d") && !Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("w") || !isGrounded){
            runningSrc.Stop();
            isSoundPlaying = false;
        }

        /* jump */
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            jumpSrc.Play();
        }

        if (!isGrounded) {
            landingSrc.Play();
        }

        


        moveSpeed = 6;
    }

    // I believe this should go to user interface system once its done
    IEnumerator TurnOffInstructions()
    {
        while (Time.time - startTime <= 4) {
            yield return null;
        } 
        screen.text = "";
        screen.fontSize = 200;
    }
}
