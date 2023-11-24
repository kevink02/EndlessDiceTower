using UnityEngine;

/// <summary>
/// A wrapper class for <see cref="RollableDie"/>
/// </summary>
[System.Serializable]
public class RollableDieWrapper
{
    /*
     * Instance variables
     */
    [SerializeField]
    private RollableDie _wrappedRollableDie;


    /*
     * Properties
     */
    public bool WasRolledThisTurn { get; private set; }
    public int RolledValue { get; private set; }
    public RollableDie WrappedDie
    {
        get
        {
            return _wrappedRollableDie;
        }
    }


    /*
     * Constructors
     */
    // Constructor does not get called if its class is serializable
    public RollableDieWrapper(RollableDie rollableDie)
    {
        //WrappedDie = rollableDie;
    }

    
    /*
     * Instance methods
     */
    public void RollDie()
    {
        // Only allow rolling the die once
        if (!WasRolledThisTurn)
        {
            RolledValue = RandomGenerator.GetDieRoll();
            WasRolledThisTurn = true;
        }
        else
        {
            Debug.Log($"You already rolled {WrappedDie.name}");
        }
    }

    public void PlayAnimation()
    {
        switch (RolledValue)
        {
            case 1:
            case 2:
            case 3:
                Debug.Log($"Animation #1: {WrappedDie.AttackAnimations[0]}");
                return;
            case 4:
            case 5:
            case 6:
                Debug.Log($"Animation #2: {WrappedDie.AttackAnimations[1]}");
                return;
            default:
                Debug.LogError($"Rolled value {RolledValue} is invalid");
                return;
        }
    }
}
