using System.Collections.Generic;
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
    private RollableDieWrapper[] _rollableDice;
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
    protected ElementType FighterElement
    {
        get
        {
            return _elementType;
        }
    }
    // Key = attack element
    // Value = amount of total damage for corresponding element
    protected Dictionary<ElementType, int> FighterAttacks { get; private set; }
    protected RollableDieWrapper[] FighterDice
    {
        get
        {
            return _rollableDice;
        }
    }


    /*
     * Delegates
     */
    protected delegate void DieRolledEvent(int index);
    protected DieRolledEvent OnDieRolled;
    protected delegate void AttackPerformedEvent();
    protected AttackPerformedEvent OnAttackPerformed;
    public delegate void FighterTurnEvent();
    public static FighterTurnEvent OnTurnEnd;


    /*
     * Unity methods
     */
    protected void Awake()
    {
        if (FighterAssets == null)
        {
            throw new System.NullReferenceException("Fighter's assets is not set");
        }
        if (_elementType == null)
        {
            throw new System.NullReferenceException("Element type is not set");
        }
        if (FighterDice == null)
        {
            throw new System.NullReferenceException("Fighter's dice is not set");
        }
        else
        {
            foreach (RollableDieWrapper rollableDie in FighterDice)
            {
                if (rollableDie.WrappedDie == null)
                {
                    throw new System.NullReferenceException("A fighter die is not set");
                }
            }
        }

        GetComponent<SpriteRenderer>().sprite = FighterAssets.FighterTexture;
        _maxHealth = 100;
        _currentHealth = _maxHealth;
        FighterAttacks = new Dictionary<ElementType, int>();
    }

    protected void OnEnable()
    {
        OnDieRolled += RollDie;
        OnDieRolled += AddDieRollToCurrentAttacks;

        OnAttackPerformed += PlayAllDiceAnimations;
        OnAttackPerformed += DoAttack;
    }

    protected void Start()
    {
    }

    private void OnDisable()
    {
        OnDieRolled -= RollDie;
        OnDieRolled -= AddDieRollToCurrentAttacks;

        OnAttackPerformed -= PlayAllDiceAnimations;
        OnAttackPerformed -= DoAttack;
    }


    /*
     * Instance methods
     */
    public abstract void StartTurn();

    public abstract void DoTurn();

    public void EndTurn()
    {
        Debug.Log($"{name}: Ending turn...");
        OnTurnEnd?.Invoke();
    }

    public abstract void DoAttack();

    public void TakeDamage(int damageAmount, ElementType attackElement)
    {
        // Current element is the incoming attack's strength
        if (_elementType == attackElement.ElementStrength)
        {
            _currentHealth -= 2 * damageAmount;
        }
        // Current element is the incoming attack's weakness
        else if (_elementType.ElementStrength == attackElement)
        {
            _currentHealth -= damageAmount / 2;
        }
        else
        {
            _currentHealth -= damageAmount;
        }

        if (_currentHealth <= 0)
        {
            Debug.Log($"{name}: I am dead");
        }
    }

    private void AddDieRollToCurrentAttacks(int index)
    {
        if (index >= 0 && index < FighterDice.Length && 
            FighterDice[index].WrappedDie != null &&
            !FighterDice[index].WasRolledThisTurn)
        {
            ElementType key = FighterDice[index].WrappedDie.DieElement;
            if (FighterAttacks.ContainsKey(key))
            {
                FighterAttacks[key] += FighterDice[index].RolledValue;
            }
            else
            {
                FighterAttacks.Add(key, FighterDice[index].RolledValue);
            }
            Debug.Log($"{name}: Added {FighterDice[index].RolledValue} damage with element {key}");
        }
    }

    private void PlayAllDiceAnimations()
    {
        foreach (RollableDieWrapper rollableDie in FighterDice)
        {
            rollableDie.PlayAnimation();
        }
    }


    /*
     * Interface methods
     */
    public void RollDie(int index)
    {
        if (index >= 0 && index < FighterDice.Length && 
            FighterDice[index].WrappedDie != null)
        {
            FighterDice[index].RollDie();
            Debug.Log($"{name}: Rolled a {FighterDice[index].RolledValue} on die #{index}");
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
