/// <summary>
/// Manages the floors or levels of the game
/// </summary>
public class FloorManager : BasicSingleton<FloorManager>
{
    /*
     * Instance variables
     */
    private int _currentFloor;


    /*
     * Unity methods
     */
    private void Awake()
    {
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
