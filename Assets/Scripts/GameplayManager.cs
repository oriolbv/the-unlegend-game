using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{

    [Header("Sound Effects")]
    private AudioSource audioSource;

    public AudioClip MainMusicAudioClip;
    public AudioClip BossMusicAudioClip;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = OptionsSingleton.Instance.MusicLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.Instance.IsFinished)
        {
            Debug.Log("Game finished");
            // Reproduce WINNING song and go to credits scene.
        }
    }

    public void ReproduceMainMusic()
    {
        audioSource.clip = MainMusicAudioClip;
        audioSource.Play();
    }

    public void ReproduceBossMusic()
    {
        audioSource.clip = BossMusicAudioClip;
        audioSource.Play();
    }
}
