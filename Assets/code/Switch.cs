using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Transform hero;
    public EnableEnemyShooter shootArea;

    public float angleOn = -135f;
    public float angleOff = -45f;

    public float flapTime = 1f;

    Quaternion rotOn;
    Quaternion rotOff;

    float changeSign;

    bool isFlapping = false;
    bool isOff = true;

    private void Start()
    {
        rotOn = Quaternion.Euler(0, 0, angleOn);
        rotOff = Quaternion.Euler(0, 0, angleOff);
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, hero.position) <= 10)
        {
            if (isOff)
            {
                shootArea.GetComponent<Collider>().enabled = false;
            }
            else
            {
                shootArea.GetComponent<Collider>().enabled = true;
            }
            StartCoroutine(TurnOnOff());
        }
    }

    IEnumerator TurnOnOff()
    {
        if (isFlapping)
        {
            isOff = !isOff;
            changeSign = -changeSign;
            yield break;
        }

        isFlapping = true;

        float interpolationParameter;

        if (isOff)
        {
            interpolationParameter = 0;
            changeSign = 1;
        }
        else
        {
            interpolationParameter = 1;
            changeSign = -1;
        }

        while (isFlapping)
        {
            interpolationParameter = interpolationParameter + changeSign * Time.deltaTime / flapTime;

            if (interpolationParameter >= 1 || interpolationParameter <= 0)
            {
                interpolationParameter = Mathf.Clamp(interpolationParameter, 0, 1);

                isFlapping = false;
            }

            transform.localRotation = Quaternion.Lerp(rotOff, rotOn, interpolationParameter);

            yield return null;
        }

        isOff = !isOff;
    }
}
