using System;
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
    private FighterStats _fighterStats;
    private int _currentHealth;
    private int _maxHealth;


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
    // Key = attack element
    // Value = amount of total damage for corresponding element
    protected Dictionary<ElementType, int> FighterAttacks { get; private set; }
    protected RollableDieWrapper[] FighterDice { get; private set; }


    /*
     * Delegates
     */
    protected delegate void DieRolledEvent(int index);
    protected DieRolledEvent OnDieRolled;
    protected event EventHandler<EventArgs> OnAttackStart;
    protected event EventHandler<EventArgs> OnTurnStart;
    public static event EventHandler<EventArgs> OnTurnEnd;
    public void StartTurn() => OnTurnStart?.Invoke(this, new EmptyArgs());
    public void StartAttack() => OnAttackStart?.Invoke(this, new EmptyArgs());
    public void EndTurn() => OnTurnEnd?.Invoke(this, new EmptyArgs());


    /*
     * Unity methods
     */
    protected void Awake()
    {
        if (FighterAssets == null)
        {
            throw new NullReferenceException("Fighter's assets is not set");
        }
        if (_fighterStats == null)
        {
            throw new NullReferenceException("Fighter's stats SO is not set");
        }
    }

    protected void OnEnable()
    {
        OnTurnStart += ResetDiceInstances;
        OnTurnStart += RemoveAllCurrentAttacks;

        OnDieRolled += RollDie;
        OnDieRolled += AddDieRollToCurrentAttacks;

        OnAttackStart += PlayAllDiceAnimations;
        OnAttackStart += DoAttack;

        BasicSingleton<FloorManager>.Instance.OnInitializeFighters += LoadInitialStats;
    }

    // Do not implement Start() here
    // Want to ensure the arbitrary execution order of all classes' Start() does not mess anything up

    protected void OnDisable()
    {
        OnTurnStart -= ResetDiceInstances;
        OnTurnStart -= RemoveAllCurrentAttacks;

        OnDieRolled -= RollDie;
        OnDieRolled -= AddDieRollToCurrentAttacks;

        OnAttackStart -= PlayAllDiceAnimations;
        OnAttackStart -= DoAttack;

        BasicSingleton<FloorManager>.Instance.OnInitializeFighters -= LoadInitialStats;
    }


    /*
     * Instance methods
     */
    private void LoadInitialStats(object sender, EventArgs eventArgs)
    {
        GetComponent<SpriteRenderer>().sprite = FighterAssets.FighterTexture;

        _maxHealth = _fighterStats.MaximumHealth;
        _currentHealth = _maxHealth;

        FighterDice = new RollableDieWrapper[_fighterStats.RollableDice.Length];
        for (int i = 0; i < _fighterStats.RollableDice.Length; i++)
        {
            FighterDice[i] = new RollableDieWrapper(_fighterStats.RollableDice[i]);
        }

        FighterAttacks = new Dictionary<ElementType, int>();
    }

    public void UpdateStats(FighterStats newFighterStats)
    {
        _fighterStats = newFighterStats;

        _maxHealth = _fighterStats.MaximumHealth;
        _currentHealth = _maxHealth;

        for (int i = 0; i < _fighterStats.RollableDice.Length; i++)
        {
            FighterDice[i].UpdateDie(_fighterStats.RollableDice[i]);
        }
    }

    /// <summary>
    /// Call to re-initialize the fighter's dice
    /// </summary>
    protected void ResetDiceInstances(object sender, EventArgs eventArgs)
    {
        foreach (RollableDieWrapper rollableDieWrapper in FighterDice)
        {
            rollableDieWrapper.ResetInstance();
        }
    }

    public abstract void DoTurn(object sender, EventArgs eventArgs);

    public abstract void DoAttack(object sender, EventArgs eventArgs);

    public void TakeDamage(int damageAmount, ElementType attackElement)
    {
        // Current element is the incoming attack's strength
        if (_fighterStats.FighterElement == attackElement.ElementStrength)
        {
            _currentHealth -= 2 * damageAmount;
        }
        // Current element is the incoming attack's weakness
        else if (_fighterStats.FighterElement.ElementStrength == attackElement)
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
            FighterDice[index].ShouldAddRoll)
        {
            FighterDice[index].UpdateDiceEligibilityForReRolling();

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

    private void RemoveAllCurrentAttacks(object sender, EventArgs eventArgs)
    {
        FighterAttacks.Clear();
    }

    private void PlayAllDiceAnimations(object sender, EventArgs eventArgs)
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
            //Debug.Log($"{name}: Rolled a {FighterDice[index].RolledValue} on die #{index}");
        }
    }

    public void RollAllDice()
    {
        for (int i = 0; i < FighterStats.MaxDicePerFighter; i++)
        {
            OnDieRolled?.Invoke(i);
        }
    }
}
