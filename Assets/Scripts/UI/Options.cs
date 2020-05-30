using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : ExtendedBehaviour
{
    public AudioClip EnterAudioClip;
    public AudioClip ExitAudioClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void GoBackToMenu()
    {
        audioSource.clip = ExitAudioClip;
        audioSource.Play();
        Wait(0.8f, () =>
        {
            SceneManager.LoadScene("MenuScene");
        });
    }

    public void ApplyChanges()
    {
        // Store changed settings into OptionsSingleton

        // Go back to Menu
        audioSource.clip = EnterAudioClip;
        audioSource.Play();
        Wait(0.8f, () =>
        {
            SceneManager.LoadScene("MenuScene");
        });
    }
}
