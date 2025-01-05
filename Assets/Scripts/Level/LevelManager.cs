using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    private int currentSceneIndex;
    public LevelUI levelUI;
    private const int mainMenuIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }


    public void LoadMainMenu() => SceneManager.LoadScene(mainMenuIndex);

    public void OnLevelComplete()
    {
        Debug.Log("LevelComplete");
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        int nextSceneIndex = currentSceneIndex + 1;
        int totalNumberOfScene = SceneManager.sceneCountInBuildSettings;

        if (nextSceneIndex < totalNumberOfScene)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            levelUI.ShowGameWinUI();
        }
    }

    public void OnPlayerDeath() => levelUI.ShowGameLoseUI();

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}