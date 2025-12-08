using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PauseScript : MonoBehaviour
{
    public Image pauseBackground;
    public Button quit;
    public Button reset;
    bool isPaused = false;
    float secondsBetween = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseBackground.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Pause game
        if(Input.GetKeyDown(KeyCode.P) && isPaused == false)
        {
            pauseBackground.gameObject.SetActive(true);
            isPaused = true;                
   
        }

        if(isPaused)
            secondsBetween += Time.deltaTime;    


        // Unpause game
        if(Input.GetKeyDown(KeyCode.P) && secondsBetween > 0.25)
        {
            pauseBackground.gameObject.SetActive(false);
            isPaused = false;
            secondsBetween = 0;
        }        
    }

}
