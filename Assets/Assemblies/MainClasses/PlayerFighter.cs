using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFighter : DiceFighter
{
    /*
     * Instance variables
     */
    private PlayerInputActions _playerInputActions;


    /*
     * Unity methods
     */
    private new void Awake()
    {
        base.Awake();

        _playerInputActions = new PlayerInputActions();
    }

    private new void OnEnable()
    {
        base.OnEnable();

        OnTurnStart += EnableDiceRolling;

        OnTurnEnd += DisableDiceRolling;

        OnSelfDefeated += EndGame;

        _playerInputActions.DiceRolling.RollDie1.performed += cxt => RollFirstDie();
        _playerInputActions.DiceRolling.RollDie2.performed += cxt => RollSecondDie();
        _playerInputActions.DiceRolling.RollDie3.performed += cxt => RollThirdDie();
        _playerInputActions.DiceAttack.Attack.performed += cxt => StartAttack();
        _playerInputActions.DiceAttack.Attack.performed += cxt => EndTurn();

        _playerInputActions.DiceRolling.Enable();
        _playerInputActions.DiceAttack.Enable();
    }

    private new void OnDisable()
    {
        base.OnDisable();

        OnTurnStart -= EnableDiceRolling;

        OnTurnEnd -= DisableDiceRolling;

        OnSelfDefeated -= EndGame;

        _playerInputActions.DiceRolling.RollDie1.performed -= cxt => RollFirstDie();
        _playerInputActions.DiceRolling.RollDie2.performed -= cxt => RollSecondDie();
        _playerInputActions.DiceRolling.RollDie3.performed -= cxt => RollThirdDie();
        _playerInputActions.DiceAttack.Attack.performed -= cxt => StartAttack();
        _playerInputActions.DiceAttack.Attack.performed -= cxt => EndTurn();

        _playerInputActions.DiceRolling.Disable();
        _playerInputActions.DiceAttack.Disable();
    }


    /*
     * Instance methods
     */
    private void EnableDiceRolling(object sender, EventArgs eventArgs)
    {
        _playerInputActions.DiceRolling.Enable();
        _playerInputActions.DiceAttack.Enable();
    }

    private void DisableDiceRolling(object sender, EventArgs eventArgs)
    {
        _playerInputActions.DiceRolling.Disable();
        _playerInputActions.DiceAttack.Disable();
    }

    private void RollDie(InputAction.CallbackContext context)
    {
        Debug.Log($"key: {context}");
        Debug.Log($"keyControl: {context.control}");
        // Debug.Log($"keyValue: {context.ReadValue<float>()}");

        var arr = context.action.bindings;
        int index = 0;
        foreach (var v in arr)
        {
            Debug.Log($"keyInArr: {v}");
            index++;
        }
    }

    public override void DoTurn(object sender, EventArgs eventArgs)
    {
        throw new System.NotImplementedException();
    }

    public override void DoAttack(object sender, EventArgs eventArgs)
    {
        foreach (KeyValuePair<ElementType, int> fighterAttack in FighterAttacks)
        {
            BasicSingleton<FighterGenerator>.Instance.CurrentEnemyFighter.TakeDamage(fighterAttack.Value, fighterAttack.Key);
            Debug.Log($"{name}: Added {fighterAttack.Value} {fighterAttack.Key} damage");
        }
    }

#warning This is a placeholder. Move this method eventually to another more appropriate class.
    private void EndGame(object sender, EventArgs eventArgs)
    {
        Debug.Log($"{name}: You lost!");
    }
}
