using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    public Material laser1;
    public Material laser2;
    bool isLaser1 = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLaser1)
        {
            GetComponent<MeshRenderer>().material = laser2;
            isLaser1 = !isLaser1;
        }
        else
        {
            GetComponent<MeshRenderer>().material = laser1;
            isLaser1 = !isLaser1;
        }
    }
}
