using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;
public class CameraSwap : MonoBehaviour
{
    public CinemachineCamera swapcamera; // Camera to swap in and out
    bool startGame = false;
    public float secondsBetween;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        swapcamera.Priority = 0; 
    }

    public void onClick()
    {
        Debug.Log("Test");
        swapcamera.Priority = 20;
        startGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(startGame)
        {
            secondsBetween += Time.deltaTime;
        }
        // start game after play button has been pressed and camera switch happens
        if(secondsBetween > 2)
        {
            SceneManager.LoadScene(1);
        }
    }

}
