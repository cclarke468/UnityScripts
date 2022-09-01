
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RespawnBehavior : MonoBehaviour
{
    public List<GameObject> objects;
    // public List<GameObject> onScreenObjs;
    private float delay = 4.5f;
    public bool running = false;
    public Transform spawnPoint;
    private Vector3 tempVector3 = new Vector3(0,0,0);

    public GameObject RandomObj()
    {
        var randomObj = Random.Range(0, objects.Count);
        return objects[randomObj];
    }

    public IEnumerator SpawnWithDelay()
    {
        yield return new WaitForSeconds(delay);
        while(running)
        {
            var obj = RandomObj();
            bool onScreen = obj.GetComponent<IsOnScreen>().onScreen;
            if (!onScreen)
            {
                tempVector3.x = spawnPoint.position.x;
                tempVector3.y = obj.transform.position.y;
                obj.transform.position = tempVector3;
            }
            else if (onScreen)
            {
                continue; //returns to top of loop
            }

            yield return new WaitForSeconds(delay);
            if (delay >= 0.5)
            {
                delay -= 0.2f;
            }
        }
    }

    public void SetDelay(float var)
    {
        delay = var;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //for collision to work I had to add a Rigidbody 2d to all the objs...
        //but I didn't want the objs to interact with other objects, so I froze position and rotation for all of them
        //not sure what bugs this may lead to in the future, but for now it works
        
        // print(other.gameObject);
        if (other.gameObject.GetComponent<IsOnScreen>())
        {
            other.gameObject.GetComponent<IsOnScreen>().onScreen = true;
            // onScreenObjs.Add(other.gameObject);
            // print(other.gameObject);
        }
        else
        {
            // print(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<IsOnScreen>())
        {
            other.GetComponent<IsOnScreen>().onScreen = false;
            // onScreenObjs.Remove(other.gameObject);
            // print("ontriggerexit");
        }
    }

    public void RunSpawnCoroutine()
    {
        running = true;
        StartCoroutine(SpawnWithDelay());
        // print("on");
    }
    
    public void StopSpawnCoroutine()
    {
        running = false;
        StopCoroutine(SpawnWithDelay());
    }
}
