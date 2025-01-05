using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource backgroundAudioSource;
    public AudioSource soundFXAudioSource;
    public AudioClip levelCompleteAudio;
    public AudioClip gameOverAudio;
    public AudioClip buttonClickAudio;

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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            PlayBackGroundMusic();
        }
        else
        {
            Destroy(gameObject);
        }

    }


    public void PlayBackGroundMusic()
    {
        if (backgroundAudioSource != null && backgroundAudioSource.clip != null && !backgroundAudioSource.isPlaying)
        {
            backgroundAudioSource.Play();
        }
    }

    public void PlayLevelCompleteAudio()
    {
        if(soundFXAudioSource != null && levelCompleteAudio != null)
        {
            soundFXAudioSource.PlayOneShot(levelCompleteAudio);
        }
    }

    public void PlayGameOverAudio()
    {
        if (soundFXAudioSource != null && gameOverAudio != null)
        {
            soundFXAudioSource.PlayOneShot(gameOverAudio);
        }
    }

    public void PlayButtonClickAudio()
    { 
        if (soundFXAudioSource != null && buttonClickAudio != null)
        {
            soundFXAudioSource.PlayOneShot(buttonClickAudio);
        }
    }
}
