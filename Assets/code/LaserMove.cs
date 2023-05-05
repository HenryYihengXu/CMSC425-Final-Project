using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    public float flapTime = 3f;
    public float range = 15;
    public int startDirection = 1;
    
    int direction = 1;
    float interpolationParameter = 0f;
    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }


    void Update()
    {
        interpolationParameter = interpolationParameter + direction * Time.deltaTime / flapTime;

        if (interpolationParameter >= 1 || interpolationParameter <= 0)
        {
            interpolationParameter = Mathf.Clamp(interpolationParameter, 0, 1);

            if (direction == 1)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
        }

        transform.localPosition = Vector3.Lerp(startPosition, startPosition + new Vector3(startDirection * range, 0, 0), interpolationParameter);

    }

    // void onTriggerEnter()
    // {

    // }
}
