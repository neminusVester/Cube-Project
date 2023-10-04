using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    [Header("Panels")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;

    [Header("Buttons")]
    [SerializeField] private Button retryButton;
    [SerializeField] private Button nextLevelButton;

    [SerializeField] private Text gemsText;


    private void Start()
    {
        GameEvents.Instance.OnPlayerStarted += StartGame;
        GameEvents.Instance.OnPlayerLose += PlayerLose;
        GameEvents.Instance.OnFinishTrigger += LevelCompleted;

        retryButton.onClick.AddListener(RestartLevelButton);
        nextLevelButton.onClick.AddListener(NextLevel);
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnPlayerStarted -= StartGame;
        GameEvents.Instance.OnPlayerLose -= PlayerLose;
        GameEvents.Instance.OnFinishTrigger -= LevelCompleted;
    }

    private void StartGame()
    {
        startPanel.SetInactive();
    }

    //Buttons functions
    private void RestartLevelButton()
    {
        GameEvents.Instance.PlayerRestartGame();
        losePanel.SetInactive();
        startPanel.SetActive();
        Time.timeScale = 1f;
    }

    private void NextLevel()
    {
        GameEvents.Instance.InstantiateNextLevel();
        winPanel.SetInactive();
        startPanel.SetActive();
        Time.timeScale = 1f;
    }

    private void PlayerLose()
    {
        Time.timeScale = 0f;
        losePanel.SetActive();
    }

    private void LevelCompleted()
    {
        Time.timeScale = 0f;
        winPanel.SetActive();
    }
}
