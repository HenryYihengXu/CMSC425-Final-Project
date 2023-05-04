using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gun : MonoBehaviour
{

    public GameObject laser;
    public int currentAmmo, maxAmmo;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {

        if(currentAmmo > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentAmmo -= 1;
                laser.SetActive(true);
            }
            else
            {
                laser.SetActive(false);
            }
        }
    }
}
