using UnityEngine;

public class GeneratePatientSprite : MonoBehaviour
{
    public ScriptablePatient patientObject;
    //0: Green Alien. 1: Blue Alien. 
    public int patientType = -1;
    // These three strings will be used to find the correct body part to assign sprite to
    public string patientHead = "PatientHead";
    public string patientBody = "PatientBody";
    public string patientLower = "PatientLower";

    public Sprite[] greenAlienHead;
    public Sprite[] greenAlienBody;
    public Sprite[] greenAlienLower; 

    public Sprite[] blueAlienHead;
    public Sprite[] blueAlienBody;
    public Sprite[] blueAlienLower; 

    SpriteRenderer srHead, srBody, srLower;
   
    void Start()
    {
        FindChildren();
        patientType = patientObject.GetPatientType();
        //Debug.Log(patientObject.GetPatientTypeSr(patientType));

        // Select from array of green sprites if patient type 1
        if (patientType == 0)
            SelectFromGreen();
        // Select from array of blue sprites if patient type 2
        if (patientType == 1)
            SelectFromBlue();
        
    }

    // Patient prefab has 3 gameobjects connected to it, where each object
    // is a different part of the body. This will hopefully allow me to randomly
    // select what sprite each part of the body has. No idea how this will go with animation
    void FindChildren()
    {
        srHead  = transform.Find(patientHead).GetComponent<SpriteRenderer>();
        srBody  = transform.Find(patientBody).GetComponent<SpriteRenderer>();
        srLower = transform.Find(patientLower).GetComponent<SpriteRenderer>();

    }

    void SelectFromGreen()
    {
        srHead.sprite = greenAlienHead[Random.Range(0, greenAlienHead.Length)];
        srBody.sprite = greenAlienBody[Random.Range(0, greenAlienBody.Length)];
        srLower.sprite = greenAlienLower[Random.Range(0, greenAlienLower.Length)];
    }
    void SelectFromBlue()
    {
        srHead.sprite = blueAlienHead[Random.Range(0, blueAlienHead.Length)];
        srBody.sprite = blueAlienBody[Random.Range(0, blueAlienBody.Length)];
        srLower.sprite = blueAlienLower[Random.Range(0, blueAlienLower.Length)];
    }    

    public int ReturnPatientType()
    {
        return patientType;
    }
}
