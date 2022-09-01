using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] particleArray; 
    //need to get camera bounds for spawn range
    private float spawnRangeX = 5f;
    private float spawnPosZ = -.26f;
    private float startDelay = 1.5f; 
    private float spawnInterval = .20f; 

    void SpawnParticles()
    {
        var particleIndex  = Random.Range(0,particleArray.Length);
        var spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 13, spawnPosZ);
        var spawnRotation = new Quaternion(0,0,Random.Range(0, 360),Random.Range(0, 360));
        Instantiate(particleArray[particleIndex], spawnPosition, spawnRotation);
    /*
    public GameObject objectPrefab; // whatever you want to instantiate
    public Vector3 location; // place you want it
 
    GameObject newObject = Instantiate(objectPrefab, location, Quaternion.identity) as GameObject;  // instatiate the object
    newObject.transform.localscale = new Vector3(whatever.x, whatever.y, whatever.z); // change its local scale in x y z format
    */

    }

    public IEnumerator ParticleSpeed()
    {
        while (spawnInterval > 0)
        {
            yield return new WaitForSeconds(1);
            CutSpawnInterval(0.01f);
            // print(spawnInterval);
        }
    }

    private void Start()
    {
        InvokeRepeating("SpawnParticles", startDelay, spawnInterval);
        StartCoroutine("ParticleSpeed");
    }

    public void CutSpawnInterval(float time)
    {
        spawnInterval -= time;
    }
    
    
}
