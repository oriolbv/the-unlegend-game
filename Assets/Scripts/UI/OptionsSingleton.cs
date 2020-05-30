using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsSingleton : Singleton<OptionsSingleton>
{
    private float musicLevel = 1;
    private float effectsLevel = 1;

    #region Properties
    public float MusicLevel
    {
        get
        {
            return musicLevel;
        }
        set
        {
            musicLevel = value;
        }
    }

    public float EffectsLevel
    {
        get
        {
            return effectsLevel;
        }
        set
        {
            effectsLevel = value;
        }
    }
    #endregion
}
