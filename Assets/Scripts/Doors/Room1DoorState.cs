using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1DoorState : MonoBehaviour
{
    public GameObject FloorButtonGameObject;

    private bool floorButtonPressed;

    private void Update()
    {
        // Getting FloorButton instances
        floorButtonPressed = FloorButtonGameObject.GetComponent<FloorButton>().IsPressed;

        // Check if all floor buttons are pressed by the different boxes placed in the room
        if (floorButtonPressed)
        {
            // Desactivate gameobject in order to open the door
            this.gameObject.SetActive(false);
        }
    }
}
