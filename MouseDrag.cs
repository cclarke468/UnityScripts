using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private bool dragging = false;
    private float distance;
    public float offset = 1f;
    private float rayPoint_x;
    private float rayPoint_y;
    private float rayPoint_z;
    private Camera mainCamera;
    private Vector2 screenbounds;

    //I found part of this code on stackoverflow and changed a couple of things; I also found the boundary code in a unity tutorial
    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, mainCamera.transform.position);
        dragging = true;
        // Debug.Log("dragging =" + dragging);
    }
 
    void OnMouseUp()
    {
        dragging = false; 
    }

    private void Start()
    {
        rayPoint_z = transform.position.z;
        mainCamera = Camera.main;
        // print(mainCamera);
        screenbounds =
            mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        // print(screenbounds);
        // rayPoint_y = Mathf.Clamp(rayPoint_y, -100, 4);
    }

    private void SetBoundaries() //not working... but is this needed?
    {
        Vector3 viewPosition = transform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, screenbounds.x * -1, screenbounds.x);
        viewPosition.y = Mathf.Clamp(viewPosition.y, screenbounds.y * -1, screenbounds.y);
        transform.position = viewPosition;
    }

    void FixedUpdate() //trigger with unity action instead of if statement?
    {
        // SetBoundaries();
        if (dragging)
        {
            Ray rayCast = mainCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = rayCast.GetPoint(distance);
            rayPoint_x = rayPoint.x;
            rayPoint_x = Mathf.Clamp(rayPoint_x, -4f, 4f);
            rayPoint_y = rayPoint.y + offset; //offset to show more of hose above finger
            rayPoint_y = Mathf.Clamp(rayPoint_y, -6, 8f); //clamp creates y value boundary
            transform.position = new Vector3(rayPoint_x, rayPoint_y, rayPoint_z);
        }
    }
}
