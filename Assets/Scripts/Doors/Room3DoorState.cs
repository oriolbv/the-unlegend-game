using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3DoorState : ExtendedBehaviour
{
    public GameObject FloorButton1GameObject;
    public GameObject FloorButton2GameObject;
    public GameObject FloorButton3GameObject;

    private bool floorButton1Pressed;
    private bool floorButton2Pressed;
    private bool floorButton3Pressed;

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
    private void Update()
    {
        // Getting FloorButton instances
        floorButton1Pressed = FloorButton1GameObject.GetComponent<FloorButton>().IsPressed;
        floorButton2Pressed = FloorButton2GameObject.GetComponent<FloorButton>().IsPressed;
        floorButton3Pressed = FloorButton3GameObject.GetComponent<FloorButton>().IsPressed;

        // Check if all floor buttons are pressed by the different boxes placed in the room
        if (floorButton1Pressed && floorButton2Pressed && floorButton3Pressed & !doorOpened)
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
