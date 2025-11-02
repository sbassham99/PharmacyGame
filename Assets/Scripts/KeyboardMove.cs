using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardMove : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        // Distance to move this frame based on which keys are down;
        float dx = 0;
        float dy = 0;

        // Which key is currently down?
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            dx = speed * Time.deltaTime; // Move up
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            dx = -speed * Time.deltaTime; // Move up
        }

        // Move by that amount in each dimension
        rb.position += new Vector2(dx, dy);
    }
}
