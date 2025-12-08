using UnityEngine;

[CreateAssetMenu(fileName = "ScriptablePatient", menuName = "Scriptable Objects/ScriptablePatient")]
public class ScriptablePatient : ScriptableObject
{
    // Patient can be one of three options, which is chosen randomly.
    public string[] patientType = {"Green Alien", "Blue Alien"};


    // Returns a random index of the patientType array. Whatever int is returned will
    // be used to determine what sprite to give the patient. 
    public int GetPatientType()
    {
        //return Array.IndexOf(patientType, Random.Range(0, patientType.Length));
        return Random.Range(0, patientType.Length);

    }
    public string GetPatientTypeSr(int i)
    {
        // return string name of alien type
        return patientType[i];
    }
}
