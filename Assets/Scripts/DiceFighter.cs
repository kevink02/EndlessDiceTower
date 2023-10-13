using UnityEngine;

public class DiceFighter : MonoBehaviour, IDiceRoller
{
    [SerializeField]
    private DiceFighterAssets _diceRollerAssets;
    [SerializeField]
    private RollableDie _rollableDie;

    private void Awake()
    {
        if (_diceRollerAssets)
        {
        }
    }


    /*
     * Interface methods
     */
    public void RollDie()
    {
        if (_rollableDie)
        {
            _rollableDie.SetRolledValue();
            _rollableDie.PlayAnimation();
        }
    }
}
