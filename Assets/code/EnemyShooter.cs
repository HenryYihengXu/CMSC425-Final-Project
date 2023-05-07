using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // print("shoot");
        shootingSound.Play();
        
        if (!hero.isCovered) {
            hero.isDead = true; 
        }
    }
}
