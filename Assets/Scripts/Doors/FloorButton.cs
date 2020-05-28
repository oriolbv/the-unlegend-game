using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("box"))
        {
            isPressed = true;
        }
    }

    #region Properties
    public bool IsPressed
    {
        get
        {
            return isPressed;
        }
        set
        {
            isPressed = value;
        }
    }
    #endregion
}
