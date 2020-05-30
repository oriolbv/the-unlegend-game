using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : ExtendedBehaviour
{

    public AudioClip EnterAudioClip;
    public AudioClip ExitAudioClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = OptionsSingleton.Instance.EffectsLevel;
    }

    public void StartGame()
    {
        audioSource.clip = EnterAudioClip;
        audioSource.Play();
        Wait(0.8f, () =>
        {
            SceneManager.LoadScene("DungeonScene");
        });
    }

    public void GoToOptions()
    {
        audioSource.clip = EnterAudioClip;
        audioSource.Play();
        Wait(0.8f, () =>
        {
            SceneManager.LoadScene("OptionsScene");
        });
    }

    public void GoToCredits()
    {
        audioSource.clip = EnterAudioClip;
        audioSource.Play();
        Wait(0.8f, () =>
        {
            SceneManager.LoadScene("CreditsScene");
        });
    }

    public void ExitGame()
    {
        audioSource.clip = ExitAudioClip;
        audioSource.Play();
        Wait(0.8f, () =>
        {
            Application.Quit();
        });
    }
}
