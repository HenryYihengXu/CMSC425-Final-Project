using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    public float waitTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.GetComponent<Hero>()){

            StartCoroutine(Winning(waitTime, other.gameObject.GetComponent<Hero>()));
        }
    }

    // takes you to the outside terrain after 5 seconds
    IEnumerator Winning(float time, Hero hero)
    {
        yield return new WaitForSeconds(time);
 
        // Code to execute after the delay
        if (!hero.isDead) {
            SceneManager.LoadScene("WinLevel"); 
        }  
    }

}
