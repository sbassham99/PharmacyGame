using UnityEngine;

public class ChangePillSize : MonoBehaviour
{
    public GameObject pill;
    bool hasSpawned = false;
    Vector3 scaleChange;

    void OnTriggerEnter2D(Collider2D col)
    {
        // make sure collision is from pill
        if (!col.gameObject.CompareTag("pill"))
            return;

        // if this is the first collision, it is from the pill spawning
        // therefore, do not change pill size
        if (!hasSpawned)
        {
            hasSpawned = true;
            return;
        }
        // Use the collided pill (or the public pill reference if you prefer)
        GameObject target = pill != null ? pill : col.gameObject;

        Vector3 current = target.transform.localScale;
        Vector3 newScale = current * 2f; // double size
        target.transform.localScale = newScale;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        // make sure collision is from pill
        if (!col.gameObject.CompareTag("pill"))
            return;

        GameObject target = pill != null ? pill : col.gameObject;

        Vector3 current = target.transform.localScale;
        Vector3 newScale = current * 0.5f; // half size
        target.transform.localScale = newScale;      
    }
}
