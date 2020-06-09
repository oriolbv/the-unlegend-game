using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToStartScene());
    }

    IEnumerator ToStartScene() 
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("StartScene");
    }
}
