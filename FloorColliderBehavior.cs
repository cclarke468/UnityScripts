
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorColliderBehavior : MonoBehaviour
{
    //this script detects if any of the softbody colliders are in contact with the ground and only triggers
    //the exit event if all of them have left the ground
    public UnityEvent triggerEnterEvent, triggerExitEvent;
    public List<Collider2D> onGroundColliders;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        onGroundColliders.Add(other);
        triggerEnterEvent.Invoke();
        // print( onGroundColliders.Count + " in list");
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        onGroundColliders.Remove(other);
        if (onGroundColliders.Count <= 0)
        {
            triggerExitEvent.Invoke();
            // print("exit triggered");
        }
        // print(onGroundColliders.Count + " left in list");
    }
}
