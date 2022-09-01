using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventsBehavior : MonoBehaviour
{
    public UnityEvent triggerEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        triggerEnterEvent.Invoke();
    }
}
