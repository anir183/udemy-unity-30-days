using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance { get; private set; }

    [Header("Scenes")]
    [SerializeField] private int mainSceneIndex;
    [SerializeField] private int menuSceneIndex;

    [Header("UIs")]
    [SerializeField] private GameObject controlsUI;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject winScreen;

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

        if (controlsUI != null && winScreen != null)
        {
            controlsUI.SetActive(true);
            winScreen.SetActive(false);
        }
    }

    public void enterMainScene()
    {
        SceneManager.LoadScene(mainSceneIndex);
    }

    public void enterMenuScene()
    {
        SceneManager.LoadScene(menuSceneIndex);
    }

    public void showWinScreen()
    {
        scoreText.text = "Collected all " + CollectableController.instance.score + " Carrots!";
        controlsUI.SetActive(false);
        winScreen.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
