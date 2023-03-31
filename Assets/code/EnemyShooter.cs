using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ToDo: 
    In the scene, open a big window on the cafe wall and make a small room, put the robot Peter modeled there.
    Add a gun to the robot.
    Currently this script is added to the wall. Once added that, we should put the script to the robot.
    
    Besides, add red boarders on the ground to tell player in this region the hero will be shot.
    The region is a 60 x 25 rectangle next to the wall.
*/

public class EnemyShooter : MonoBehaviour
{
    public Transform hero;
    bool isHeroInSight = false;
    float startTime = 0;

    void Update()
    {
        float diffX = hero.position[0] - transform.position[0];
        float diffZ = hero.position[2] - transform.position[2];
        if (diffX <= 30 && diffX >= -30 && diffZ <= 25 && diffZ >= -25) {
            // ToDo: Turn(); // Once the robot model is added, turn the shooter to face the hero
            if (!isHeroInSight) {
                startTime = Time.time;
                isHeroInSight = true;
            }
        } else {
            isHeroInSight = false;
        }

        if (isHeroInSight && Time.time - startTime >= 1) {
            Shoot();
            startTime = Time.time;
        }
    }

    void Shoot() {
        // ToDo: Play Sound Effect
        print("shoot");
        if (!hero.gameObject.GetComponent<Hero>().isCovered) {
            hero.gameObject.GetComponent<Hero>().isDead = true; 
        }
    }
}
