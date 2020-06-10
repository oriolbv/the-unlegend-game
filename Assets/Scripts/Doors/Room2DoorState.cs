using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2DoorState : ExtendedBehaviour
{
    public GameObject BlueEnemy1GameObject;
    public GameObject BlueEnemy2GameObject;
    public GameObject BlueEnemy3GameObject;

    private bool blueEnemy1Dead;
    private bool blueEnemy2Dead;
    private bool blueEnemy3Dead;

    private bool doorOpened;

    [Header("Sound Effects")]
    private AudioSource audioSource;
    public AudioClip DoorOpenAudioClip;

    private void Start()
    {
        doorOpened = false;

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = OptionsSingleton.Instance.EffectsLevel;
        audioSource.clip = DoorOpenAudioClip;
    }
    void Update()
    {
        // Getting FloorButton instances
        blueEnemy1Dead = BlueEnemy1GameObject == null ? true : false;
        blueEnemy2Dead = BlueEnemy2GameObject == null ? true : false;
        blueEnemy3Dead = BlueEnemy3GameObject == null ? true : false;

        // Check if all floor buttons are pressed by the different boxes placed in the room
        if (blueEnemy1Dead && blueEnemy2Dead && blueEnemy3Dead && !doorOpened)
        {
            doorOpened = true;
            audioSource.Play();
            Wait(1.4f, () =>
            {
                // Desactivate gameobject in order to open the door
                this.gameObject.SetActive(false);
            });
        }
    }
}
