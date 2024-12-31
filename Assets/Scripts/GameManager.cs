using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseIcon;
    [SerializeField] GameObject playIcon;
    [SerializeField] GameObject levelCompleteIcon;
    [SerializeField] GameObject UiPanel;

    [SerializeField] PlayerMovement playerMovement;



    public void Won()
    {
        int score = CoinCollection.CoinScore;
        if(score >= 3)
        {
            playerMovement.stopFrog = true;
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
        Time.timeScale = 1f;
    }

    public void BackToStart()
    {
        SceneManager.LoadScene(0); // 0 is the start scene
    }

    public void Pause()
    {
        pauseIcon.SetActive(false);
        playIcon.SetActive(true);
        Time.timeScale = 0f;

        UiPanel.SetActive(true);
    }

    public void Play()
    {
        pauseIcon.SetActive(true);
        playIcon.SetActive(false);
        Time.timeScale = 1f;

        UiPanel.SetActive(false);
    }

    public void NextButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
