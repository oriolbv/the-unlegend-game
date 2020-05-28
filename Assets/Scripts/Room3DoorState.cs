using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3DoorState : MonoBehaviour
{
    public GameObject FloorButton1GameObject;
    public GameObject FloorButton2GameObject;
    public GameObject FloorButton3GameObject;

    private bool floorButton1Pressed;
    private bool floorButton2Pressed;
    private bool floorButton3Pressed;

    private void Update()
    {
        // Getting FloorButton instances
        floorButton1Pressed = FloorButton1GameObject.GetComponent<FloorButton>().IsPressed;
        floorButton2Pressed = FloorButton2GameObject.GetComponent<FloorButton>().IsPressed;
        floorButton3Pressed = FloorButton3GameObject.GetComponent<FloorButton>().IsPressed;

        // Check if all floor buttons are pressed by the different boxes placed in the room
        if (floorButton1Pressed && floorButton2Pressed && floorButton3Pressed)
        {
            // Desactivate gameobject in order to open the door
            this.gameObject.SetActive(false);
        }
    }
}
