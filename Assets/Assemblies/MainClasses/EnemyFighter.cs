using System.Collections.Generic;
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

        OnTurnStart += DoTurn;
    }

    private new void OnDisable()
    {
        base.OnDisable();

        OnTurnStart -= DoTurn;
    }


    /*
     * Instance methods
     */
    public override void DoTurn(object sender, EventArgs eventArgs)
    {
        // Roll all dice
        RollAllDice();

        // Perform the attack
        OnAttackStart?.Invoke();

        EndTurn();
    }

    public override void DoAttack()
    {
        foreach (KeyValuePair<ElementType, int> fighterAttack in FighterAttacks)
        {
            BasicSingleton<FighterGenerator>.Instance.CurrentPlayerFighter.TakeDamage(fighterAttack.Value, fighterAttack.Key);
            Debug.Log($"{name}: Added {fighterAttack.Value} {fighterAttack.Key} damage");
        }
    }
}
