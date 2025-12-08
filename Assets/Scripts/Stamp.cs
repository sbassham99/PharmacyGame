using UnityEngine;
using System.Collections;

public class Stamp : MonoBehaviour
{
    public Camera DropOffCamera;
    public bool isDragging = false;
    Vector3 offset; // for mouse dragging
    Vector3 startPosition; // return stamp to original spot
    bool withinStampRange = false;
    Rigidbody2D stamp;
    public Sprite dropShadow, addShadow;
    SpriteRenderer sr;
    GameObject prescription; // will become the parent object of the stamp

    // Will instantiate Approved or Rejected on prescription paper
    public GameObject prefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        stamp = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - DropOffCamera.ScreenToWorldPoint(Input.mousePosition);
        sr.sprite = dropShadow;
    }
    void OnMouseUp()
    {
        // Return stamp to original position on table
        transform.position = startPosition;
        isDragging = false;
        sr.sprite = addShadow;
    }

    void OnTriggerEnter2D(Collider2D paper)
    {
        if (paper.gameObject.CompareTag("paper"))
        {
            withinStampRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D paper)
    {
        if(paper.gameObject.CompareTag("paper"))
        {
            withinStampRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = DropOffCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetPos = (Vector2)(mousePos + offset);
            stamp.MovePosition(targetPos);       
        }

        // Stamper mechanics
        if (Input.GetKeyDown(KeyCode.Space) && withinStampRange)
        {
            // find the prescription object
            prescription = GameObject.FindWithTag("paper");

            // reduce size of stamp to simulate it being pressed downwards onto the paper
            transform.localScale = new Vector3(0.3f, 0.3f, 1f);

            // Create stamp on paper
            GameObject stamped = Instantiate(prefab, transform.position, transform.rotation);
            stamped.transform.SetParent(prescription.transform);

            //TODO add stamp sound

            // add a delay so the stamp stays at a smaller scale for half a second
            // adding realism to stamp mechanic
            StartCoroutine(StampDelay());
        }
    }
    IEnumerator StampDelay()
    {
        // Wait for 1/2 second
        yield return new WaitForSeconds(0.5f);
        transform.localScale = new Vector3(0.6f, 0.6f, 1f);
    }
}
