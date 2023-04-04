using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class Cover : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hero") {
            other.gameObject.GetComponent<Hero>().isCovered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Hero") {
            other.gameObject.GetComponent<Hero>().isCovered = false;
        }
    }
}
