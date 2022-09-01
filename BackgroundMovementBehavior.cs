using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovementBehavior : MonoBehaviour
{
    public float currentSpeed = 0f, startSpeed = 0.1f, maxSpeed = 100f;
    public float delay = 3f, beginPlayDelay = 3f;
    // private float 
    // private bool isRunning = true;
    private void Start()
    {
        currentSpeed = 0;
        // print("start");
        StartCoroutine(StartWithDelay());
        
        // StopCoroutine(StartWithDelay(delay));
    }

    private void FixedUpdate()
    {
        TranslateLeft();
    }

    private void TranslateLeft()
    {
        // print("moveleft running");
        transform.Translate(Time.deltaTime * currentSpeed * Vector3.left, Space.World); //using translate means no physics, so the boundaries are ignored
    }

    public IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(delay);
        currentSpeed = startSpeed;
        delay = beginPlayDelay;
        StartCoroutine(SpeedUp());
    }

    public void GameOver()
    {
        StopCoroutine(SpeedUp());
        delay = 1f;
        StartCoroutine(SlowDown());
    }
    public IEnumerator SlowDown()
    {
        while (currentSpeed > 0.1)
        {
            currentSpeed /= 2;
            // print("slowing");
            delay *= .5f;
            yield return new WaitForSeconds(delay);
        }
        currentSpeed = 0;
        // print("stopped");
        StopAllCoroutines();
    }

    public IEnumerator SpeedUp()
    {
        StopCoroutine(SlowDown());
        while (currentSpeed < maxSpeed)
        {
            currentSpeed *= 1.05f;
            // currentSpeed *= Mathf.Exp(1.5f);
            yield return new WaitForSeconds(delay);
            delay *= 0.99f;
        }
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }
}
