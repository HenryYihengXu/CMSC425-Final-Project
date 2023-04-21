using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform hero;

    public float angleOpened = -110f;
    public float angleClosed = 0f;

    public float flapTime = 1.5f;

    Quaternion rotOpened;
    Quaternion rotClosed;

    float changeSign;

    bool isFlapping = false;
    bool isClosed = true;

    private void Start()
    {
        rotOpened = Quaternion.Euler(0, angleOpened, 0);
        rotClosed = Quaternion.Euler(0, angleClosed, 0);
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, hero.position) <= 10)
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        if (isFlapping)
        {
            isClosed = !isClosed;
            changeSign = -changeSign;
            yield break;
        }

        isFlapping = true;

        float interpolationParameter;

        if (isClosed)
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

            transform.localRotation = Quaternion.Lerp(rotClosed, rotOpened, interpolationParameter);

            yield return null;
        }

        isClosed = !isClosed;
    }
}
