using UnityEngine;

public class ViewDropOff : MonoBehaviour
{
    public Camera mainCam;
    public Camera dropOffCam;
    public Camera pillCam;
    public string dropOffTag = "dropoff";
    public string pillTag = "pillcounter";

    // This will be instantiated to prevent player movement when camera has changed.
    public GameObject wallPrefab;
    GameObject LeftWall;
    GameObject RightWall;
    bool wallUp = false;

    void Start()
    {
        // setting the nonmain cameras to disabled here. There seems to be
        // a unity bug or something that is giving me grief
        dropOffCam.enabled = false;
        pillCam.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject other = col.gameObject;

        // Player is at dropoff
        if (other.CompareTag(dropOffTag) && !wallUp)
        {
            // Switch cameras
            dropOffCam.enabled = true;
            mainCam.enabled = false;
            // Create wall in front of player to freeze movement
            CreateWall();
        }

        // Player is trying to count pills
        if (other.CompareTag(pillTag) && !wallUp)
        {
            // Switch cameras
            pillCam.enabled = true;
            mainCam.enabled = false;
            // Create walls around player to prevent movement
            CreateWall();
        }

    }
    void Update()
    {
        // Player can press 's' on keyboard to switch back
        // to main camera. 
        if (!mainCam.enabled && Input.GetKeyDown("s"))
        {
            // Switch camera back to main camera
            pillCam.enabled = false;
            dropOffCam.enabled = false;
            mainCam.enabled = true;

            // Destroy wall to free movement and reset wallUp flag
            Destroy(LeftWall);
            Destroy(RightWall);
            wallUp = false;

        }
    }

    void CreateWall()
    {
        LeftWall = Instantiate(wallPrefab, transform.position + new Vector3(-1.0f, 0, 0),
                transform.rotation);
        RightWall = Instantiate(wallPrefab, transform.position + new Vector3(1.0f, 0, 0),
                transform.rotation);
        wallUp = true;
    }
}
