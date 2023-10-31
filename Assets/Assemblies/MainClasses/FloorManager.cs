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
    private Text _floorText;
    private int _currentFloor;


    /*
     * Delegates
     */
    // Most delegates should be here to prevent risk of other classes' delegates invoking before these
    public event System.Action OnCreateFighters;
    public event System.Action OnQueueFighters;
    public event System.Action OnCreateNewFloor;


    /*
     * Unity methods
     */
    private void Awake()
    {
        if (_floorText == null)
        {
            throw new System.NullReferenceException("Floor text object is not set");
        }

        _currentFloor = 0;
    }

    private void OnEnable()
    {
        OnCreateNewFloor += IncrementFloorNumber;
    }

    private void Start()
    {
        // Invoke when creating only the first floor
        OnCreateFighters?.Invoke();
        OnQueueFighters?.Invoke();

        // Invoke when creating any new floor
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
}
