using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUI : MonoBehaviour
{
    public GameObject levelPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button menuButton;
    public LevelManager levelManager;
    public int levelNumber = 1;
    private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLevelText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        AddListeners();
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level: " + levelNumber;
    }

    private void HideLevelPanel()
    {
        levelPanel.SetActive(false);
    }

    private void SetGameOverPanel(bool isActive)
    {
        gameOverPanel.SetActive(isActive);
    }

    private void AddListeners()
    {
        menuButton.onClick.AddListener(MainMenuButton);
        restartButton.onClick.AddListener(RestartButton);
    }

    private void MainMenuButton()
    {
        soundManager.PlayButtonClickAudio();
        levelManager.LoadMainMenu();
    }

    private void RestartButton()
    {
        soundManager.PlayButtonClickAudio();
        Debug.Log("Restart button clicked!");
        levelManager.RestartLevel();
    }

    public void ShowGameWinUI()
    {
        SetGameOverPanel(true);

        gameOverText.text = "Game Completed!!";
        gameOverText.color = Color.green;
        HideLevelPanel();
    }

    public void ShowGameLoseUI()
    {
        SetGameOverPanel(true);

        gameOverText.text = "Game Over!!";
        gameOverText.color = Color.red;
        HideLevelPanel();
    }
}
