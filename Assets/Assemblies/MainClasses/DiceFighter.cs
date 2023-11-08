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
    }

    protected void Start()
    {
    }


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
