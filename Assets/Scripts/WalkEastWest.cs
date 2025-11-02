using UnityEngine;

public class WalkEastWest : MonoBehaviour
{
    Animator animator; // Link to this object's Animation Controller component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Start walk east animation by setting direction parameter used by animator
        // Or by using trigger parameters set on corresponding transitions
        if (Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetInteger("direction", 1);
            //animator.SetTrigger("east");
        }
        // Start walk west animation
        if (Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetInteger("direction", 2);
            //animator.SetTrigger("west");
        }
    }
}
