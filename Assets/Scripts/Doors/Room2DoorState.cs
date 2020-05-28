using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2DoorState : MonoBehaviour
{
    public GameObject BlueEnemy1GameObject;
    public GameObject BlueEnemy2GameObject;
    public GameObject BlueEnemy3GameObject;

    private bool blueEnemy1Dead;
    private bool blueEnemy2Dead;
    private bool blueEnemy3Dead;


    // Update is called once per frame
    void Update()
    {
        // Getting FloorButton instances
        blueEnemy1Dead = BlueEnemy1GameObject == null ? true : false;
        blueEnemy2Dead = BlueEnemy2GameObject == null ? true : false;
        blueEnemy3Dead = BlueEnemy3GameObject == null ? true : false;

        // Check if all floor buttons are pressed by the different boxes placed in the room
        if (blueEnemy1Dead && blueEnemy2Dead && blueEnemy3Dead)
        {
            // Desactivate gameobject in order to open the door
            this.gameObject.SetActive(false);
        }
    }
}
