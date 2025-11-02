using UnityEngine;

public class PillBottle : MonoBehaviour
{
    // Current bottle position in world
    public float bx = 6, by = 14, bz = 0;
    public Camera PillCamera;
    bool isDragging = false;
    Vector3 offset;

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - PillCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    void OnMouseUp()
    {
        // Return bottle to original position on table
        transform.position = new Vector3(bx, by, bz);
        isDragging = false;
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDragging)
        {
            transform.position = PillCamera.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
}
