using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayBehavior : MonoBehaviour
{
    public float delay = 3f;
    // private bool delayDone = false;
    private void Awake()
    {
        // delayDone = false;
    }

    public IEnumerator DelayAfterCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(true);
    }
    
    public IEnumerator DelayBeforeCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(true);
    }

    public void SetActiveAfterDelay(GameObject obj)
    {
        StartCoroutine(DelayAfterCoroutine(obj));
    }

    public void SetActiveBeforeDelay(GameObject obj)
    {
        StartCoroutine(DelayBeforeCoroutine(obj));
    }
    
}
