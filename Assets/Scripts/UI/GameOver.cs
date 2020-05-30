using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : ExtendedBehaviour
{
    public AudioClip EnterAudioClip;
    public AudioClip ExitAudioClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = OptionsSingleton.Instance.EffectsLevel;
    }

    public void BackToMenu()
    {
        audioSource.clip = ExitAudioClip;
        audioSource.Play();
        Wait(0.8f, () =>
        {
            SceneManager.LoadScene("StartScene");
        });
    }

    public void RestartGame()
    {
        audioSource.clip = EnterAudioClip;
        audioSource.Play();
        Wait(0.8f, () =>
        {
            SceneManager.LoadScene("DungeonScene");
        });
    }
}
