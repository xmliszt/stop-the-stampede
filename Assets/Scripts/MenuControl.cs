using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void StartGame()
    {
        Invoke("Play", 2);
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
