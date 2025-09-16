using UnityEngine;
using UnityEngine.UI;

public class ShowHighestScore : MonoBehaviour
{
    public Text highestScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highestScoreText.text = "Highest Score: " + PlayerPrefs.GetInt("High Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
