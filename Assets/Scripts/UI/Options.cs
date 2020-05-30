using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : ExtendedBehaviour
{
    public Slider MusicLevelSlider;
    public Slider EffectsLevelSlider;

    public AudioClip EnterAudioClip;
    public AudioClip ExitAudioClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = OptionsSingleton.Instance.EffectsLevel;

        MusicLevelSlider.value = OptionsSingleton.Instance.MusicLevel;
        EffectsLevelSlider.value = OptionsSingleton.Instance.EffectsLevel;
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
        OptionsSingleton.Instance.MusicLevel = MusicLevelSlider.value;
        OptionsSingleton.Instance.EffectsLevel = EffectsLevelSlider.value;

        // Go back to Menu
        audioSource.clip = EnterAudioClip;
        audioSource.Play();
        Wait(0.8f, () =>
        {
            SceneManager.LoadScene("MenuScene");
        });
    }
}
