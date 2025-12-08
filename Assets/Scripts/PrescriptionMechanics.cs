using UnityEngine;


// nightmare script
public class PrescriptionMechanics : MonoBehaviour
{
    public float speed = 4.5f;
    Rigidbody2D prescriptionPaper;
    SpriteRenderer fingerSR, paperSR, stampSR;
    GameObject gameFinger, patient, stamp, scriptWaypoint;
    bool removeFinger = false;
    float secondsTilFingerDespawn = 0;
    public Sprite greenHand, blueHand;
    GeneratePatientSprite GetSpriteType;
    public int alienColor, indexOfStruct = -1;
    GameObject moveScriptToFill, paper;
    public PrescriptionStruct[] scriptType;
    void Start()
    {
        prescriptionPaper = GetComponent<Rigidbody2D>();
        scriptWaypoint = GameObject.FindWithTag("scriptwaypoint");
        gameFinger = GameObject.FindWithTag("finger");
        moveScriptToFill = GameObject.FindWithTag("movescripttofill");
        paper = GameObject.FindWithTag("paper");

        //get access to finger and paper sprites, and type of sprite
        fingerSR  = transform.Find("finger").GetComponent<SpriteRenderer>();
        paperSR = paper.GetComponent<SpriteRenderer>();
        GetSpriteType = GetComponent<GeneratePatientSprite>();
        AssignFingerSprite(); // make finger green or blue
        SetScriptType();      // randomly select struct from array

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("scriptwaypoint"))
        {
            speed = 0.0f;
            removeFinger = true;
        }     
    }

    // Update is called once per frame
    void Update()
    {
        // move prescription object to the center of the dropoff screen. It will stop moving 
        // on collision trigger
        Vector2 delta = scriptWaypoint.transform.position - prescriptionPaper.transform.position;
        delta.Normalize();
        prescriptionPaper.position += delta * speed * Time.deltaTime;

        if (removeFinger)
        {
            secondsTilFingerDespawn += Time.deltaTime;
            if(secondsTilFingerDespawn > 1.5f)
            {
                fingerSR.enabled = false;
                if(Input.GetKeyDown("s"))
                    MoveScript();
            }
        }
    }

    void MoveScript()
    {
        // If stamp is green
        if(stamp = GameObject.FindWithTag("approve_stamped"))
        {
            paper.transform.position = moveScriptToFill.transform.position;
            paper.transform.localScale = new Vector3(0.6f, 0.7f, 1f);

            // check if approve stamp was correct choice and adjust score accordingly
            if(alienColor == scriptType[indexOfStruct].alienTypeThatTakesMed)
                TotalScore.UpdateScore(500);
            else
                TotalScore.UpdateScore(-500);
        }

        // If stamp is red
        if(stamp = GameObject.FindWithTag("rejected_stamped"))
        { 
            Destroy(gameObject);
            Destroy(patient);

            // check if rejection stamp was correct choice and adjust score accordingly
            if(alienColor == scriptType[indexOfStruct].alienTypeThatTakesMed)
                TotalScore.UpdateScore(-500);
            else
                TotalScore.UpdateScore(500);
        }
    }

    void AssignFingerSprite()
    {
        // Find patient at drop off
        patient = GameObject.FindWithTag("AtDropOff");
        GetSpriteType = patient.GetComponent<GeneratePatientSprite>();
        alienColor = GetSpriteType.patientType;
        if(alienColor == 0)
            fingerSR.sprite = greenHand;
        if(alienColor == 1)
            fingerSR.sprite = blueHand;
    }


    void SetScriptType()
    {
        // Randomly select a script from the array
        indexOfStruct = Random.Range(0, scriptType.Length);
        paperSR.sprite = scriptType[indexOfStruct].prescription;
        //paperSR.sprite = scriptType.prescription[indexOfStruct];
    }

}
