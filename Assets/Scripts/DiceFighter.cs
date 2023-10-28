using UnityEngine;

public abstract class DiceFighter : MonoBehaviour, IDiceRoller
{
    /*
     * Instance variables
     */
    [SerializeField]
    private DiceFighterAssets _diceRollerAssets;
    [SerializeField]
    private RollableDie[] _rollableDice;


    /*
     * Class variables
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
     * Unity methods
     */
    protected void Awake()
    {
        if (_diceRollerAssets)
        {
            GetComponent<SpriteRenderer>().sprite = _diceRollerAssets.FighterTexture;
        }
    }

    // Stuff that should be done once singletons and events are set up
    protected void Start()
    {
        BasicSingleton<TurnManager>.Instance.FighterTurnQueue.Enqueue(this);
    }


    /*
     * Interface methods
     */
    public void RollDie(int index)
    {
        if (_rollableDice != null && index >= 0 && index < _rollableDice.Length && _rollableDice[index])
        {
            _rollableDice[index].SetRolledValue();
            _rollableDice[index].PlayAnimation();
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
