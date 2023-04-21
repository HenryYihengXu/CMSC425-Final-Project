using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuard : MonoBehaviour
{
    public Transform heroTransform;
    public float moveSpeed = 4f;

    void Start()
    {
        gameObject.GetComponent<EnemyGuard>().enabled = false;
        gameObject.tag = "GuardInCafe";
    }

    void Update()
    {
        /* rotation */
        transform.forward = heroTransform.position - transform.position;
        
        /* move */
        transform.position = transform.position + moveSpeed * Time.deltaTime * transform.forward;
    }
}
