using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the floors or levels of the game
/// </summary>
public class FloorManager : BasicSingleton<FloorManager>
{
    /*
     * Instance variables
     */
    [SerializeField]
    [Tooltip("The gameobjects that fighters will be positioned at in the scene view")]
    private GameObject _leftFighterPosition, _rightFighterPosition;
    [SerializeField]
    private Text _floorText;
    private int _currentFloor;


    /*
     * Delegates
     */
    // Most delegates should be here to prevent risk of other classes' delegates invoking before these
    public event EventHandler<EventArgs> OnInitializeFighters;
    public event EventHandler<EventArgs> OnCreateNewFloor;
    public event EventHandler<EventArgs> OnResetTurnQueue;


    /*
     * Unity methods
     */
    private void Awake()
    {
        if (_leftFighterPosition == null || _rightFighterPosition == null)
        {
            throw new NullReferenceException("Fighter position objects are not set");
        }
        if (_floorText == null)
        {
            throw new NullReferenceException("Floor text object is not set");
        }

        _currentFloor = 0;
    }

    private void OnEnable()
    {
        OnCreateNewFloor += IncrementFloorNumber;
        OnCreateNewFloor += AssignFighterPositions;
    }

    private void Start()
    {
        // Invoke when creating only the first floor
        OnInitializeFighters?.Invoke(this, new DummyArgs());

        // Invoke when creating any new floor
        OnCreateNewFloor?.Invoke(this, new DummyArgs());
        OnResetTurnQueue?.Invoke(this, new DummyArgs());
    }

    private void OnDisable()
    {
        OnCreateNewFloor -= IncrementFloorNumber;
        OnCreateNewFloor -= AssignFighterPositions;
    }


    /*
     * Instance methods
     */
    private void IncrementFloorNumber(object sender, EventArgs eventArgs)
    {
        _currentFloor++;
        _floorText.UpdateText($"Floor {_currentFloor}");
    }

    private void AssignFighterPositions(object sender, EventArgs eventArgs)
    {
        BasicSingleton<FighterGenerator>.Instance.CurrentPlayerFighter.transform.position = _leftFighterPosition.transform.position;
        BasicSingleton<FighterGenerator>.Instance.CurrentEnemyFighter.transform.position = _rightFighterPosition.transform.position;
    }
}
