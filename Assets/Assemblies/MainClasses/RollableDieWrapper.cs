using UnityEngine;

/// <summary>
/// A wrapper class for <see cref="RollableDie"/>
/// </summary>
[System.Serializable]
public class RollableDieWrapper
{
    /*
     * Properties
     */
    public bool ShouldAddRoll { get; private set; }
    public int RolledValue { get; private set; }
    public RollableDie WrappedDie { get; private set; }


    /*
     * Constructors
     */
    // Constructor does not get called if its class is serializable
    public RollableDieWrapper(RollableDie rollableDie)
    {
        WrappedDie = rollableDie;
    }

    
    /*
     * Instance methods
     */
    public void UpdateDie(RollableDie newRollableDie)
    {
        WrappedDie = newRollableDie;
    }

    public void ResetInstance()
    {
        ShouldAddRoll = true;
    }

    /// <summary>
    /// After rolling a die once, update whether future rolls should be added as well
    /// </summary>
    public void UpdateDiceEligibilityForReRolling()
    {
        // For now, only first rolls are eligible to be added
        ShouldAddRoll = false;
    }

    public void RollDie()
    {
        RolledValue = RandomGenerator.GetDieRoll();
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
