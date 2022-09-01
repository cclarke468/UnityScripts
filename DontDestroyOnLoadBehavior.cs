
using UnityEngine;

public class DontDestroyOnLoadBehavior : MonoBehaviour
{
    void Awake()
    {
        if (FindObjectsOfType<AudioBehavior>().Length < 2)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
