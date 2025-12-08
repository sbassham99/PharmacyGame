using UnityEngine;
using TMPro;
public class TotalScore : MonoBehaviour
{
    public TextMeshProUGUI ScoreBox;
    static int currentScore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreBox.text = "Score: " + currentScore;
    }

    public static int UpdateScore(int scoreUpdate)
    {
        int testScore = currentScore;
        testScore += scoreUpdate;
        Debug.Log("Expected score: " + testScore);
        return currentScore += scoreUpdate;
        
    }

}
