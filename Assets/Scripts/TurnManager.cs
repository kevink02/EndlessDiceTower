using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : IManager
{
    /*
     * Instance variables
     */
    private Queue<DiceFighter> _fighterTurnQueue;


    /*
     * Unity methods
     */
    private void Awake()
    {
        _fighterTurnQueue = new Queue<DiceFighter>();
    }


    /*
     * Interface methods
     */
    public void ExecuteState()
    {
        throw new System.NotImplementedException();
    }

    public void NextState()
    {
        throw new System.NotImplementedException();
    }

    public void ResetState()
    {
        throw new System.NotImplementedException();
    }
}
