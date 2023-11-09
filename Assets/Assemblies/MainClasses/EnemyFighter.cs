using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : DiceFighter
{
    /*
     * Unity methods
     */
    private new void Awake()
    {
        base.Awake();
    }

    private new void Start()
    {
        base.Start();
    }


    /*
     * Instance methods
     */
    public override void StartTurn()
    {
        throw new System.NotImplementedException();
    }

    public override void DoTurn()
    {
        throw new System.NotImplementedException();
    }

    public new void EndTurn()
    {
        base.EndTurn();
    }
}
