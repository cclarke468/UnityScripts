using System.Collections;
using UnityEngine;

public class MagnetBehavior : MonoBehaviour
{
    public GameObject Magnet;
    public Rigidbody collectableRB;
    private float forceFactor = 7500;
    void Awake()
    {
        collectableRB = GetComponent<Rigidbody>();
    }
    private IEnumerator MagnetCoroutine()
    {
        while (collectableRB != null)
        {
            collectableRB.AddForce((Magnet.transform.position - transform.position) * forceFactor * Time.deltaTime);
            // print("sucking");
            yield return new WaitForSeconds(.01f);
        }
    }

    public void StopMagnetForce()
    {
        collectableRB.velocity = new Vector3(0,0,0);
        collectableRB.angularVelocity = new Vector3(0, 0, 0);
        // print("Debug");
    }

    // void FixedUpdate() //this is bad code
    // {
    //     magnetRB.AddForce((Time.deltaTime * Magnet.transform.position - transform.position) * forceFactor);
    // }
}
