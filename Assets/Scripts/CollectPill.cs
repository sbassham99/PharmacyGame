using UnityEngine;
// idea - undercover fbi agent doing in a terrible alien costume
public class CollectPill : MonoBehaviour
{
    public GameObject pill;
    int count = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        // make sure it was pill that collided
        if (col.gameObject.CompareTag("pill"))
        {
            pill = col.gameObject;
            count++;
            Debug.Log("Pills in container: " + count);

        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        // Check and see if any pills have fallen out of the collector
        // and decrement them from the count. Should also serve to reset
        // the count when the collector is emptied into a RX bottle
        if (col.gameObject.CompareTag("pill"))
        {
            count--;
            Debug.Log("Pills in container: " + count);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
