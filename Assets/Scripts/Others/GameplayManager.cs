using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : ExtendedBehaviour
{

    [Header("Sound Effects")]
    private AudioSource audioSource;

    public AudioClip MainMusicAudioClip;
    public AudioClip BossMusicAudioClip;
    public AudioClip WinMusicAudioClip;


    private bool _bossBattleAlreadyStarted;
    private bool _finished;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = OptionsSingleton.Instance.MusicLevel;

        ReproduceMainMusic();

        _bossBattleAlreadyStarted = false;
        _finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.Instance.IsBossBattleStarted && !_bossBattleAlreadyStarted)
        {
            _bossBattleAlreadyStarted = true;
            ReproduceBossMusic();
        }
        else if (GameState.Instance.IsFinished && !_finished)
        {
            Debug.Log("Game finished");
            _finished = true;
            // Reproduce WINNING song and go to credits scene.
            ReproduceWinMusic();
            Wait(2f, () => {
                SceneManager.LoadScene("CreditsScene");
            });
        }
    }

    public void ReproduceMainMusic()
    {
        audioSource.clip = MainMusicAudioClip;
        audioSource.Play();
    }

    public void ReproduceBossMusic()
    {
        audioSource.Stop();
        audioSource.clip = BossMusicAudioClip;
        audioSource.Play();
    }

    public void ReproduceWinMusic()
    {
        audioSource.loop = false;
        audioSource.clip = WinMusicAudioClip;
        audioSource.Play();
    }
    

}
