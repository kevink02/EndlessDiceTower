using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : BasicSingleton<FloorManager>, ISingletonUser
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
    private new void Awake()
    {
        base.Awake();

        _currentFloor = 0;
        // _turnManager.ResetState();
    }


    /*
     * Interface methods
     */
    public ISingletonUser GetSingletonInstance()
    {
        return BasicSingleton<FloorManager>.Instance;
    }

    public void SetSingletonInstance()
    {
        BasicSingleton<FloorManager>.Instance = this;
    }
}
