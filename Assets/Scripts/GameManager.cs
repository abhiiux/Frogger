using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseIcon;
    [SerializeField] GameObject playIcon;
    [SerializeField] GameObject levelCompleteIcon;

    public void Won()
    {
        int score = CoinCollection.CoinScore;
        if(score >= 3)
        {
            levelCompleteIcon.SetActive(true);
        }
    }

    public void Restart()
    {
        Invoke(nameof(RestartScene), 2f);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause()
    {
        pauseIcon.SetActive(false);
        playIcon.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Play()
    {
        pauseIcon.SetActive(true);
        playIcon.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
