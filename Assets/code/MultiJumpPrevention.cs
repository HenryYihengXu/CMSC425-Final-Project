using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiJumpPrevention : MonoBehaviour
{
    public GameObject heroGameObject;
    Hero hero;

    void Start()
    {
        hero = heroGameObject.GetComponent<Hero>();
    }

    void OnTriggerStay(Collider other)
    {
        hero.isGrounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        hero.isGrounded = false;
    }
}
