using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterGenerator : BasicSingleton<FighterGenerator>
{
    /*
     * Instance methods
     */
    public override void SetSingletonInstance()
    {
        BasicSingleton<FighterGenerator>.Instance = this;
    }
}
