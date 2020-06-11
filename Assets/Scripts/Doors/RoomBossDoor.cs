using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBossDoor : ExtendedBehaviour
{
    public GameObject BossEnemyGameObject;

    private bool bossEnemyDead;

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
        bossEnemyDead = BossEnemyGameObject == null ? true : false;

        // Check if all floor buttons are pressed by the different boxes placed in the room
        if (bossEnemyDead && !doorOpened)
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
