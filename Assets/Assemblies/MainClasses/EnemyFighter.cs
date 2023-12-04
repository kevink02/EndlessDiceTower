using UnityEngine;

public class EnemyFighter : DiceFighter
{
    /*
     * Unity methods
     */
    private new void Awake()
    {
        base.Awake();
    }

    private new void OnEnable()
    {
        base.OnEnable();
    }

    private new void OnDisable()
    {
        base.OnDisable();
    }


    /*
     * Instance methods
     */
    public override void ResetInstance(object sender, EventArgs eventArgs)
    {
        Debug.Log($"Resetting {name}'s instance");
    }

    public override void DoTurn()
    {
        // Roll all dice
        for (int i = 0; i < 3; i++)
        {
            OnDieRolled?.Invoke(i);
        }

        // Perform the attack
        OnAttackPerformed?.Invoke();

        EndTurn();
    }
}
