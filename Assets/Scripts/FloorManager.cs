using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : BasicSingleton<FloorManager>
{
    /*
     * Instance variables
     */
    private int _currentFloor;


    /*
     * Delegates
     */
    public event System.Action OnCreateNewFloor;


    /*
     * Unity methods
     */
    private new void Awake()
    {
        base.Awake();

        _currentFloor = 0;
    }

    private void OnEnable()
    {
        OnCreateNewFloor += IncrementFloorNumber;
    }

    private void Start()
    {
        OnCreateNewFloor?.Invoke();
    }

    private void OnDisable()
    {
        OnCreateNewFloor -= IncrementFloorNumber;
    }


    /*
     * Instance methods
     */
    private void IncrementFloorNumber()
    {
        _currentFloor++;
    }

    public override void SetSingletonInstance()
    {
        BasicSingleton<FloorManager>.Instance = this;
    }
}
