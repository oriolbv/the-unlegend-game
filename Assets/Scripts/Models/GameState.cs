 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : Singleton<GameState>
{
    private bool _isFinished;

    public GameState()
    {
    }

    public void initGameScore()
    {
        _isFinished = false;
    }

    // Properties
    public bool IsFinished
    {
        get
        {
            return _isFinished;
        }
        set
        {
            _isFinished = value;
        }
    }
}

