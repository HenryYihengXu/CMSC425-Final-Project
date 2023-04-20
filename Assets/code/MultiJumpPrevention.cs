using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiJumpPrevention : MonoBehaviour
{
    public GameObject HeroGameObject;
    Hero hero;

    void Start()
    {
        hero = HeroGameObject.GetComponent<Hero>();
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
