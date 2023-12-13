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

        OnSelfDefeated += EventManager.Instance.CreateNewFloor;
    }

    private new void OnDisable()
    {
        base.OnDisable();

        OnTurnStart -= DoTurn;

        OnSelfDefeated -= EventManager.Instance.CreateNewFloor;
    }


    /*
     * Instance methods
     */
    public override void DoTurn(object sender, EventArgs eventArgs)
    {
        // Roll all dice
        RollAllDice();

        StartAttack();

        EndTurn();
    }

    public override void DoAttack(object sender, EventArgs eventArgs)
    {
        foreach (KeyValuePair<ElementType, int> fighterAttack in FighterAttacks)
        {
            BasicSingleton<FighterGenerator>.Instance.CurrentPlayerFighter.TakeDamage(fighterAttack.Value, fighterAttack.Key);
            Debug.Log($"{name}: Added {fighterAttack.Value} {fighterAttack.Key} damage");
        }
    }
}
