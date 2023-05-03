using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    // target is the hero gameObject
    public GameObject target;

    void Update()
    {
        if (target != null)
        {
            // get the direction vector
            Vector3 direction = target.transform.position - transform.position;
            // get the rotation
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            // update the rotation of the transform to look at the hero
            transform.rotation = lookRotation;
        }
    }
}
