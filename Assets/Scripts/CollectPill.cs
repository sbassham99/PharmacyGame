using UnityEngine;
using TMPro;

/*
This script is attached to a collision box that is in the counting tray
pill catcher, so each time a pill is pushed into the holder, a count
is incremented by one. 

If a pill falls out, count is decremented by one

If the player puts 5 pills in the tray within a quick enough timespan,
they are rewarded extra points
*/

public class CollectPill : MonoBehaviour
{
    public TextMeshProUGUI pillCountText;
    public GameObject pill, wow, prescriptionPaper, patient, findPrescription;
    int countByFive, count;
    public CloseLid close;
    string pillTag = "pill";

    // get prescription info from here.
    PrescriptionMechanics prescriptionInfo;

    // track if player is counting by multiples of 5
    public float secondsSinceLast = 0.0f;
    public float secondsBetween = 0.3f;

    void OnTriggerEnter2D(Collider2D col)
    {
        // make sure it was pill that collided
        if (col.gameObject.CompareTag("pill"))
        {
            pill = col.gameObject;
            count++;
            countByFive++;
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
        }
    }

    void Update()
    {
        pillCountText.text = "Pills: " + GetPillCount();
        
        secondsSinceLast += Time.deltaTime;
        if(secondsSinceLast <= secondsBetween && countByFive == 5 && checkIfActiveScript()) 
        {
            // Play wow animation
            wow.SetActive(true);
            TotalScore.UpdateScore(100);
            Debug.Log("Counted by 5!");
            countByFive = 0;
            secondsSinceLast = 0;
        }

        // keep reseting secondsSinceLast if it goes over threshold
        if(secondsSinceLast > secondsBetween)
        {
            secondsSinceLast = 0;
            countByFive = 0;
        }

        // If player closes tray lid, adjust score accordingly and remove all pill objects
        if(close.isOpen == false)
        {
            // TODO: check for edge cases, like if the lid is closed without active script 
            // being filled. May be best to place this in CloseLid script

            //check with struct to make sure count is correct and update TotalScore
            CheckCountAndUpdateScore();
            // delete prescription after score has been handled, and delete patient at drop off
            DeletePrescriptionAndPatient();
            // delete all pillobjects, reset count
            DeletePillsAndResetCount(pillTag);
        }

    }



    public int GetPillCount()
    {
        return count;
    }

    // Finds reference to the prescription structure that is currently being counted
    // and after the tray is closed it will count the pills in the tray and compare
    // to expected count from prescription structure. 
    void CheckCountAndUpdateScore()
    {            
        prescriptionInfo = GetComponent<PrescriptionMechanics>();
        prescriptionPaper = GameObject.FindWithTag("Prescription");

        
        if (checkIfActiveScript())
            prescriptionInfo = prescriptionPaper.GetComponent<PrescriptionMechanics>(); 
        if(prescriptionInfo != null && prescriptionPaper != null)
        {
            // there is a bug here somewhere
            Debug.Log("in the if statement");           
            if(count == prescriptionInfo.scriptType[prescriptionInfo.indexOfStruct].pillQtyToCount)
            {
                Debug.Log("Count correct");
                TotalScore.UpdateScore(500);
            }
            else
            {
                Debug.Log("Count incorrect");
                TotalScore.UpdateScore(-500);
            }
        }
    }

    void DeletePillsAndResetCount(string tag)
    {
        // delete all pills first, may not need to reset count
        GameObject[] destroyPills = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject pill in destroyPills)
        {
            Destroy(pill);
        }
        
    }

    void DeletePrescriptionAndPatient()
    {
        // find reference to prescription object and patient at drop off and DESTROY THEM!
        patient = GameObject.FindWithTag("AtDropOff");
        if (patient != null && prescriptionPaper != null)
        {
        Destroy(patient);
        Destroy(prescriptionPaper);
        }
    }

    // Check if there is an active prescription in the world, this way you only get
    // the bonus points for counting by 5 if a prescription is active
    bool checkIfActiveScript()
    {
        findPrescription = GameObject.FindWithTag("Prescription");
        if(findPrescription != null)
            return true;
        return false;
    }
}


// 2 concept questions about NP-completeness and dynamic programming
// 2 application problems
    // here's an NP problem
    // here's a dynamic programming problem
