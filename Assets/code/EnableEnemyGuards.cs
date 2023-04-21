using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableEnemyGuards : MonoBehaviour
{
    public string tag;
    bool isTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hero") {
            if (isTriggered)
            {
                foreach (GameObject enemyGuard in GameObject.FindGameObjectsWithTag(tag))
                {
                    enemyGuard.GetComponent<EnemyGuard>().enabled = false;
                }
                isTriggered = !isTriggered;
            }
            else
            {
                foreach (GameObject enemyGuard in GameObject.FindGameObjectsWithTag(tag))
                {
                    enemyGuard.GetComponent<EnemyGuard>().enabled = true;
                }
                isTriggered = !isTriggered;
            }
            
        }
    }
}