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
        if (FighterAssets)
        {
            GetComponent<SpriteRenderer>().sprite = FighterAssets.FighterTexture;
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
        if (FighterDice != null && index >= 0 && index < FighterDice.Length && FighterDice[index])
        {
            FighterDice[index].SetRolledValue();
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
