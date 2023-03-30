using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeTaken : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hero") {
            other.gameObject.GetComponent<Move>().hasSprint = true;
            Destroy(gameObject);
        }
    }
}
