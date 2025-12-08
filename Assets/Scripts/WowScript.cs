using UnityEngine;

public class WowScript : MonoBehaviour
{
    float secondsSinceLast = 0.0f;

    void Update()
    {
        // object not active by default. If player counts by 5, the object will 
        // become active
        if(gameObject.activeInHierarchy)
        {
            secondsSinceLast += Time.deltaTime;
            if(secondsSinceLast > 1)
            {
                gameObject.SetActive(false);
                secondsSinceLast = 0;
            }
        }
    }
}
