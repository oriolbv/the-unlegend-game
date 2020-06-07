using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _ga;
    
    public static GameAssets ga
    {
        get
        {
            if (_ga == null) _ga = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _ga;
        }
    }

    public Transform prefabChatBubble;
}
