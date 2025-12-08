using UnityEngine;
using UnityEngine.SceneManagement;

// OVERRIDE SCRIPT IF THE CINEMACHINE CAMERA DECIDES TO NOT WORK IN BUILD
public class PlayGame : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
            SceneManager.LoadScene(1);
    }
}
