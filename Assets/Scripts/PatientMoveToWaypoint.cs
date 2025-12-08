using UnityEngine;


/* Patient will move to their designated waypoint at the drop off counter
until they hit the trigger and their speed is reduced to 0. This will flip
a flag to true that will tell the prescription mechanics script to fire
*/

public class PatientMoveToWaypoint : MonoBehaviour
{
    Rigidbody2D patientBody;
    public float speed = 4.0f;
    GameObject waypoint;
    bool patientAtDropoff = false;
    Camera DropOffCamera;
    public GameObject prescription;
    GameObject scriptSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        patientBody = GetComponent<Rigidbody2D>();
        waypoint = GameObject.Find("PatientWaypoint");
        DropOffCamera = GameObject.FindWithTag("dropoffcamera").GetComponent<Camera>();
        scriptSpawn = GameObject.FindWithTag("prescriptionspawner");
    }

    // Set speed to 0 if patient collides with another patient or the drop off counter
    void OnTriggerEnter2D(Collider2D col)
    {
        speed = 0.0f;
        
        if(col.gameObject.CompareTag("dropoff"))
        {
            patientAtDropoff = true;
            gameObject.tag = "AtDropOff";
        }
    }
    // Set speed back to 1 when out of trigger zone
    void OnTriggerExit2D(Collider2D col)
    {
        speed = 1.0f;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 delta = waypoint.transform.position - patientBody.transform.position;
        delta.Normalize();
        patientBody.position += delta * speed * Time.deltaTime;

        if(patientAtDropoff && DropOffCamera.enabled)
        {
            Instantiate(prescription, scriptSpawn.transform.position, transform.rotation);
            Debug.Log("Patient at dropoff");
            patientAtDropoff = false;
        }
    }

}
