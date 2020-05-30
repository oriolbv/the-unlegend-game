using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesIndicator : MonoBehaviour
{

    public GameObject[] hearts;
    //private List<bool> heartsState;


    public Sprite EmptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        //foreach(GameObject heart in hearts)
        //{
        //    heartsState.Add(true);
        //}
    }

    public void UpdateLivesIndicator(int lives)
    {
        for (int i = 0; i < hearts.Length; ++i)
        {
            if (i > (lives - 1))
            {
                hearts[i].GetComponent<Image>().sprite = EmptyHeart;
            }
        }
    }
}
