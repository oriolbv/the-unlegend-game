using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject HealthIndicator;
    private int lives = 3;

    public void UpdateHealthIndicator()
    {

    }

    #region Properties
    public int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
        }
    }

    #endregion
}
