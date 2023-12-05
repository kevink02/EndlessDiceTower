using System;
using UnityEngine;


public class FighterStatsArgs : EventArgs
{
    /*
     * Properties
     */
    public FighterStats NewFighterStats { get; private set; }

    /*
     * Constructors
     */
    public FighterStatsArgs(FighterStats fighterStats)
    {
        NewFighterStats = fighterStats;
    }
}


[CreateAssetMenu(menuName = "New Fighter's Stats")]
public class FighterStats : ScriptableObject
{
    /*
     * Instance variables
     */
    [SerializeField]
    private ElementType _elementType;
    [SerializeField]
    private int _maximumHealth;
    [SerializeField]
    private RollableDie[] _rollableDice;


    /*
     * Constant variables
     */
    public const int MaxDicePerFighter = 3;


    /*
     * Properties
     */
    public ElementType FighterElement
    {
        get
        {
            return _elementType;
        }
    }
    public int MaximumHealth
    {
        get
        {
            return _maximumHealth;
        }
    }
    public RollableDie[] RollableDice
    {
        get
        {
            return _rollableDice;
        }
    }


    /*
     * Unity methods
     */
    private void OnValidate()
    {
        if (_elementType == null)
        {
            throw new NullReferenceException("Element type is not set");
        }
        if (_maximumHealth <= 0)
        {
            throw new Exception("The fighter's health is too low");
        }
        if (_rollableDice.Length > MaxDicePerFighter)
        {
            throw new Exception("The fighter has too many dice equipped");
        }
        else if (_rollableDice.Length == 0)
        {
            throw new Exception("The fighter has no dice equipped");
        }
    }
}
