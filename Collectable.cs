using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int value;
    public bool isBad = false;
    public int collectableForce = 7500;
    public bool isActive = true; //becomes false when hitting a destroy collectable collider to prevent missing reference exception
  
}
