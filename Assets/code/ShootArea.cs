using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArea : MonoBehaviour
{
    public EnemyShooter shooter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hero") {
            shooter.enabled = true;
            shooter.startTime = Time.time;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Hero") {
            shooter.enabled = false;
        }
    }
}
