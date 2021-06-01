using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.SetText("Score: 0");
        highScore.SetText("High Score: " + PlayerPrefs.GetInt("high", 0));
    }

    // Update is called once per frame
    void Update()
    {
        int score = PlayerPrefs.GetInt("score", 0);
        int highscore = PlayerPrefs.GetInt("high", 0);
        if (score > highscore)
        {
            PlayerPrefs.SetInt("high", score);
        }
        scoreText.SetText("Score: " + score);
    }
}
