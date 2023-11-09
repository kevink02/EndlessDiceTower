using UnityEngine;

public abstract class DiceFighter : MonoBehaviour, IDiceRoller
{
    /*
     * Instance variables
     */
    [SerializeField]
    private DiceFighterAssets _diceRollerAssets;
    [SerializeField]
    private ElementType _elementType;
    [SerializeField]
    private RollableDie[] _rollableDice;
    private int _currentHealth;
    private int _maxHealth;


    /*
     * Constant variables
     */
    private const int MaxDicePerFighter = 3;


    /*
     * Properties
     */
    protected DiceFighterAssets FighterAssets
    {
        get
        {
            return _diceRollerAssets;
        }
    }
    protected RollableDie[] FighterDice
    {
        get
        {
            return _rollableDice;
        }
    }


    /*
     * Delegates
     */
    public static event System.Action OnFighterTurnEnd;


    /*
     * Unity methods
     */
    protected void Awake()
    {
        if (FighterAssets)
        {
            GetComponent<SpriteRenderer>().sprite = FighterAssets.FighterTexture;
        }
        if (_elementType == null)
        {
            throw new System.NullReferenceException("Element type is not set");
        }

        _maxHealth = 100;
        _currentHealth = _maxHealth;
    }

    protected void Start()
    {
    }


    /*
     * Instance methods
     */
    public abstract void StartTurn();

    public abstract void DoTurn();

    public void EndTurn()
    {
        Debug.Log($"{name}: Ending turn...");
        OnFighterTurnEnd?.Invoke();
    }

    public abstract void DoAttack();


    /*
     * Interface methods
     */
    public void RollDie(int index)
    {
        if (FighterDice != null && index >= 0 && index < FighterDice.Length && FighterDice[index])
        {
            FighterDice[index].SetRolledValue();
            Debug.Log($"{name}: Rolled a {FighterDice[index].GetRolledValue()} on die #{index}");
            FighterDice[index].PlayAnimation();
        }
    }

    public void RollAllDice()
    {
        for (int i = 0; i < MaxDicePerFighter; i++)
        {
            RollDie(i);
        }
    }
}