using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour

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

    // destory hero and bullet
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.GetComponent<Hero>()){
            other.gameObject.GetComponent<Hero>().isDead = true;
        }
        Destroy(gameObject); 


    }

}
