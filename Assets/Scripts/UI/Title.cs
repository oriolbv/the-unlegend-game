using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : ExtendedBehaviour
{
    public AudioClip EnterAudioClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = OptionsSingleton.Instance.EffectsLevel;
    }
    public void GoToGameMenu()
    {
        audioSource.clip = EnterAudioClip;
        audioSource.Play();
        Wait(0.8f, () =>
        {
            SceneManager.LoadScene("MenuScene");
        });
    }
}
