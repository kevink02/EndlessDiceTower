using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Fighter's Stats")]
public class FighterStats : ScriptableObject
{
    /*
     * Instance variables
     */
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
    private void OnEnable()
    {
        if (_rollableDice.Length > MaxDicePerFighter)
        {
            throw new System.Exception("The fighter has too many dice equipped");
        }
        else if (_rollableDice.Length == 0)
        {
            throw new System.Exception("The fighter has no dice equipped");
        }
    }
}
