
using UnityEngine;
using UnityEngine.Events;

public class GenericEventBehavior : MonoBehaviour
{
    public UnityEvent triggerEnterEvent, triggerExitEvent, mouseDownEvent;

    public void OnTriggerEnter2D(Collider2D other)
    {
        triggerEnterEvent.Invoke();
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        triggerExitEvent.Invoke();
    }

    public void OnMouseDown()
    {
        mouseDownEvent.Invoke();
        // print("click");
    }
}
