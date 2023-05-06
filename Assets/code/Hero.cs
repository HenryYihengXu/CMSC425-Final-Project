using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    // shooting, on hero. For now??
    public Rigidbody bullet;
    public float bulletSpeed = 15;

    public GameObject gunTop;



    void Start()
    {
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
        
        gunTop = GameObject.Find("gunTop");
    }

    void Update()
    {
        // life check
        if (isDead)
        {
            moveSpeed = 0;
            jumpForce = 0;
            
            // I believe this should go to user interface system once its done

            screen.text = "Game Over. \n Press x to restart"; // can give more lifes
            if (Input.GetKey("x")) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        /* rotation */
        // if (Input.GetKey(KeyCode.Mouse0))
        // {
        transform.localRotation = Quaternion.AngleAxis(turnSpeed * Input.GetAxis("Mouse X"), Vector3.up) * transform.localRotation;
        Camera.main.transform.localRotation = Quaternion.AngleAxis(turnSpeed * Input.GetAxis("Mouse Y"), Vector3.left) * Camera.main.transform.localRotation;
        //}

        /* move */
        if (items.ContainsKey("Sprint") && Input.GetKey(KeyCode.Mouse1)) {
            moveSpeed *= 2; //changed from 12 to *2, bc it needs to stop at game over
        }

        // shooting
        if(Input.GetMouseButtonDown(0))
        {
            // relative position of gun cylinder, spawn bullet out of that

            Vector3 spawnPoint = gunTop.transform.position;

            Rigidbody p = Instantiate(bullet, spawnPoint + transform.forward, gunTop.transform.rotation);
            p.velocity = transform.forward * bulletSpeed;
        }

        float distance = moveSpeed * Time.deltaTime;

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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Bullet(Clone)") {
            isDead = true;
        }
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
