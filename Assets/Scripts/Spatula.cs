using UnityEngine;

public class Spatula : MonoBehaviour
{
    public Camera PillCamera;
    bool isDragging = false;
    Vector3 offset;

    Rigidbody2D spatula;
    // This rotates the spatula when player picks it up
    Quaternion rotateSpat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotateSpat = Quaternion.identity;
        spatula = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - PillCamera.ScreenToWorldPoint(Input.mousePosition);
        
        // Rotate spatula
        rotateSpat = Quaternion.Euler(new Vector3(-15, -60, -90));
        transform.rotation = rotateSpat;
    }
    void OnMouseUp()
    {
        // Return spatula to original rotation
        rotateSpat = Quaternion.Euler(new Vector3(3, 0, -80));
        transform.rotation = rotateSpat;

        // Return spatula to original position on table
        // TODO: Don't mkae this hardcoded, seems bad long
        transform.position = new Vector3(-8, 9, 0);
        isDragging = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 mousePos = PillCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetPos = (Vector2)(mousePos + offset);
            spatula.MovePosition(targetPos);
        }
}
}
