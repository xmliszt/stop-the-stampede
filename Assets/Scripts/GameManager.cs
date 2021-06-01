using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text gameoverText;
    public Text finalScoreText;

    private void Start()
    {
        gameoverText.enabled = false;
        finalScoreText.enabled = false;
        PlayerPrefs.SetInt("score", 0);
    }
    public void GameOver()
    {
        gameoverText.enabled = true;
        finalScoreText.enabled = true;
        finalScoreText.text = "Your Final Score is: " + PlayerPrefs.GetInt("score", 0);
        Time.timeScale = 0;
    }

    public void GameStart()
    {
        gameoverText.enabled = false;
        finalScoreText.enabled = false;
        PlayerPrefs.SetInt("score", 0);
        Time.timeScale = 1;
    }
}
