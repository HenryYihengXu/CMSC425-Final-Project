using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ToDo: 
    In the scene, open a big window on the cafe wall and make a small room, put the robot Peter modeled there.
    Add a gun to the robot.
    Currently this script is added to the wall. Once added that, we should put the script to the robot.
    
    Besides, add red boarders on the ground to tell player in this region the hero will be shot.
    The region is a 100 x 25 rectangle next to the wall.
*/

public class EnemyShooter : MonoBehaviour
{
    public Hero hero;
    public float startTime;
    AudioSource shootingSound;

    void Start()
    {
        gameObject.GetComponent<EnemyShooter>().enabled = false;
        shootingSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.time - startTime >= 1) {
            Shoot();
            startTime = Time.time;
        }
    }

    void Shoot()
    {
        //print("shoot");
        shootingSound.Play();
        
        if (!hero.isCovered) {
            hero.isDead = true; 
        }
    }
}
