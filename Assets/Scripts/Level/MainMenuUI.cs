using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private const int firstLevel = 1;
    public Button playButton;
    public Button quitButton;

    private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void AddListeners()
    {
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
    }

    public void Play()
    {
        soundManager.PlayButtonClickAudio();
        SceneManager.LoadScene(firstLevel);
    }

    public void Quit()
    {
        soundManager.PlayButtonClickAudio();
        Application.Quit();
        Debug.Log("Game quit");
    }
}
