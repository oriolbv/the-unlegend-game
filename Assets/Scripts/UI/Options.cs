using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public void GoBackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ApplyChanges()
    {
        // Store changed settings into OptionsSingleton

        // Go back to Menu
        SceneManager.LoadScene("MenuScene");
    }
}
