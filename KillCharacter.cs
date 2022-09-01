
using System;
using UnityEngine;
using UnityEngine.Events;

public class KillCharacter : MonoBehaviour
{
    public UnityEvent deathEvent;
    public void OnTriggerEnter2D(Collider2D other)
    {
        // print("trigger");
        if (!other.CompareTag("Player")) return;
        deathEvent.Invoke();
        // print("death");
    }
    
}
