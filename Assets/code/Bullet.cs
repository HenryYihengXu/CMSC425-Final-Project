using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
    }

    // bullet fizzles out
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    // destory enemy and bullet
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "EnemyGuard"){
            Destroy(other.gameObject); // this destroys the enemy
        }
        if (other.gameObject.name != "Hero"){
            Destroy(gameObject); // this destroys the enemy
        }

    }



}
