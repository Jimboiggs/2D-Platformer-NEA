using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    //Rate of rotation in degrees per second
    [SerializeField] private float degreesPerSecond = 180f;
    //Wait time in seconds
    [SerializeField] private float waitTime = 1f;
    //Bool to dictate clockwise start
    [SerializeField] private bool clockwise = true;
    //Scale to be applied to rotation to make it start clockwise/anticlockwise
    private float directionScale = 1f;
    //Float of time to wait before swinging starts
    [SerializeField] private float initialDelay = 0f;

    void Start()
    {
        if (clockwise)
        {
            directionScale = 1f;
        }
        else
        {
            directionScale = -1f;
        }
        //Starts rotating on first frame
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        yield return new WaitForSeconds(initialDelay);
        while (true)
        {
            //Rotate 180 degrees clockwise in z axis
            yield return StartCoroutine(RotateByAngle(Vector3.forward, 180f * directionScale));
            

            //Waits for specified time
            yield return new WaitForSeconds(waitTime);

            //Rotate 180 degrees anticlockwise in z axis
            yield return StartCoroutine(RotateByAngle(Vector3.forward, -180f * directionScale));

            //Waits for specified time
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator RotateByAngle(Vector3 axis, float angle)
    {
        //Rotates the game object
        float targetAngle = Mathf.Abs(angle);
        float rotatedAngle = 0f;

        while (rotatedAngle < targetAngle)
        {
            float step = degreesPerSecond * Time.deltaTime;
            if (rotatedAngle + step > targetAngle)
            {
                //Avoids swing over-rotating
                step = targetAngle - rotatedAngle;
            }
            transform.Rotate(axis, Mathf.Sign(angle) * step);
            rotatedAngle += step;
            yield return null;
        }
    }
}
