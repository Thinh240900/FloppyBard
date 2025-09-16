using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour {
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource audioSource;
    public AudioSource gameOverSound;

    private bool _isGameOver = false;
    
    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd = 1)
    {
        if (_isGameOver)
            return;
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        StartCoroutine(PlayPart());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        if (_isGameOver)
            return;
        _isGameOver = true;
        gameOverScreen.SetActive(true);
        if (playerScore > PlayerPrefs.GetInt("High Score", 0)){
            PlayerPrefs.SetInt("High Score", playerScore);
        }
        gameOverSound.Play();
    }
    
    System.Collections.IEnumerator PlayPart()
    {
        audioSource.time = 0.8f;
        audioSource.Play();
        yield return new WaitForSeconds(1.7f);
        audioSource.Stop();
    }
}
