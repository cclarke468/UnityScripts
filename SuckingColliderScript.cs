
using System.Collections.Generic;
using UnityEngine;

public class SuckingColliderScript : MonoBehaviour
{
    public List<MagnetBehavior> magnetizedObjects;

    private void OnTriggerEnter(Collider other)//on trigger, make collectable suck toward vacuum
    {
        if (!other.GetComponent<Collectable>() || other == null || !other.GetComponent<Collectable>().isActive) return;
        magnetizedObjects.Add(other.GetComponent<MagnetBehavior>());
        for (var index = 0; index < magnetizedObjects.Count; index++)
        {
            var item = magnetizedObjects[index];
            // print("index = " + index);
            // print(magnetizedObjects.Count);
            if (other != null && item.GetComponent<Collider>() != other) continue;
            item.StartCoroutine("MagnetCoroutine");
        }
    }


    private void OnTriggerExit(Collider other) //on trigger exit, return collectable to normal
    {
        // print(other.gameObject + " exited sucking radius");
        if (other == null && !magnetizedObjects.Contains(other.GetComponent<MagnetBehavior>())) return;
        for (var index = 0; index < magnetizedObjects.Count; index++)
        {
                var item = magnetizedObjects[index];
                item.StopCoroutine("MagnetCoroutine");
                item.StopMagnetForce();
                magnetizedObjects.Remove(other.GetComponent<MagnetBehavior>());
        }
    }

    // private void OnTriggerExit(Collider other)//on trigger exit, return collectable to normal
         // {
         //     for (int i = 0; i < magnetizedObjects.Count; i++)
         //     {
         //         if (other.GetComponent<Collider>() == other && item != null)
         //         {
         //             item.StopCoroutine("MagnetCoroutine");
         //             item.StopMagnetForce();
         //             magnetizedObjects.Remove(other.GetComponent<MagnetBehavior>()); 
         //         }
         //
         //         i++;
         //     }
         // }
     
    
}
