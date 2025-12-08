using UnityEngine;

public class RotateBottle : MonoBehaviour
{
    public float rotationSpeed = 210f;  // degrees per second
    public float maxRotation = 180f;   // total rotation
    bool shouldRotate = false;
    bool dropPills = false;
    float currentRotation = 0f;

    // Stuff to spawn pills from bottle
    //public int maxPills = 50; ending up taking this mechanic out
    int pillsSpawned = 0;
    public GameObject tray;
    public GameObject pill;
    Vector3 currentPosition;
    public AudioSource a;

    void Start()
    {
        // Find tray and get bottles rigidbody component
        tray = GameObject.FindWithTag("tray");
        currentPosition = transform.position;


    }
    void OnTriggerEnter2D(Collider2D tilter)
    {
        // Check it is correct collision
        if (tilter.CompareTag("tiltbottle"))
        {
            shouldRotate = true;
            dropPills = true;
        }
    }

    void OnTriggerExit2D(Collider2D tilter)
    {
        shouldRotate = false;
        dropPills = false;
        currentRotation = 0;       
    }

    void Update()
    {
        if (shouldRotate)
        {
            currentRotation += rotationSpeed * Time.deltaTime;
        }

        if (currentRotation > maxRotation)
        {
            currentRotation = maxRotation;
            shouldRotate = false;
        }
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);

        // Spawn pills if the bottle is upside down and above tray
        if (currentRotation == maxRotation && dropPills)
        {
            float movement = Vector3.Distance(transform.position, currentPosition);
            
            // if movement greater than 2, bottle was shaken
            if (movement > 2.0f)  // took out && pillsSpawned <= maxPills to add no limit to amount spawned
            {
                int pillsToSpawn = Random.Range(3, 7);              

                PlayAudio();
                // Get sprite bounds (world space)
                SpriteRenderer trayRenderer = tray.GetComponent<SpriteRenderer>();
                Bounds b = trayRenderer.bounds;

                for (int i = 0; i <= pillsToSpawn; i++)
                {
                    // Pick a random position inside the tray sprite area
                    float randomX = Random.Range(b.min.x, b.max.x);
                    float randomY = Random.Range(b.min.y, b.max.y);

                    // Keep Z consistent with tray
                    Vector3 spawnPos = new Vector3(randomX, randomY, tray.transform.position.z);

                    // add random rotation (this ended up not mattering)
                    Quaternion randomRot = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

                    // Spawn the pill
                    Instantiate(pill, spawnPos, randomRot, tray.transform);

                    pillsSpawned++;
                }
            }
            currentPosition = transform.position;
        }
    }

    void PlayAudio()
    {
        if(a.isPlaying == false)
        {
            // audio clip has white noise at the start, skip past it
            a.time = 0.9f;
            a.Play();
        }
    }
}
