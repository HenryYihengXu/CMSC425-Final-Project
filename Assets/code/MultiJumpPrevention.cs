using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiJumpPrevention : MonoBehaviour
{
    public Hero hero;
    
    void OnTriggerStay(Collider other)
    {
        if (!other.isTrigger)
        {
            hero.isGrounded = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger)
        {
            hero.isGrounded = false;
        }
    }
}