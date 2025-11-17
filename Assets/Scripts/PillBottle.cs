using UnityEngine;

public class PillBottle : MonoBehaviour
{
    public Sprite dropShadow, addShadow;
    SpriteRenderer sr;
    // Current bottle position in world
    //public float bx = 6, by = 14, bz = 0;
    Vector3 startPosition;
    public Camera PillCamera;
    bool isDragging = false;
    Vector3 offset;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startPosition = transform.position;       
    }
    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - PillCamera.ScreenToWorldPoint(Input.mousePosition);
        sr.sprite = dropShadow;
    }
    void OnMouseUp()
    {
        // Return bottle to original position on table
        transform.position = startPosition;
        //transform.position = new Vector3(bx, by, bz);
        sr.sprite = addShadow;
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
