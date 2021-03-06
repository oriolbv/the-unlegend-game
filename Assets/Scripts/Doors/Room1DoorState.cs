﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1DoorState : ExtendedBehaviour
{
    public GameObject FloorButtonGameObject;

    private bool floorButtonPressed;
    private bool doorOpened;

    [Header("Sound Effects")]
    private AudioSource audioSource;
    public AudioClip DoorOpenAudioClip;

    void Start()
    {
        doorOpened = false;

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = OptionsSingleton.Instance.EffectsLevel;
        audioSource.clip = DoorOpenAudioClip;
    }

    private void Update()
    {
        // Getting FloorButton instances
        floorButtonPressed = FloorButtonGameObject.GetComponent<FloorButton>().IsPressed;

        // Check if all floor buttons are pressed by the different boxes placed in the room
        if (floorButtonPressed && !doorOpened)
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
