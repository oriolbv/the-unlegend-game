﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : ExtendedBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Wait(10f, () =>
        {
            SceneManager.LoadScene("MenuScene");
        });
    }
}
