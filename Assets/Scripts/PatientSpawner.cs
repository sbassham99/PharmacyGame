using UnityEngine;

public class ClientSpawner : MonoBehaviour
{

    public GameObject patient;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // spawn a patient at start of the game
        SpawnPatient();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("patient") == null)
            SpawnPatient();
        
    }

    void SpawnPatient()
    {
        // Spawn patient
        Instantiate(patient, transform.position, transform.rotation);   
    }
}
