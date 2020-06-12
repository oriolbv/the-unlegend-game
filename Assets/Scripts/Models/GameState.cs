 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : Singleton<GameState>
{
    private bool _isGameStarted;
    private bool _isBossBattleStarted;
    private bool _isFinished;

    public GameState()
    {
    }

    public void initGameScore()
    {
        _isGameStarted = false;
        _isFinished = false;
        _isBossBattleStarted = false;
    }

    // Properties

    public bool IsGameStarted
    {
        get
        {
            return _isGameStarted;
        }
        set
        {
            _isGameStarted = value;
        }
    }

    public bool IsBossBattleStarted
    {
        get
        {
            return _isBossBattleStarted;
        }
        set
        {
            _isBossBattleStarted = value;
        }
    }


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

