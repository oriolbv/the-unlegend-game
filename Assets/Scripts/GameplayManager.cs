using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (GameState.Instance.IsFinished)
        {
            Debug.Log("Game finished");
            // Reproduce WINNING song and go to credits scene.

            
        }
    }
}
