using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    [Header("Scenes")]
    [SerializeField] private int menuSceneIndex;
    [SerializeField] private int mainSceneIndex;

    [Header("UI References")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text endScoreText;
    [SerializeField] private GameObject endScreen;

    private int score = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        if (scoreText != null && endScoreText != null && endScreen != null)
        {
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Score: 0";
            endScoreText.text = "Score: 0";

            endScreen.SetActive(false);
        }
    }

    public void enterMainScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainSceneIndex);
        Time.timeScale = 1;
    }

    public void enterMenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(menuSceneIndex);
        Time.timeScale = 1;
    }

    public void enterEndState()
    {
        scoreText.gameObject.SetActive(false);
        endScreen.gameObject.SetActive(true);
    }

    public void incrScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        endScoreText.text = "Score: " + score;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
