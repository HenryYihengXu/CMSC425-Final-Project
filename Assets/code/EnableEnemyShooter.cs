using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableEnemyShooter : MonoBehaviour
{
    public List<EnemyShooter> shooters = new List<EnemyShooter>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hero")
        {
            foreach (EnemyShooter shooter in shooters)
            {
                shooter.enabled = true;
                shooter.startTime = Time.time;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Hero")
        {
            foreach (EnemyShooter shooter in shooters)
            {
                shooter.enabled = false;
                shooter.startTime = Time.time;
            }
        }
    }
}
