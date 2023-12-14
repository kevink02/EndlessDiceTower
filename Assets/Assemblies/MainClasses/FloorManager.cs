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
        EventManager.Instance.OnCreateNewFloor += IncrementFloorNumber;
        EventManager.Instance.OnCreateNewFloor += AssignFighterPositions;
    }

    private void Start()
    {
        // Invoke when creating only the first floor
        EventManager.Instance.InitializeFighters(this, new EmptyArgs());

        // Invoke when creating any new floor
        EventManager.Instance.CreateNewFloor(this, new EmptyArgs());
        EventManager.Instance.ResetTurnQueue(this, new EmptyArgs());
    }

    private void OnDisable()
    {
        EventManager.Instance.OnCreateNewFloor -= IncrementFloorNumber;
        EventManager.Instance.OnCreateNewFloor -= AssignFighterPositions;
    }


    /*
     * Instance methods
     */
    private void IncrementFloorNumber(object sender, EventArgs eventArgs)
    {
        _currentFloor++;
        LevelUIManager.Instance.CurrentFloorText.UpdateText($"Floor {_currentFloor}");
    }

    private void AssignFighterPositions(object sender, EventArgs eventArgs)
    {
        BasicSingleton<FighterGenerator>.Instance.CurrentPlayerFighter.transform.position = LevelUIManager.Instance.PlayerPosition.transform.position;
        BasicSingleton<FighterGenerator>.Instance.CurrentEnemyFighter.transform.position = LevelUIManager.Instance.EnemyPosition.transform.position;
    }
}
