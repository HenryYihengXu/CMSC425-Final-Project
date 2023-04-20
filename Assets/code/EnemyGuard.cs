using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuard : MonoBehaviour
{
    public GameObject heroGameObject;
    float moveSpeed = 6f;

    void Start()
    {
        gameObject.GetComponent<EnemyGuard>().enabled = false;
    }

    void Update()
    {
        
    }
}
