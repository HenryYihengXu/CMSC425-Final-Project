using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArea : MonoBehaviour
{
    public GameObject shooter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hero") {
            shooter.GetComponent<EnemyShooter>().enabled = true;
            shooter.GetComponent<EnemyShooter>().startTime = Time.time;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Hero") {
            shooter.GetComponent<EnemyShooter>().enabled = false;
        }
    }
}
