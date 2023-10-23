using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : IManager
{
    /*
     * Instance variables
     */
    private int _currentFloor;
    [SerializeField]
    private TurnManager _turnManager;


    /*
     * Unity methods
     */
    private void Awake()
    {
        _currentFloor = 0;
        _turnManager.ResetState();
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
